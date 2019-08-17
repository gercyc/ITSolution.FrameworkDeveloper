using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using System;
using System.Diagnostics;
using System.IO;

namespace ITSolution.Framework.Util
{
    public class LoggerUtilIts
    {
        /// <summary>
        /// Log na saida padrão da mensagem contida na exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowExceptionMessage(Exception ex)
        {
            //Uso o método Write para escrever o arquivo que será adicionado no arquivo texto
            string msg = "Mensagem: " + ex.Message;
            Console.WriteLine(@"Log ITSolution: => " + msg);
        }

        /// <summary>
        /// Log na saida padrão completo da exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowExceptionLogs(Exception ex)
        {
            var inner = ex.InnerException == null
                          ? "Nenhuma exceção interna"
                          : ex.InnerException.Message + "";
            //Uso o método Write para escrever o arquivo que será adicionado no arquivo texto
            string msg = "Mensagem: " + ex.Message + "\n" +
                "Pilha de erros: " + ex.StackTrace + "\n" +
            "Exceção interna: " + inner;

            Console.WriteLine("Log ITSolution: => \t" + msg);
        }

        /// <summary>
        /// Log na saida padrão completo da exceção e o do tipo do objeto informado
        /// </summary>
        public static void ShowExceptionLogs(Exception ex, object o)
        {
            Console.WriteLine();

            //Uso o método Write para escrever o arquivo que será adicionado no arquivo texto
            string msg =
                "\nClasse:" + o.GetType() + "\n" +
                "\nMensagem: " + ex.Message + "\n" +
                "Pilha de erros: " + ex.StackTrace + "\n" +
            "Exceção interna: " + ex.InnerException + "\n";

            Console.WriteLine(@"Log ITSolution: => " + msg);
        }

        /// <summary>
        /// Log no arquivo de log
        /// </summary>
        /// <param name="ex"></param>
        public static void GenerateLogs(Exception ex)
        {
            var logs = "C:\\logs\\its\\excecoes";
            var fileName = logs + "\\" + ex.GetType() + "-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".txt";
            FileManagerIts.CreateDirectory(logs);

            //esreve ou concatena o log
            FileManagerIts.AppendTextFileException(fileName, ex);

            //escrever no eventviewer.. gercy campos, em 30/06/2017
            WriteOnEventViewer(ex, "Exceção lançãda!\nContate o administrador.");
        }

        /// <summary>
        /// Log no arquivo de log
        /// </summary>
        /// <param name="ex"></param>
        public static void GenerateLogs(Exception ex, params string[] msg)
        {
            var logs = "C:\\logs\\its\\excecoes";
            var fileName = logs + "\\" + ex.GetType() + "-" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            FileManagerIts.CreateDirectory(logs);
            File.Delete(fileName);
            FileManagerIts.AppendTextFileException(fileName, ex, msg); ;
            WriteOnEventViewer(ex, msg);
        }

        private static void WriteOnEventViewer(Exception ex, params string[] msg)
        {
            var logs = "C:\\logs\\its\\excecoes";
            string sSource = "ITSolution.Framework";

            var inner = ex.InnerException == null
                           ? "Nenhuma exceção interna"
                           : ex.InnerException.Message + "";

            var msgLog = "\nMensagem: " + ex.Message + "\n" +
                            "Classe: " + ex.GetType() + "\n" +
                            "Exceção interna: " + inner + "\n" +
                            "=>: " + inner + "\n" +
                            "Pilha de erros: " + ex.StackTrace + "\n";


            try
            {
                if (!EventLog.SourceExists(sSource))
                {
                    EventLog.CreateEventSource(sSource, "ITE.Forms");
                }


                EventLog MyEventLog = new EventLog(); MyEventLog.Source = sSource;
                // Id do Evento
                int eventID = 3300;
                // Categoria do Evento
                short categoriaID = 16;
                // Tipo do Erro
                EventLogEntryType typeEntry = EventLogEntryType.Error;
                MyEventLog.WriteEntry(msgLog, typeEntry, eventID,
                    categoriaID);
            }
            catch (Exception e)
            {
                FileManagerIts.AppendTextFileException(logs + @"\\eventViewLogFail.txt", e, msg); ;
            }
        }

        public static void WriteOnEventViewer(string message, params string[] msg)
        {
            var logs = "C:\\logs\\its\\excecoes";
            string sSource = "ITSolution.Framework";

            try
            {
                if (!EventLog.SourceExists(sSource))
                {
                    EventLog.CreateEventSource(sSource, "ITE.Forms");
                }

                EventLog MyEventLog = new EventLog(); MyEventLog.Source = sSource;
                // Id do Evento
                int eventID = 3300;
                // Categoria do Evento
                short categoriaID = 16;
                // Tipo do Erro
                EventLogEntryType typeEntry = EventLogEntryType.Information;
                MyEventLog.WriteEntry(message, typeEntry, eventID,
                    categoriaID);
            }
            catch (Exception e)
            {
                FileManagerIts.AppendTextFileException(logs + @"\\eventViewLogFail.txt", e, msg); ;
            }
        }

        public static string GetInnerException(Exception ex)
        {
            var inner = ex.InnerException == null
                    ? "Nenhuma exceção interna"
                    : ex.InnerException.Message + "";

            string msg = ex.Message  + ". Exceção : " + inner;

            return msg;
        }
        public static string GetLogException(Exception ex)
        {
            return "\nMensagem: " + ex.Message + "\n" +
                           "Classe: " + ex.GetType() + "\n" +
                           "Exceção interna: " + GetInnerException(ex) + "\n" +
                           "Pilha de erros: " + ex.StackTrace + "\n";
        }
    }
}
