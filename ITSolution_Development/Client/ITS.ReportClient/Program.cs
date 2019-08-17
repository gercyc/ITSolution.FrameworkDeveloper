
using System.Globalization;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System;
using ITSolution.Framework.Common.BaseClasses.Reports.Enumeradores;

namespace ITSolution.Framework.Client.Reports
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetTheme();
            new XFrmReportList(TypeGroupUser.Administrador).ShowDialog();

            //TaskUpdateManager.UpdateDllsFromDisk();
            //InfoPC();

            //name computer
            //var m = Environment.MachineName;
            //name computer

        }


        static void SetTheme()
        {
            // The following line provides localization for the application's user interface. 
            //Thread.CurrentThread.CurrentUICulture =
            //    new CultureInfo("pt -BR");

            //// The following line provides localization for data formats. 
            //Thread.CurrentThread.CurrentCulture =
            //    new CultureInfo("pt-BR");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Visual Studio 2013 Blue";
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2013 Light Gray";

        }


        /*new XFrmXmlCompare(@"D:\Program Files\TFS\ITSolution\ITSolution.Admin\Config\App.xml",
@"D:\Program Files\TFS\ITSolution\ITSolution.Admin\Config\App.xml").ShowDialog();*/


    }
}
