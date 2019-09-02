using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ITSolution.Framework.Core.Host
{
    public class Startup
    {
        string _assemblyPath = @"C:\Users\gercy\source\repos\ITSolution.FrameworkDeveloper\ITSolution_Development\Servers\ITSolution.Framework.Servers.Core.FirstAPI\bin\Debug\netcoreapp2.1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions()
            IMvcBuilder mvcBuilder = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string[] files = Directory.GetFiles(_assemblyPath, "*.dll");
            foreach (var file in files)
            {
                Assembly asm = ITSAssemblyLoader.ITSLoader.Load(file);
                mvcBuilder.AddApplicationPart(asm);
            }
            
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
