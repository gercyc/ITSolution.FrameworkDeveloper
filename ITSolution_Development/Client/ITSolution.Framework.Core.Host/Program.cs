using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyModel;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ITSolution.Framework.Core.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor...");
            CreateHost(args);
            Console.WriteLine("Servidor Iniciado");
            Console.ReadLine();
        }
        static void CreateHost(string[] args)
        {
            string[] files = Directory.GetFiles(
//AppContext.BaseDirectory, 
@"C:\Users\gercy\Source\Repos\ITSolution.FrameworkDeveloper\ITSolution_Development\Web\ITSolution.Framework.Web.BusinessAPI\bin\Debug\netcoreapp2.1",
"*.dll");

            foreach (var file in files)
            {
                AssemblyName assemblyName = AssemblyLoadContext.GetAssemblyName(file);
                var dps = DependencyContext.Default;
                
                Assembly assembly = Assembly.Load(assemblyName);

                IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args).UseStartup<StartupBase>();
                webHostBuilder.Build().Start();
            }


        }
    }
  
}
