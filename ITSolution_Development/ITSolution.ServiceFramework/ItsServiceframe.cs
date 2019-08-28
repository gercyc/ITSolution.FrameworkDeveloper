using ITSolution.Reports.Util;
using ITSolution.ServiceFramework.Servers;
using ITSolution.ServiceFramework.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.ServiceFramework
{
    public partial class ItsServiceframe : Form
    {
        private Uri[] uris;

        public ItsServiceframe()
        {
            InitializeComponent();
            this.uris = new Uri[] { new Uri("net.tcp://localhost:9091"), new Uri("http://localhost:9090") };

        }

        private void btnStartSvc1_Click(object sender, EventArgs e)
        {
            var rptServer = new ReportServer(new Uri("http://localhost:9090/reports"));
            rptServer.Start();
            btnStartReports.Text = rptServer.State.ToString();

        }

        private void btnStarScheduler_Click(object sender, EventArgs e)
        {

            //var jobServer = new JobServer(new Uri("http://localhost:9090/scheduler"));
            //jobServer.Start();
            //btnStarScheduler.Text = jobServer.State.ToString();
        }
        private void createHost()
        {
            //implementacao do host wcf.
            //configuracoes do servico, endpoints etc..
            Uri uri = new Uri("http://localhost:9090/");
            ServiceHost sHost = new ServiceHost(typeof(ReportContract),
                new Uri[] { new Uri("net.tcp://localhost:9091"), new Uri("http://localhost:9090") });

            //add behavior
            //ativa o wsdl do servicos() exposto
            //customiza a execucao do servico, caracts. de exec do servico etc...
            //
            sHost.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

            //contratos visiveis para os clientes.. expondo os contratos disponiveis no endpoint abaixo
            //contrato, forma de binding (http), endereco.. tipo: lochst..:9090/
            //sHost.AddServiceEndpoint(typeof(IReportContract), new NetTcpBinding(), "svc1");

            sHost.AddServiceEndpoint(typeof(IReportContract), new BasicHttpBinding(), "ReportService");
            //expondo o WSDL do contrato a partir de um ponto http.. esta acessivel em lochst..:9090/
            sHost.AddServiceEndpoint(typeof(IReportContract), MetadataExchangeBindings.CreateMexHttpBinding(), "ReportServiceWSDL");

            //abrindo o host.. deixando o servico pronto para receber requests..
            sHost.Open();
            Console.WriteLine(sHost.State);
            //Thread.Sleep(600000);
            //btnStartSvc1.Text = "Servico iniciado.";
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            //var movServer = new MovimentoServer(new Uri("http://localhost:9090/movimento"));
            //movServer.Start();
            //buttonEdit1.Text = movServer.State.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //RegisterServices registerServices = new RegisterServices();
            //registerServices.StartFrameworkServices(9000);
            //registerServices.StartServices(9000);
            //var Url = "http://localhost:9000/TesteController";
            
            //var t = registerServices.OpenConnection<ITeste>(Url);
            //var soma = t.SomaInt(1, 1).ToString();
            //MessageBox.Show(soma);
        }
    }
}
