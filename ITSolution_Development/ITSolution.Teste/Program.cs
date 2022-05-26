using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Beans.Forms;
using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ITSolution.Teste
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
            Application.Run(new RibbonForm1());

            //new XFrmPdfConvertToText().ShowDialog();

        }
    }
}
