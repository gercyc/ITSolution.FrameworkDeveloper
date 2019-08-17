using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

//Ver dps
//http://stackoverflow.com/questions/4334521/c-sharp-webrequest-authentication
//Add uma DLL externa Html Agility
namespace ITSolution.Framework.Web
{
    public class HtmlUtil
    {
        /// <summary>
        /// Cria um documento html a partir dos dados das tags do html
        /// </summary>
        /// <param name="htmlSource"></param>
        /// <returns></returns>
        public static HtmlDocument CreateHtmlDocument(string htmlSource)
        {
            using (var webControl = new WebBrowser())
            {
                //supre qualquer erro de script js etc
                webControl.ScriptErrorsSuppressed = true;

                webControl.DocumentText = htmlSource;

                while (webControl.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                return webControl.Document;
            }
        }

        /// <summary>
        /// Captura e gera um documento html a partir do url
        /// </summary>
        /// <param name="url"></param>Url
        /// <returns></returns>Documento html
        public static HtmlDocument GetHtmlDocument(String url)
        {
            try
            {

                String htmlSource = "";
                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                htmlSource = reader.ReadToEnd();

                reader.Close();
                //response.Close();

                return CreateHtmlDocument(htmlSource);

            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                return CreateHtmlDocument("<html> </html>");

            }
        }

        /// <summary>
        /// Captura e gera um documento html a partir do url
        /// </summary>
        /// <param name="url"></param>Url
        /// <returns></returns>Documento html
        public async static Task<String> GetHtmlSource(String url)
        {

            String htmlSource = "";

            try {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                htmlSource = await reader.ReadToEndAsync();

                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Falha gerar html.");
            }
            return htmlSource;

        }

    }
}
