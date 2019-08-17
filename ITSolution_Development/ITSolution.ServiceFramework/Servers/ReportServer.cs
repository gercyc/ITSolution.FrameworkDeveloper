using ITSolution.Framework.Mensagem;
using ITSolution.Reports.Util;
using ITSolution.ServiceFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.ServiceFramework.Servers
{
    class ReportServer : ServiceHost
    {
        public ReportServer(Uri uri) : base(typeof(ReportContract), uri)
        {
            
        }

        public void Start()
        {
            try
            {
                //add behavior
                //ativa o wsdl do servicos() exposto
                //customiza a execucao do servico, caracts. de exec do servico etc...
                //
                base.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

                //contratos visiveis para os clientes.. expondo os contratos disponiveis no endpoint abaixo
                //contrato, forma de binding (http), endereco.. tipo: lochst..:9090/
                //sHost.AddServiceEndpoint(typeof(IReportContract), new NetTcpBinding(), "svc1");
                base.AddServiceEndpoint(typeof(IReportContract), new BasicHttpBinding(), "ReportService");

                //expondo o WSDL do contrato a partir de um ponto http.. esta acessivel em lochst..:9090/
                base.AddServiceEndpoint(typeof(IReportContract), MetadataExchangeBindings.CreateMexHttpBinding(), "ReportServiceWSDL");

                //abrindo o host.. deixando o servico pronto para receber requests..
                base.Open();

            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
            }
        }
    }
}

//Implementacao original
////implementacao do host wcf.
////configuracoes do servico, endpoints etc..
//Uri uri = new Uri("http://localhost:9090/");
//ServiceHost sHost = new ServiceHost(typeof(ReportContract),
//    new Uri[] { new Uri("net.tcp://localhost:9091"), new Uri("http://localhost:9090") });

////add behavior
////ativa o wsdl do servicos() exposto
////customiza a execucao do servico, caracts. de exec do servico etc...
////
//sHost.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

////contratos visiveis para os clientes.. expondo os contratos disponiveis no endpoint abaixo
////contrato, forma de binding (http), endereco.. tipo: lochst..:9090/
////sHost.AddServiceEndpoint(typeof(IReportContract), new NetTcpBinding(), "svc1");
//sHost.AddServiceEndpoint(typeof(IReportContract), new BasicHttpBinding(), "ReportService");

////expondo o WSDL do contrato a partir de um ponto http.. esta acessivel em lochst..:9090/
//sHost.AddServiceEndpoint(typeof(IReportContract), MetadataExchangeBindings.CreateMexHttpBinding(), "ReportServiceWSDL");

////abrindo o host.. deixando o servico pronto para receber requests..
//sHost.Open();
//Console.WriteLine(sHost.State);
////Thread.Sleep(600000);
//btnStartSvc1.Text = "Servico iniciado.";