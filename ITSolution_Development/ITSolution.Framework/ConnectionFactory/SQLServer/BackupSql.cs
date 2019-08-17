using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using Microsoft.SqlServer.Management.Smo;

namespace ITSolution.Framework.ConnectionFactory.SQLServer
{
    /// <summary>
    /// Classe responsavél por realizar backup de uma base dados do SQL Server
    /// </summary>
    public class BackupSql
    {
        //Padrao de backup eh completo
        //fonte 
        //https://www.mssqltips.com/sqlservertip/1849/backup-and-restore-sql-server-databases-programmatically-with-smo/

        private string _pathBackup;

        private Backup createBackup(AppConfigIts appConfig, string directory )
        {
            string database = appConfig.Database;

            if (string.IsNullOrWhiteSpace(database))
            {
                throw new ArgumentException("Nome do banco de dados não pode nulo e nem conter espaços");
            }
            //Com a propriedade Ação, você pode especificar o tipo de backup, como backup completo, arquivos ou log. 
            //Com a propriedade banco de dados especificar o nome do banco de dados que está sendo feito backup.
            //O dispositivo é o tipo de mídia de backup, como disco ou fita, portanto, é necessário 
            //adicionar um dispositivo (um ou mais) à coleção Dispositivos da instância de backup.
            //Com as propriedades BackupSetName e BackupSetDescription, você pode especificar o nome e a descrição 
            //para o conjunto de backup. 
            //A classe Backup também tem uma propriedade chamada ExpirationDate que indica quanto tempo os 
            //dados de backup são considerados válidos e expirar o backup após essa data.
            //A instância de objeto de backup gera vários eventos durante a operação de backup, podemos gravar 
            //manipuladores de eventos para esses eventos e conectá - los com eventos. 
            //É isso que estou fazendo para monitorar o progresso.Estou conectando os métodos 
            //CompletionStatusInPercent e Backup_Completed(manipuladores de eventos) com eventos PercentComplete e Complete 
            //da instância do objeto de backup.Finalmente, estou chamando o método SqlBackup para iniciar a operação de backup, 
            //SMO fornece uma variante desse método chamado SqlBackupAsync 
            //se você deseja iniciar a operação de backup de forma assíncrona.
            Backup bkpDbFull = new Backup();

            // Specify whether you want to back up database or files or log 
            bkpDbFull.Action = BackupActionType.Database;

            // Specify the name of the database to back up 
            bkpDbFull.Database = database;

            string databaseName = database + "_" + DataUtil.ToDateSql() + ".bak";
            if (directory == null)
            {
                //aponta direto pro aquivo .exe
                //string exe = Application.ExecutablePath;
                //path do backup sera na pasta do programa => DEBUG/database-date.bak
                directory = Path.Combine(Application.StartupPath, databaseName);

                //arquivo do bak
                bkpDbFull.Devices.AddDevice(directory, DeviceType.File);

            }
            else
            {
                directory = Path.Combine(directory, databaseName);
                bkpDbFull.Devices.AddDevice(directory, DeviceType.File);

            }

            this._pathBackup = directory;


            bkpDbFull.BackupSetName = database.ToUpper() + " database Backup";
            bkpDbFull.BackupSetDescription = database.ToUpper() + " database - Full Backup";
            // You can specify the expiration date for your backup data
            //after that date backup data would not be relevant
            //bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);

            /* You can specify Initialize = false (default) to create a new
             * backup set which will be appended as last backup set on the media. You
             * can specify Initialize = true to make the backup as first set on the
             * medium and to overwrite any other existing backup sets if the all the
             * backup sets have expired and specified backup set name matches with
             * the name on the medium */
            bkpDbFull.Initialize = true;//false concatena o backup


            //Esses sao eventos para serem usados em modo Console.
            // Wiring up events for progress monitoring 
            //bkpDBFull.PercentComplete +=  CompletionStatusInPercent;
            //bkpDBFull.Complete += Backup_Completed;

            return bkpDbFull;
        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Full
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public bool BackupFullFromDatabase(AppConfigIts appConfig, string directory = null)
        {
            Backup bkpDbFull = createBackup(appConfig, directory);

            string serverName = appConfig.ServerName;

            //Servidor onde devo disparar a ação
            Server server = new Server(serverName);

            try
            {

                /* SqlBackup method starts to take back up
                 * You can also use SqlBackupAsync method to perform the backup
                 * operation asynchronously */
                bkpDbFull.SqlBackup(server);

                return true;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha durante o processo de backup!");

                return false;
            }
        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Full utilizando instrução SQL
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public bool BackupNativoFullFromDatabase(AppConfigIts appConfig, string directory)
        {
            //seta o path de backup
            createBackup(appConfig, directory);
            try
            {
             
                var scriptSql = new StringBuilder();
                scriptSql.Append("BACKUP DATABASE ");
                scriptSql.Append(appConfig.Database);
                scriptSql.Append(" TO DISK = ");
                scriptSql.Append("'");
                scriptSql.Append(_pathBackup);
                scriptSql.Append("' ");
                scriptSql.Append("WITH NO_COMPRESSION, NAME = ");
                scriptSql.Append("'");
                scriptSql.Append(appConfig.Database);
                scriptSql.Append("-Full Database backup', FORMAT, INIT, NOREWIND, NOUNLOAD, STATS = 1");

                try
                {
                    var a = new ConnectionLocalSql(appConfig.ConnectionString).ExecuteQuery(scriptSql.ToString());

                    if (File.Exists(this._pathBackup))
                    {
                        //se o arquivo foi compactado
                        if (ZipUtil.CompressFile(this._pathBackup))
                            File.Delete(this._pathBackup);
                    }
              
                }
                catch (SqlException sqle)
                {
                    XMessageIts.ExceptionMessageDetails(sqle, "Falha durante o processo de backup!");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha durante o processo de backup!");

                return false;

            }

        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Full
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public void BackupFullFromDatabaseAsync(AppConfigIts appConfig, string directory)
        {
            Backup bkpDbFull = createBackup(appConfig, directory);

            string serverName = appConfig.ServerName;
            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            bkpDbFull.SqlBackupAsync(server);

        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Full
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public bool BackupFullCompressFromDatabase(AppConfigIts appConfig, string directory)
        {
            bool result = BackupFullFromDatabase(appConfig, directory);

            if (File.Exists(this._pathBackup))
            {
                //se o arquivo foi compactado
                if (ZipUtil.CompressFile(this._pathBackup))
                    File.Delete(this._pathBackup);
            }

            return result;
        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Full
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public async void BackupFullCompressFromDatabaseAsync(AppConfigIts appConfig, string directory)
        {

            Backup bkpDbFull = createBackup(appConfig, directory);

            string serverName = appConfig.ServerName;

            //Servidor onde devo disparar a ação
            Server server = new Server(serverName);

            await Task.Run(() => bkpDbFull.SqlBackupAsync(server));

            if (File.Exists(this._pathBackup))
            {
                if (ZipUtil.CompressFile(this._pathBackup))
                    File.Delete(this._pathBackup);
            }
        }

        /// <summary>
        /// Realiza backup de uma base dados do SQL server.
        /// Backup Different
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public void BackupDifferentFromDatabase(AppConfigIts appConfig, string directory)
        {
            //O processo de emissão de backups diferenciais não é muito diferente da emissão de backups completos. 
            //Para emitir um backup diferencial, defina a propriedade Incremental = true.
            //Se você definir essa propriedade, o backup incremental / diferencial será realizado 
            //desde o último backup completo.

            Backup bkpDbDifferential = createBackup(appConfig, directory);
            string database = appConfig.Database;
            string serverName = appConfig.ServerName;

            bkpDbDifferential.BackupSetDescription = database.ToUpper() + " database - Differential Backup";

            /* You can specify Incremental = false (default) to perform full backup
             * or Incremental = true to perform differential backup since most recent
             * full backup */
            bkpDbDifferential.Incremental = true;

            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            /* SqlBackup method starts to take back up
             * You can also use SqlBackupAsync method to perform the backup
             * operation asynchronously */
            bkpDbDifferential.SqlBackup(server);

        }


        /// <summary>
        /// Realiza backup da transação de logs de uma base dados do SQL server.
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public void BackupTransactionLogFromDatabase(AppConfigIts appConfig, string directory)
        {
            //Backups de log de transações - Mais uma vez, o processo de emissão de backup de log transacional 
            //não é muito diferente da emissão de backups completos.
            //Para emitir backups de log transacional, defina a propriedade Action = BackupActionType.Log 
            //em vez de BackupActionType.Database como no caso de um backup completo.
            Backup bkpDbLog = createBackup(appConfig, directory);

            string database = appConfig.Database;
            string serverName = appConfig.ServerName;

            /* Specify whether you want to back up database or files or log */
            bkpDbLog.Action = BackupActionType.Log;

            bkpDbLog.BackupSetDescription = database.ToUpper() + " database - Log Backup";

            /* You can specify Incremental = false (default) to perform full backup
             * or Incremental = true to perform differential backup since most recent
             * full backup */
            bkpDbLog.Incremental = true;

            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            /* SqlBackup method starts to take back up
             * You can also use SqlBackupAsync method to perform the backup
             * operation asynchronously */
            bkpDbLog.SqlBackup(server);

        }


        /// <summary>
        /// BACKUP DATABASE WITH COMPRESSION is not supported on Express Edition (64-bit).
        /// Backup com compressão - Esse backup reduz quase 75% do tamanho do backup original.*/
        /// </summary>
        /// <param name="appConfig"></param>
        /// <param name="directory"></param>
        public void BackupCompressFromDatabase(AppConfigIts appConfig, string directory)
        {
            Backup bkpDbFullWithCompression = createBackup(appConfig, directory);

            string database = appConfig.Database;
            string serverName = appConfig.ServerName;

            /* You can use back up compression technique of SQL Server 2008,
             * specify CompressionOption property to On for compressed backup */
            bkpDbFullWithCompression.CompressionOption = BackupCompressionOptions.On;

            bkpDbFullWithCompression.BackupSetName = database.ToUpper() + " database Backup - Compressed";
            bkpDbFullWithCompression.BackupSetDescription = database.ToUpper() + " database - Full Backup with Compressin";

            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            /* SqlBackup method starts to take back up
             * You can also use SqlBackupAsync method to perform the backup
             * operation asynchronously */
            bkpDbFullWithCompression.SqlBackup(server);

        }

        /*  EVENTOS DISPARADOS QUANDO USADO EM MODO CONSOLE
        private  void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Percent completed: {0}%.", args.Percent);
        }
        private  void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Hurray...Backup completed.");
            Console.WriteLine(args.Error.Message);
        }
        private  void Restore_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Hurray...Restore completed.");
            Console.WriteLine(args.Error.Message);
        }
        */
    }
}
