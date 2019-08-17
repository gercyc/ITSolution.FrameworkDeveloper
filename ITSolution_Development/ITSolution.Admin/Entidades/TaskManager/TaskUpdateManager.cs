using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Windows.Forms;
using ITSolution.Admin.Repositorio;
using ITSolution.Framework.Arquivos;

namespace ITSolution.Admin.Entidades.TaskManager
{
    public class TaskUpdateManager
    {

        //OK
        public void UpdateDLLsITE(string source, string tarjet)
        {
            var files = FileManagerIts.ToFiles(source, new string[] { ".dll", ".pdb", ".exe" });
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if (fileName != null && fileName.StartsWith("ITE."))
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(tarjet, fileName);
                    //copia o arquivo para o diretorio ou sobreescreve se ele existir
                    FileManagerIts.CopyFile(f, newSource);
                }
            }

            //com lambda ficou foi mais complicado de entender posteriormente
            //FileManagerIts.ToFiles(temp)
            //    .Where(f => f.ToString() != null && !f.StartsWith("ITE."))
            //    .ToList().ForEach(File.Delete);
        }

        public void UpdateSystemDLLs(string source, string tarjet)
        {
            string startup = Application.StartupPath;
            //altera o path
            //..\ITSolution\ITSolution.Admin\bin\Debug
            //..\ITE\ITE.Forms\bin\Debug\
            if (string.IsNullOrEmpty(source))
            {
                source = startup.Replace(@"\ITSolution\ITSolution.Admin", @"\ITE\ITE.Forms");
                source = source.Replace(@"\ITE\ITE.Teste", @"\ITE\ITE.Forms");
            }


            var files = FileManagerIts.ToFiles(source, new string[] { ".dll", ".pdb", ".exe" });
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if (fileName.StartsWith("ITE.") || fileName.StartsWith("ITSolution."))
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(tarjet, fileName);
                    //copia o arquivo para o diretorio ou sobreescreve se ele existir
                    FileManagerIts.CopyFile(f, newSource);
                    Console.WriteLine(fileName);
                }
            }
        }


        //OK Graças a Deus
        public void UpdateDLLsITSolution(string source, string tarjet)
        {
            var files = FileManagerIts.ToFiles(source, new string[] { ".dll", ".pdb", ".exe" });
            //vai o foreach normal mesmo
            foreach (var f in files)
            {
                string fileName = Path.GetFileName(f);
                if (fileName != null && fileName.StartsWith("ITSolution."))
                {
                    //gera o caminho do arquivo
                    string newSource = Path.Combine(tarjet, fileName);
                    //copia o arquivo para o diretorio ou sobreescreve se ele existir
                    FileManagerIts.CopyFile(f, newSource);
                }
            }
        }

        //PQP consegui
        /// <summary>
        /// Copia todo conteúdo do diretório para outro
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tarjet"></param>
        public void UpdateSoftware(string source, string tarjet)
        {
            //encapsulado pro ITE
            FileManagerIts.DirectoryCopy(source, tarjet);
        }

        /// <summary>
        /// Verifica o programa esta instalado na máquina cliente
        /// Diretórios setados no ITESetup:
        ///     Raiz:
        ///     Raiz:\Program Files
        ///     Raiz:\Program Files (x86)
        /// </summary>
        /// <returns></returns>
        public string DetectInstallDir()
        {
            var root = FileManagerIts.ToDiskUnit();
            //diretorio padrão é esse
            //32 e 64 bits
            string localx86 = @"\Program Files (x86)\ITS\ITE\";
            string localx64 = @"\Program Files\ITS\ITE\";
            string local = "";

            //checa todas as unidade x64 e x86 em busca do local de instalação            
            for (int i = 0; i < root.Length / 2; i++)
            {
                //a letra da unidade
                string letter = root[i];

                //verificar se alguem instalou na raiz do disco tbm
                var raiz = letter + "\\ITE";

                //se existe
                if (Directory.Exists(raiz))
                {
                    i = 26;//termina o laco
                    local = raiz;
                }
                else
                {
                    //tenta no x86 primeiro
                    local = letter + localx86;

                    //nao existe diretorio no x86
                    if (!Directory.Exists(local))
                        //entao tente no x64
                        local = letter + localx64;

                    //verificase se exite no x64
                    if (Directory.Exists(local))
                        i = 26;//termina o laco
                               //continua procurando
                }
            }

            if (Directory.Exists(local))
                return local;
            return local;
        }

        #region Uso Interno
        public static void UpdateDllsFromDisk()
        {
            string tarjet = @"D:\OneDrive\ITE Clients\Flp";
            //diretorio do diretorio
            new TaskUpdateManager().UpdateSystemDLLs(null, tarjet);
        }

        public static void InstallProceduresNFunctions()
        {
            string proc = @"D:\Program Files\TFS\ITSolution\ITSolution.Admin\SQLs\procedures";
            string func = @"D:\Program Files\TFS\ITSolution\ITSolution.Admin\SQLs\functions";

            ExecDDL(proc);
            ExecDDL(func);
        }
        public static void InstallProcedures()
        {
            string proc = @"D:\Program Files\TFS\ITSolution\ITSolution.Admin\SQLs\procedures";

            ExecDDL(proc);
        }

        public static void InstallFunctions()
        {
            string func = @"D:\Program Files\TFS\ITSolution\ITSolution.Admin\SQLs\functions";
            ExecDDL(func);
        }

        //Uso Particular -> Chamada recursiva 
        private static void ExecDDL(string resource)
        {

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var cnn = new AdminContext().ConnectionSql)
                {
                    cnn.OpenConnection();
                    var connection = cnn.Connection;

                    try
                    {
                        Dictionary<string, bool> statusScripts = new Dictionary<string, bool>();
                        List<SqlCommand> commands = new List<SqlCommand>();
                        //cria a transacao
                        cnn.Transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted, "myTransaction");


                        //de tudo .sql q esta la dentro

                        var sqlFiles = new FileManagerIts().ToFilesRecursive(resource);
                        var sqls = sqlFiles.Where(file => file.ToString().EndsWith(".sql"));
                        foreach (var sql in sqlFiles)
                        {
                            var sqlFileName = Path.GetFileName(sql);
                            Console.WriteLine("Executando script: " + sqlFileName);
                            var sqlQuery = FileManagerIts.GetDataStringFile(sql);
                            // split script on GO command
                            IEnumerable<string> commandStrings = Regex.Split(sqlQuery, @"^\s*GO\s*$",
                                                     RegexOptions.Multiline | RegexOptions.IgnoreCase);

                            //executando cada script separado por GO
                            foreach (string commandString in commandStrings)
                            {
                                try
                                {
                                    if (commandString.Trim() != string.Empty)
                                    {
                                        var command = new SqlCommand(commandString, null);
                                        command.Transaction = cnn.Transaction;
                                        var result = cnn.ExecuteNonQuery(command);
                                        commands.Add(command);
                                        if (result.IsCompleted) //se executou o arquivo DDL..
                                        {
                                            //taskLogger("Comando " + commandString + " executado com sucesso.");
                                            Console.WriteLine("Comando " + sqlFileName + " executado com sucesso.");
                                            Console.WriteLine("============================================================================");
                                            statusScripts.Add(commandString, true);
                                        }
                                    }
                                }
                                catch (SqlException sqlE)
                                {
                                    Console.WriteLine("Error: " + sqlE.Number + "Comando: \n" + commandString + " \nLine: " + sqlE.LineNumber + " Message:" + sqlE.Message);
                                    statusScripts.Add(commandString, false);
                                }
                            }//fim
                        }

                        //se a lista de scripts executados tiver mais de um item falso
                        if (statusScripts.Where(s => s.Value == false).Count() == 0)
                        {
                            cnn.Transaction.Commit();
                            ts.Complete();
                        }
                        else
                        {
                            cnn.Transaction.Rollback();
                        }
                    }
                    catch (TransactionAbortedException traCanc)
                    {
                        Console.WriteLine("Ocorreram erros no processo. Todas as alterações serao desfeitas.");
                        Console.WriteLine("Erro: " + traCanc.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocorreram erros no processo. Todas as alterações serao desfeitas.");
                        Console.WriteLine("Erro: " + ex.Message);
                    }
                }
            }
        }
        #endregion
    }
}
