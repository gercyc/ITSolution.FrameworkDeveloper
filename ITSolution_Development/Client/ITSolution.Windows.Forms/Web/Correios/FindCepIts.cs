using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Threading.Tasks;

namespace ITSolution.Framework.Web.Correios
{
    /// <summary>
    /// Classe responsavél por encontrar informações sobre um CEP via correios
    /// Essa classe utiliza o webservices dos correios
    /// referencia:http://brunoferreirainfo.com.br/2016/01/20/como-consultar-cep-com-c-windows-forms-e-ws-correios/#.WAuWayRRLxx
    /// Webserivce:https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl
    /// </summary>
    public class FindCepIts
    {

        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Complemento2 { get; set; }
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

        public FindCepIts()
        {

        }


        /// <summary>
        /// Encontra a Cidade, Estado, Endereco, Complemento, Bairro e CEP
        /// </summary>
        /// <param name="cep"></param>Cep 
        /// <returns></returns>true se o cep foi localizado caso contrário false
        public async Task<bool> FindAdress(string cep)
        {
            return await Task.Run(() => findAdress(cep));
        }

        /// <summary>
        /// Localiza os dados no ws dos correios
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        private bool findAdress(string cep)
        {
            if (String.IsNullOrEmpty(cep))
                return false;
            try
            {

                WSCorreiosCep.AtendeClienteClient ws = new WSCorreiosCep
                    .AtendeClienteClient("AtendeClientePort");

                var r = ws.consultaCEP(cep);

                this.Endereco = r.end;
                this.Bairro = r.bairro;
                this.Complemento = r.complemento;
                this.Complemento2 = r.complemento2;
                this.Cep = r.cep;
                this.Cidade =  r.cidade;
                this.UF = r.uf;

                if (!r.cep.Equals(this.Cep)){
                    XMessageIts.Advertencia("Notificamos que o seu CEP mudou!\n\n"+
                        "Confira novamente seu CEP.", "Atenção ! ! !");
                }

                return true;
            }
            catch (Exception ex)
            {
                LoggerUtilIts.GenerateLogs(ex);

                LoggerUtilIts.ShowExceptionLogs(ex);
                return false;
            }

        }

        /*Metodo procedural com muitas falhas          
        /// <summary>
        /// Encontra a Cidade, Estado, Endereco, Bairro e CEP pelo Cep usando o site dos correios
        /// </summary>
        /// <param name="cep"></param>Cep 
        /// <returns></returns>true se encontrou pelo menos a cidade e estado caso contrário false
        public async Task<bool> FindAdress(string cep)
        {
            if (String.IsNullOrWhiteSpace(cep)) return false;
            try {
                //teste => string cep = "30140-070";
                string url = "http://www.buscacep.correios.com.br/servicos/dnec/consultaLogradouroAction.do?Metodo=listaLogradouro&CEP=" + cep + "&TipoConsulta=cep";

                //https://social.msdn.microsoft.com/Forums/pt-BR/5cc4d182-2cb9-4fd1-9690-a3f24e831f40/pegar-contedo-de-uma-tag-html?forum=vscsharppt

                //Exemplo de filtro
                String websiteCorreios = await HtmlUtil.GetHtmlSource(url);

                findBairroCidade(websiteCorreios);
                findLogradouro(websiteCorreios);
                findEstado(websiteCorreios);
                findCepConfirmation(websiteCorreios);


                return (Cidade != null && UF != null);
            }
            catch
            {
                return false;
            }
            //acha tudo com a tag 
            //MatchCollection matches = Regex.Matches(websiteCorreios, @"<tr.*?>(.*?)</tr>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }

        private void findCepConfirmation(String webSiteCorreios)
        {
            //<td width="65" style="padding: 2px">30140-070</td>

            MatchCollection matchesCep = Regex.Matches(webSiteCorreios, "<td width=\"65\" style=\"padding: 2px\">(.*)</td>");
            foreach (Match match in matchesCep)
            {
                foreach (Group td in match.Groups)
                {
                    var value = td.Value;
                    if (value.Contains("<td width=\"65\" style=\"padding: 2px\">")) continue;

                    Cep = td.Value;// Console.WriteLine("Cep:" + td.Value);
                }
            }
        }

        private void findEstado(String webSiteCorreios)
        {
            //<td width="25" style="padding: 2px">MG</td>

            MatchCollection matchesUF = Regex.Matches(webSiteCorreios, "<td width=\"25\" style=\"padding: 2px\">(.*)</td>");
            foreach (Match match in matchesUF)
            {
                foreach (Group td in match.Groups)
                {
                    var value = td.Value;
                    if (value.Contains("<td width=\"25\" style=\"padding: 2px\">")) continue;

                    UF = td.Value; //Console.WriteLine("UF:" + td.Value);
                }
            }
        }

        private void findLogradouro(String webSiteCorreios)
        {

            MatchCollection matchesLogradouro = Regex.Matches(webSiteCorreios, "<td width=\"268\" style=\"padding: 2px\">(.*)</td>");
            foreach (Match match in matchesLogradouro)
            {
                foreach (Group td in match.Groups)
                {
                    var value = td.Value;
                    if (value.Contains("<td width=\"268\" style=\"padding: 2px\">")) continue;

                    Logradouro = td.Value; //Console.WriteLine("Endereço:" + td.Value);

                }
            }
        }

        private void findBairroCidade(String webSiteCorreios)
        {

            MatchCollection matchesBairoCidade = Regex.Matches(webSiteCorreios,
                            "<td width=\"140\" style=\"padding: 2px\">(.*)</td>");
            int i = 0;

            foreach (Match match in matchesBairoCidade)
            {
                foreach (Group td in match.Groups)
                {
                    var value = td.Value;
                    if (value.Contains("<td width=\"140\" style=\"padding: 2px\">"))
                    {
                        
                        continue;
                    }
                    i++;

                    Console.WriteLine(i);

                    if (i == 1)
                    {
                        Bairro = td.Value; 
                        Console.WriteLine("Bairro:" + td.Value);
                    }
                    if (i == 2)
                    {
                        Cidade = td.Value;
                        Console.WriteLine("Cidade:" + td.Value);
                    }
                }
            }
            //So achou a cidade
            if (i == 1)
            {
                Cidade = Bairro;
                Bairro = null;
            }
        }
*/

    }
}
