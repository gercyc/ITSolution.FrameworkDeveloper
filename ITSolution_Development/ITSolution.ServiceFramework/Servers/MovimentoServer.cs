using ITSolution.Framework.Mensagem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.ServiceFramework.Servers
{
    public class MovimentoServer : ServiceHost
    {
        //public MovimentoServer(Uri uri) : base(typeof(MovimentoDaoManager), uri)
        //{

        //}

        //public void Start()
        //{
        //    try
        //    {
        //        //add behavior
        //        //ativa o wsdl do servicos() exposto
        //        //customiza a execucao do servico, caracts. de exec do servico etc...
        //        //
        //        base.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

        //        //contratos visiveis para os clientes.. expondo os contratos disponiveis no endpoint abaixo
        //        //contrato, forma de binding (http), endereco.. tipo: lochst..:9090/
        //        //sHost.AddServiceEndpoint(typeof(IReportContract), new NetTcpBinding(), "svc1");
        //        base.AddServiceEndpoint(typeof(IMovimentoDaoManager), new BasicHttpBinding(), "MovimentoService");

        //        //expondo o WSDL do contrato a partir de um ponto http.. esta acessivel em lochst..:9090/
        //        base.AddServiceEndpoint(typeof(IMovimentoDaoManager), MetadataExchangeBindings.CreateMexHttpBinding(), "MovimentoServiceWSDL");

        //        //abrindo o host.. deixando o servico pronto para receber requests..
        //        base.Open();

        //    }
        //    catch (Exception ex)
        //    {
        //        XMessageIts.ExceptionMessage(ex);
        //    }
        //}
    }
}
