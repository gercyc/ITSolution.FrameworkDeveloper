using ITSolution.Framework.BaseClasses;
using ITSolution.ServiceFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolution.ServiceFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Console.WriteLine(EnvironmentInformation.ServerPort);

                //Application.Run(new ItsServiceframe());

                //ServiceBase[] ServicesToRun;
                //ServicesToRun = new ServiceBase[]
                //{
                //new ItsFrameService()
                //};
                //ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
