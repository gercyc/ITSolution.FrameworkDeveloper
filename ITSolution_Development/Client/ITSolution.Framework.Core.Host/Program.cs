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
            //CreateHost(args);
            CreateWebHostBuilder(args);
            Console.WriteLine("Servidor Iniciado");
            Console.ReadLine();
        }
        static void CreateHost(string[] args)
        {
            string contentRoot = @"C:\Users\gercy\source\repos\ITSolution.FrameworkDeveloper\ITSolution_Development\Servers\ITSolution.Framework.Servers.Core.FirstAPI\bin\Debug\netcoreapp2.1";
            string[] files = Directory.GetFiles(contentRoot, "*.dll");
            foreach (var file in files)
            {
                AssemblyName assemblyName = ITSAssemblyLoader.GetAssemblyName(file);
                Assembly asm = ITSAssemblyLoader.ITSLoader.Load(file);
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            webHostBuilder = WebHost.CreateDefaultBuilder(args).UseUrls("http://*:5000").UseStartup<Startup>();
            
            webHostBuilder.Start();
            return webHostBuilder;
        }
    }

}
