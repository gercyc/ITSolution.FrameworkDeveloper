using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseClasses.RegisterServices;
using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.Mensagem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolutionFramework
{
    public partial class ITSolutionFrame : Form
    {
        TraceServerListener serverListener;
        public ITSolutionFrame()
        {
            InitializeComponent();
        }
        public ServiceTraceHandle TraceHandle;
        public delegate void ServiceTraceHandle(string _sessionID, TraceClass msg);
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                taskIcon.Text = "Iniciando serviços...";
                ThreadStart thServices = () =>
                {
                    RemoteService.RegisterService.StartFrameworkServices();
                    RemoteService.RegisterService.StartApplicationServices();
                };

                thServices.Invoke();

                gridControl1.DataSource = RemoteService.RegisterService.OnlineServers;
                taskIcon.Text = string.Format("Servidor iniciado, porta {0}", EnvironmentInformation.ServerPort);
                taskIcon.Icon = ITSolution.Framework.ServiceHost.Properties.Resources.server_go;
                Trace();
                this.Hide();
            }
            catch (ReflectionTypeLoadException loaderEx)
            {
                MessageBoxException.ShowException("Erro ao carregar assemblies.", loaderEx);
                Application.Exit();
            }
            catch (Exception ex)
            {

                MessageBoxException.ShowException("Erro não identificado", ex);
                Application.Exit();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //XFrmTaskCentral xFrmTaskCentral = new XFrmTaskCentral();
            //xFrmTaskCentral.Show();

        }
        private void WriteText(string _sessionID, TraceClass tracedata)
        {
            if (memoEdit1.InvokeRequired)
            {
                this.Invoke(new WriteMemo(WriteMemoEdit), new object[] { tracedata });

            }

        }
        public delegate void WriteMemo(TraceClass tracedata);
        private void WriteMemoEdit(TraceClass tracedata)
        {
            memoEdit1.Text += tracedata + "\r\n";
            memoEdit1.Update();
        }

        public void Trace()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Factory.StartNew(() =>
                    {
                        serverListener = TraceServerListener.Get<MemoryTraceListener>(Consts.InternalFrameworkSession);
                        var v = serverListener.Read();
                        foreach (var traceData in v)
                        {
                            //memoEdit1.Text += string.Format("{0}{1}", traceData.Message, "\n");
                            //memoEdit1.Update();
                            Console.WriteLine(traceData.Message);
                            if (TraceHandle == null)
                                TraceHandle += WriteText;

                            TraceHandle.Invoke(Consts.InternalFrameworkSession, traceData);
                        }

                    });
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            });

        }
    }
}
