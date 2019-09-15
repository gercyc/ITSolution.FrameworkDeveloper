using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.Core.BaseClasses;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ITSolution.Framework.Core.Host
{
    class Program
    {
        static IWebHostBuilder webHostBuilder;
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor...");
            //Console.WriteLine(AppConfigManager.Configuration.ConnectionString);
            //CreateHost(args);
            CreateWebHostBuilder(args);
            Console.WriteLine("Servidor Iniciado");
            Console.ReadLine();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string url = string.Format("http://*:{0}", EnvironmentInformation.ServerPort);
            webHostBuilder = WebHost.CreateDefaultBuilder(args).UseUrls(url).UseStartup<Startup>();
            webHostBuilder.Build().Start();
            return webHostBuilder;
        }
    }

}
