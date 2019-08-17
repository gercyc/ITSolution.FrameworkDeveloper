using System;
using System.Text;
using System.IO;
using System.Net;

namespace ITSolution.Framework.Web.Bacen
{
    partial class XFrmCvsTeste : DevExpress.XtraEditors.XtraForm
    {
        private static readonly CookieContainer _cookies = new CookieContainer();
        private static string urlBaseBacen = @"https://ptax.bcb.gov.br/ptax_internet/consultaBoletim.do?method=gerarCSVFechamentoMoedaNoPeriodo&ChkMoeda=61";
       // private string paginaHTML;

        public XFrmCvsTeste()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;

            this.webBrowser1.Navigate(urlBaseBacen);

        }
        //Preciso invocar o methodo POST do html
        // retorna true se conseguiu efetuar a consulta 
        // os dados da consulta vão ser armazenados na variavel paginaHTML
        public bool POST()
        {
            bool isPost = true;
            var request = (HttpWebRequest)WebRequest.Create(urlBaseBacen);
            request.ProtocolVersion = HttpVersion.Version10;
            request.CookieContainer = _cookies;
            request.Method = "POST";

            string postData = "";
            postData = postData + "origem=comprovante&";
            //postData = postData + "cnpj=" + new Regex(@"[^\d]").Replace(aCNPJ, string.Empty) + "&";
            //postData = postData + "txtTexto_captcha_serpro_gov_br=" + aCaptcha + "&";
            postData = postData + "submit1=Consultar&";
            postData = postData + "search_type=cnpj";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            String retorno = "";
            try
            {
                Stream dataStream = request.GetRequestStream(); // PODE OCORRER ERRO AO TENTAR CONECTAR
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse(); // COLOCADO DENTRO DE TRY CATCH - SE O SERVIÇO FICAR FORA DO AR, DA ERRO NESSA LINHA
                StreamReader stHtml = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
                retorno = stHtml.ReadToEnd();
            }
            catch (Exception)
            {
                isPost = false;
            }

            return isPost;
        } 


        private void getCotacaoFromCVS()
        {
            DateTime dtInicio = dateEdit1.DateTime;
            DateTime dtFim = dateEdit2.DateTime;
            string preUrl = @"https://ptax.bcb.gov.br/ptax_internet/consultaBoletim.do?method=gerarCSVFechamentoMoedaNoPeriodo&ChkMoeda=61";
            var url = new StringBuilder();
            url.Append(preUrl);
            url.Append("&DATAINI=");
            url.Append(dtInicio.ToShortDateString());
            url.Append("&DATAFIM=");
            url.Append(dtFim.ToShortDateString());


            this.webBrowser1.Navigate(url.ToString());



           /* try
            {
                Stream st1 = this.webBrowser1.DocumentStream;//esse stream eh null
                
                Stream st2 = File.Open(@"D:\Desktop\" + Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".cvs", 
                    FileMode.CreateNew);
                BinaryReader f1 = new BinaryReader(st1);
                BinaryWriter f2 = new BinaryWriter(st2);

                while (true)
                {
                    byte[] buf = new byte[10240];
                    int sz = f1.Read(buf, 0, 10240);
                    if (sz <= 0)
                        break;
                    f2.Write(buf, 0, sz);
                    if (sz < 10240)
                        break; // fim de arquivo
                }
                f1.Close();
                f2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao copiar a o arquivo ...: " + ex.Message, "Erro", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }*/



        }

        private void btnGerarCvs_Click(object sender, EventArgs e)
        {
            getCotacaoFromCVS();
        }
    }
}