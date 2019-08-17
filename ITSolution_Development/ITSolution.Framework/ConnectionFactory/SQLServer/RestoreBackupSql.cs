using System;
using System.IO;
using System.Linq;
using System.Text;
using ITSolution.Framework.Mensagem;
using Microsoft.SqlServer.Management.Smo;

namespace ITSolution.Framework.ConnectionFactory.SQLServer
{
    /// <summary>
    /// Classe responsavél por restaurar um backup de dados do SQL server.
    /// </summary>
    public class RestoreBackupSql
    {
        //fonte 
        //https://www.mssqltips.com/sqlservertip/1849/backup-and-restore-sql-server-databases-programmatically-with-smo/
        private Restore createRestoreDB(string database, string pathBackup, string serverName = "(local)" )
        {
            if (!File.Exists(pathBackup))
            {
                throw new FileNotFoundException("Arquivo de backup não encontrado !");
            }

            if (!pathBackup.EndsWith(".bak"))
            {
                throw new ArgumentException("Arquivo de backup inválido. O arquivo deve ter a extensão .bak.");
            }
            Restore restoreDB = new Restore();
            restoreDB.Database = database;
            // Specify whether you want to restore database, files or log
            restoreDB.Action = RestoreActionType.Database;

            restoreDB.Devices.AddDevice(pathBackup, DeviceType.File);

            /* You can specify ReplaceDatabase = false (default) to not create a new
             * database, the specified database must exist on SQL Server
             * instance. If you can specify ReplaceDatabase = true to create new
             * database image regardless of the existence of specified database with
             * the same name */
            restoreDB.ReplaceDatabase = true;

            /* If you have a differential or log restore after the current restore,
             * you would need to specify NoRecovery = true, this will ensure no
             * recovery performed and subsequent restores are allowed. It means it
             * the database will be in a restoring state. */
            restoreDB.NoRecovery = true;

            ///* Wiring up events for progress monitoring */
            //restoreDB.PercentComplete += CompletionStatusInPercent;
            //restoreDB.Complete += Restore_Completed;


            return restoreDB;
        }

        /// <summary>
        /// Realize o backup completo do banco de dados.
        /// Restaurações Completas ou Diferenciais
        /// </summary>
        /// <param name="pathBackup"></param>Nome da base dados
        /// <param name="directoryBackup"></param>Diretorio a ser salvo o backup da base
        public bool RestoreBackupFullFromDatabase(string database, string pathBackup, string serverName = "(local)")
        {
            //Restaurações Completas ou Diferenciais  -Com essas classes é necessário especificar a propriedade "Ação" 
            //para indicar o tipo de restauração, isto é, banco de dados, arquivos ou log.
            //Em um cenário em que se você tiver backups diferenciais ou de log adicionais para serem restaurados 
            //depois que for necessário especificar o "NoRecovery = true", exceto para a restauração final.
            //Neste exemplo, estou conectando eventos da instância de objeto de restauração para manipuladores 
            //de eventos para monitoramento de progresso.Finalmente, o método SqlRestore é chamado para iniciar a restauração.
            Restore restoreDB = createRestoreDB(database, pathBackup, serverName);

            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            try
            {

                /* SqlRestore method starts to restore the database
                 * You can also use SqlRestoreAsync method to perform restore
                 * operation asynchronously */
                //restoreDB.SqlRestore(server);
                StringBuilder sbScriptRestore = new StringBuilder();

                sbScriptRestore.Append("RESTORE DATABASE ");
                sbScriptRestore.Append(database);
                sbScriptRestore.Append(" FROM DISK = '");
                sbScriptRestore.Append(pathBackup);
                sbScriptRestore.Append("' WITH FILE = 1, STATS = 1");

                var con = new ConnectionLocalSql();
                
                con.ExecuteQuery(sbScriptRestore.ToString());

                string result = con.GetDataBases().Where(d => d.ToString() == database).First();

                //string script = "@RESTORE DATABASE " + database +  " FROM DISK = '"  + pathBackup + "' WITH FILE = 1, STATS = 1";
                //chegou aqui ok
                return result.Equals(database);
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha na restauração do backup!");

                return false;
            }

        }

        /// <summary>
        ///Restaura um banco de dados em um novo local
        ///Quando for preciso criar um novo banco de dados e restaurá-lo em um novo local físico 
        ///que difere do banco de dados original. 
        ///Para esse efeito, a classe "Restore" tem a coleção "RelocateFiles" que pode ser concluída 
        ///para cada arquivo com o novo local.
        /// </summary>
        /// <param name="pathBackup"></param>
        /// <param name="serverName"></param>
        /// <param name="newLocation"></param>
        public bool RestoreBackupToNewLocation(string database, string pathBackup, string serverName = "(local)",
            string newLocation = null)
        {
            Restore restoreDB = new Restore();
            restoreDB.Database = database + "New";
            /* Specify whether you want to restore database or files or log etc */
            restoreDB.Action = RestoreActionType.Database;
            restoreDB.Devices.AddDevice(pathBackup, DeviceType.File);

            /* You can specify ReplaceDatabase = false (default) to not create a new
             * database, the specified database must exist on SQL Server instance.
             * You can specify ReplaceDatabase = true to create new database
             * regardless of the existence of specified database */
            restoreDB.ReplaceDatabase = true;

            /* If you have a differential or log restore to be followed, you would
             * specify NoRecovery = true, this will ensure no recovery is done
             * after the restore and subsequent restores are completed. The database
             * would be in a recovered state. */
            restoreDB.NoRecovery = false;

            /* RelocateFiles collection allows you to specify the logical file names
             * and physical file names (new locations) if you want to restore to a
             * different location.*/

            var path_noext = Path.GetFileNameWithoutExtension(newLocation);

            restoreDB.RelocateFiles.Add(new RelocateFile(newLocation + "_Data", path_noext + ".mdf"));
            restoreDB.RelocateFiles.Add(new RelocateFile(newLocation + "_Log", path_noext + ".ldf"));

            ///* Wiring up events for progress monitoring */
            //restoreDB.PercentComplete += CompletionStatusInPercent;
            //restoreDB.Complete += Restore_Completed;

            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);

            try
            {

                /* SqlRestore method starts to restore the database
                 * You can also use SqlRestoreAsync method to perform restore
                 * operation asynchronously */
                restoreDB.SqlRestore(server);
                return true;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha na restauração do backup!");

                return false;
            }
        }

        /// <summary>
        /// Restaura o backup da transação de logs de uma base dados do SQL server.
        /// Restauração do Registro de Transações
        /// O processo de restauração de um log transacional é semelhante a restauração
        /// de um backup completo ou diferencial. 
        /// Ao restaurar um log transacional, é necessário definir a propriedade 
        /// Action = RestoreActionType.Log em vez de RestoreActionType.Database 
        /// como no caso de restauração completa/diferencial.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="serverName"></param>
        /// <param name="pathBackup"></param>
        public bool RestoreBackupTransactionLogFromDatabase(string database, string pathBackup, string serverName = "(local)")
        {
            Restore restoreDBLog = createRestoreDB(database, pathBackup, serverName);

            restoreDBLog.Action = RestoreActionType.Log;
            //Servidor onde devo disparar a ação
            //por padrão é o (local)
            Server server = new Server(serverName);
            try
            {
                /* SqlRestore method starts to restore the database
                 * You can also use SqlRestoreAsync method to perform restore
                 * operation asynchronously */
                restoreDBLog.SqlRestore(server);
                return true;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha na restauração do backup!");

                return false;
            }
        }

    }
}