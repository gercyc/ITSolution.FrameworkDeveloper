using BoletoNet;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ITSolution.Framework.Ticket
{
    public static class BoletoUtil
    {

        /// <summary>
        ///Monta e salva o html
        /// </summary>
        /// <param name="bb"></param>
        public static void ShowBoletoHtml(BoletoBancario bb)
        {
            
            var path = Path.Combine(FileManagerIts.DeskTopPath, "Boleto-" + bb.Banco.Nome + ".html");

            for (int i = 1; File.Exists(path); i++)
            {
                path = Path.Combine(FileManagerIts.DeskTopPath, "Boleto-" + bb.Banco.Nome + "_" + i + ".html");
            }

            bb.MontaHtmlNoArquivoLocal(path);
            //FileManagerIts.OverWriteOnFile(path, html);

            //if(File.Exists(path))
              //  FileManagerIts.OpenFromSystem(path);
        }
        /// <summary>
        /// Gera a imagem do boleto
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Bitmap CreateImage(string url)
        {
            //string address = webBrowser.Url.ToString();
            int width = 670;
            int height = 805;

            int webBrowserWidth = 670;
            int webBrowserHeight = 805;

            Bitmap bmp = GetWebSiteThumbnail(url, webBrowserWidth, webBrowserHeight, width, height);

            return bmp;
        }
        /// <summary>
        /// Gera a imagem do boleto e salva na raiz do programa com o nome boleto.jpeg
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GenerateImage(string url)
        {
            Bitmap bmp = CreateImage(url);
            //antes era bmp
            string file = Path.Combine(Environment.CurrentDirectory, "boleto.jpeg");
            bmp.Save(file);
            return file;
        }

        /// <summary>
        /// PDF nao fica muito bom
        /// </summary>
        /// <param name="bb"></param>
        public static void ShowBoletoPDF(BoletoBancario bb)
        {
            var bytes = bb.MontaBytesPDF();

            var path = Path.Combine(FileManagerIts.DeskTopPath, "Boleto-" + bb.Banco.Nome + ".pdf");


            for (int i = 1; File.Exists(path); i++)
            {
                path = Path.Combine(FileManagerIts.DeskTopPath, "Boleto-" + bb.Banco.Nome + "_" + i + ".pdf");
            }

            FileManagerIts.WriteBytesToFile(path, bytes);


            FileManagerIts.OpenFromSystem(path);
        }

        /// <summary>
        /// Gera o layout do(s) boleto(s)
        /// </summary>
        /// <param name="boletos"></param>Boletos a serem gerados
        /// <returns>O path do html gerado</returns>
        public static string GenerateTicketLayout(IEnumerable<BoletoBancario> boletos)
        {
            try
            {
                var html = new StringBuilder();
                foreach (var o in boletos)
                {
                    html.Append(o.MontaHtml());
                    html.Append("</br></br></br></br></br></br></br></br></br></br>");
                }

                string _arquivo = Path.GetTempFileName();

                using (var f = new FileStream(_arquivo, FileMode.Create))
                {

                    //O encoding mais simples que resolve seu problema é o Latin1(veja tabela).No lugar do ASCII usaria:
                    //Encoding.GetEncoding("ISO-8859-1")
                    //ou
                    //Encoding.GetEncoding(28591)
                    //Dependendo do seu caso pode ter que usar o 850 ou 860.
                    //Se não puder usá - lo, a solução é converter o texto tirando os acentos.
                    //Tem perda de informação, mas é a única solução que sobrou.
                    //antes
                    //var w = new StreamWriter(f, Encoding.Default);
                    var sw = new StreamWriter(f, Encoding.GetEncoding("ISO-8859-1"));

                    //gera o html
                    sw.Write(html.ToString());

                    //fecha o stream
                    sw.Close();

                    //fecha o arquivo
                    f.Close();
                }
                return _arquivo;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessageDetails(ex, "Ocorreu um erro ao gerar o layout do boleto.");
                throw ex;
            }

        }


        #region Geraçao da imagem do boleto - Github -> Fork

        public static Bitmap GetWebSiteThumbnail(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
        {
            WebsiteThumbnailImage thumbnailGenerator = new WebsiteThumbnailImage(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight);
            return thumbnailGenerator.GenerateWebSiteThumbnailImage();
        }

        private class WebsiteThumbnailImage
        {
            public WebsiteThumbnailImage(string Url, int BrowserWidth, int BrowserHeight, int ThumbnailWidth, int ThumbnailHeight)
            {
                this.m_Url = Url;
                this.m_BrowserWidth = BrowserWidth;
                this.m_BrowserHeight = BrowserHeight;
                this.m_ThumbnailHeight = ThumbnailHeight;
                this.m_ThumbnailWidth = ThumbnailWidth;
            }

            private string m_Url = null;
            public string Url
            {
                get
                {
                    return m_Url;
                }
                set
                {
                    m_Url = value;
                }
            }

            private Bitmap m_Bitmap = null;
            public Bitmap ThumbnailImage
            {
                get
                {
                    return m_Bitmap;
                }
            }

            private int m_ThumbnailWidth;
            public int ThumbnailWidth
            {
                get
                {
                    return m_ThumbnailWidth;
                }
                set
                {
                    m_ThumbnailWidth = value;
                }
            }

            private int m_ThumbnailHeight;
            public int ThumbnailHeight
            {
                get
                {
                    return m_ThumbnailHeight;
                }
                set
                {
                    m_ThumbnailHeight = value;
                }
            }

            private int m_BrowserWidth;
            public int BrowserWidth
            {
                get
                {
                    return m_BrowserWidth;
                }
                set
                {
                    m_BrowserWidth = value;
                }
            }

            private int m_BrowserHeight;
            public int BrowserHeight
            {
                get
                {
                    return m_BrowserHeight;
                }
                set
                {
                    m_BrowserHeight = value;
                }
            }

            public Bitmap GenerateWebSiteThumbnailImage()
            {
                Thread m_thread = new Thread(new ThreadStart(_GenerateWebSiteThumbnailImage));
                m_thread.SetApartmentState(ApartmentState.STA);
                m_thread.Start();
                m_thread.Join();
                return m_Bitmap;
            }

            private void _GenerateWebSiteThumbnailImage()
            {
                WebBrowser m_WebBrowser = new WebBrowser();
                m_WebBrowser.ScrollBarsEnabled = false;
                m_WebBrowser.Navigate(m_Url);
                m_WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
                while (m_WebBrowser.ReadyState != WebBrowserReadyState.Complete)
                    Application.DoEvents();
                m_WebBrowser.Dispose();
            }

            private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                WebBrowser m_WebBrowser = (WebBrowser)sender;
                m_WebBrowser.ClientSize = new Size(this.m_BrowserWidth, this.m_BrowserHeight);
                m_WebBrowser.ScrollBarsEnabled = false;
                m_Bitmap = new Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height);
                m_WebBrowser.BringToFront();
                m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds);
                m_Bitmap = (Bitmap)m_Bitmap.GetThumbnailImage(m_ThumbnailWidth, m_ThumbnailHeight, null, IntPtr.Zero);
            }
        }

        #endregion
    }
}
