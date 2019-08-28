using ITSolution.Framework.Arquivos;
using System;
using System.Windows.Forms;

namespace ITSolution.Framework.Mensagem
{

    /// <summary>
    /// Mensagem prontas usando System.Windows.Forms
    /// </summary>
    public class XMessageIts
    {
        private static string TITLE = "Mensagem";

        public XMessageIts()
        {

        }

        /// <summary>
        /// Exibe uma Mensagem
        /// </summary>
        /// <param colName="message"></param>
        public static void Mensagem(object message)
        {
            if (message == null)
            {
                message = "null";
            }

            // igual ao information MessageBoxIcon.Asterisk
            MessageBox.Show(message.ToString(), TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Mensagem(object message, string title)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="icone"></param>
        public static void Mensagem(object message, MessageBoxIcon icone)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), TITLE, MessageBoxButtons.OK, icone);
        }

        /// <summary>
        /// Exibe uma Mensagem, título e um ícone
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icone"></param>
        public static void Mensagem(object message, string title, MessageBoxIcon icone)
        {
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, icone);
        }

        /// <summary>
        /// Exibe uma Mensagem com ok
        /// </summary>
        /// <param name="message"></param>
        public static void Advertencia(object message)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Exclamation);
            MessageBox.Show(message.ToString(), TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void Advertencia(object message, string title)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Exclamation);
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título de confirmação de ação
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>Yes ou No
        public static DialogResult Confirmacao(object message)
        {
            if (message == null)
            {
                message = "";
            }
            DialogResult result = MessageBox.Show(message.ToString(), TITLE,
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }

        /// <summary>
        /// Exibe uma Mensagem e um título de confirmação de ação
        /// Retorna YES ou NO
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>Yes ou No
        public static DialogResult Confirmacao(object message, string title)
        {
            if (message == null)
            {
                message = "";
            }
            DialogResult result =
                 MessageBox.Show(message.ToString(), title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param name="message"></param>
        public static void Erro(object message)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Hand
            //          MessageBoxIcon.Stop
            MessageBox.Show(message.ToString(), TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void Erro(object message, string title)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Hand
            //          MessageBoxIcon.Stop
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void None(object message, string title)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void ExceptionMessage(Exception ex)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro recebeu uma exceção não identificada");
            }
            MessageBox.Show(ex.Message +
                "\nPilha de erros:\n " + ex.StackTrace
                + "\nExceção Interna:\n" + ex.InnerException,
                TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void ExceptionJustMessage(Exception ex, string message = null, string title = null)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro recebeu uma exceção não identificada");
            }
            if (title == null)
                title = TITLE;

            var inner = ex.InnerException == null
                          ? "Nenhuma exceção interna"
                          : ex.InnerException.Message + "";

            string msg = ex.Message + "\n" + inner;

            if (message == null)
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message + " " + msg + "\n", title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ExceptionMessage(Exception ex, string message, string title)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro recebeu uma exceção não identificada");
            }
            MessageBox.Show(message + "\n\n" + ex.Message + "\nPilha de erros::\n " + ex.StackTrace,
                title, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// Exibe somente a mensagem que a exceção lançou e gera log da execeção.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ExceptionMessageDetails(Exception ex, string message, string title = null)
        {
            if (ex == null)
                ex = new Exception();
            var split = (ex.Message + "").Split('.');
            var newMsg = "";
            foreach (var item in split)
            {
                newMsg += item + "\n";
            }

            string msg = string.Format("{0}\n{1}\n{2}", message, newMsg, "Verifique o arquivo de logs na pasta its");
            var logs = "C:\\logs\\its\\excecoes";

            FileManagerIts.CreateDirectory(logs);
            FileManagerIts.AppendTextFileException(logs + "\\" + ex.GetType()
                + "-" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt", ex);
            //refazer no WinForms nativo
            MessageBox.Show(message);

        }


    }
}
