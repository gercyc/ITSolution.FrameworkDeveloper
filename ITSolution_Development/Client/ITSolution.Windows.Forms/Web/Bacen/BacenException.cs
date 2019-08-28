using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Text;

namespace ITSolution.Framework.Web.Bacen
{
    public abstract class BacenException : Exception
    {
        protected string message;
        public string Title { get; protected set; }

        public string Error { get; protected set; }
        public override string Message
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append(this.message);
                sb.Append("\n");
                sb.Append("======================================================================================\n");
                if (this.Error != null)
                {
                    sb.Append("Erro: ");
                }
                sb.Append(this.Error);
                return sb.ToString();
            }
        }
        public BacenException(Exception ex, string message) : base(ex.Message)
        {
            this.Error = ex != null? ex.Message : null;
            this.message = message;
            this.Title = "Falha na conexão com o servidor bacen";

        }

        protected void generateLog()
        {
            LoggerUtilIts.GenerateLogs(this, this.Message);

        }

        public void ShowExceptionMessage()
        {
            XMessageIts.Erro(this.Message, this.Title);
        }
    }
}
