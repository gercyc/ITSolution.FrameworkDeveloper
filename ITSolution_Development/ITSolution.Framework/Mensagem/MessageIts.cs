using System;
using System.Windows.Forms;

namespace ITSolution.Framework.Mensagem
{

    /// <summary>
    /// Mensagem prontas usando System.Windows.Forms
    /// </summary>
    public class MessageIts
    {
        private static String TITULO = "Mensagem";

        public MessageIts()
        {

        }

        /// <summary>
        /// Exibe uma Mensagem
        /// </summary>
        /// <param colName="message"></param>
        public static void Mensagem(Object message)
        {
            if (message == null)
            {
                message = "null";
            }
            // igual ao information MessageBoxIcon.Asterisk
            MessageBox.Show(message.ToString(), TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Mensagem(Object message, String titulo)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="icone"></param>
        public static void Mensagem(Object message, MessageBoxIcon icone)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), TITULO, MessageBoxButtons.OK, icone);
        }

        /// <summary>
        /// Exibe uma Mensagem, título e um ícone
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        /// <param colName="icone"></param>
        public static void Mensagem(Object message, String titulo, MessageBoxIcon icone)
        {
            MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.OK, icone);
        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Advertencia(Object message)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Exclamation);
            MessageBox.Show(message.ToString(), TITULO, MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);//Exclamation sao os mesmos

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Advertencia(Object message, String titulo)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Exclamation);
            MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título de confirmação de ação
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static DialogResult Confirmacao(Object message)
        {
            if (message == null)
            {
                message = "";
            }
            DialogResult result =
                MessageBox.Show(message.ToString(), TITULO, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }
        
        /// <summary>
        /// Exibe uma Mensagem e um título de confirmação de ação
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static DialogResult Confirmacao(Object message, String titulo)
        {
            if (message == null)
            {
                message = "";
            }
            DialogResult result =
                MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }
        
        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Erro(Object message)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Hand
            //          MessageBoxIcon.Stop
            MessageBox.Show(message.ToString(), TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void Erro(Object message, String titulo)
        {
            if (message == null)
            {
                message = "null";
            }
            //sao iguais MessageBoxIcon.Hand
            //          MessageBoxIcon.Stop
            MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Exibe uma Mensagem e um título
        /// </summary>
        /// <param colName="message"></param>
        /// <param colName="titulo"></param>
        public static void None(Object message, String titulo)
        {
            if (message == null)
            {
                message = "null";
            }
            MessageBox.Show(message.ToString(), titulo, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void MensagemExcecao(Exception ex)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro nao recebeu a exceção\nFalha nao identificada");
                return;
            }
            MessageBox.Show(ex.Message + "\nPilha de erros:\n " + ex.StackTrace
                + "\n" + ex.InnerException, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void MensagemExcecao(Exception ex, String message)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro nao recebeu a exceção\nFalha nao identificada");
                return;
            }
            MessageBox.Show("Mensagem: " + message + "\n" + ex.Message + 
                "\nPilha de erros: " + ex.StackTrace
                + "\nExceção interna: " + ex.InnerException, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Gera uma mensagem com base nos dados na exceção
        /// </summary>
        /// <param name="ex"></param>
        public static void MensagemExcecao(Exception ex, String message, String titulo)
        {
            if (ex == null)
            {
                ex = new Exception("Mensageiro nao recebeu a exceção\nFalha nao identificada");
                return;
            }
            MessageBox.Show("Mensagem: " + message + "\n" + ex.Message +
                    "\nPilha de erros: " + ex.StackTrace
                    + "\nExceção interna: " + ex.InnerException, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       


    }
}
