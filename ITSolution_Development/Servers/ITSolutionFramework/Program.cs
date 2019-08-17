using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.BaseClasses.Trace;
using ITSolution.Framework.Common.BaseClasses;
using ITSolution.Framework.Mensagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSolutionFramework
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
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);
            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(CurrentDomain_AssemblyLoad);
            AppDomain.CurrentDomain.TypeResolve += new ResolveEventHandler( CurrentDomain_TypeResolve);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //Application.Run(new ITSolutionFrame());
            TraceClass traceClass = new TraceClass();
            var app = new ITSolutionFrame();
            //traceClass.ClientListener = app;
            PipeHost<TraceClass> _pipe = new PipeHost<TraceClass>("Trace", traceClass);
            _pipe.StartListen();
            Application.Run(app);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            XMessageIts.ExceptionMessage((Exception)e.ExceptionObject);
        }

        private static System.Reflection.Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.Load(args.Name);
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private static System.Reflection.Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
