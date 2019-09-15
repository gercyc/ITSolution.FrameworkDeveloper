using ITSolution.Framework.BaseClasses;
using ITSolution.Framework.Core.BaseClasses;
using ITSolution.Framework.Server.Core.BaseClasses.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ITSolution.Framework.Core.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //assinando o evento para definir quem vai resolver os assemblies
            AssemblyLoadContext.Default.Resolving += Default_Resolving;
        }

        private Assembly Default_Resolving(AssemblyLoadContext arg1, AssemblyName arg2)
        {
            return ITSAssemblyResolve.ITSLoader.LoadFromAssemblyName(arg2);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions()
            IMvcBuilder mvcBuilder = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //starting application parts
            foreach (var file in ITSAssemblyResolve.ITSLoader.GetServerAssemblies())
            {
                Assembly asm = ITSAssemblyResolve.ITSLoader.Load(file);
                Type[] types = asm.GetTypes().Where(t => t.BaseType == typeof(ITSolutionContext)).ToArray();
                if (types != null)
                {
                    services.AddDbContext<ITSolutionContext>();

                    ITSDbContextOptions dbContextOptions = new ITSDbContextOptions();
                    object instance = Activator.CreateInstance(types[0], dbContextOptions);
                    ServiceDescriptor descriptor = new ServiceDescriptor(typeof(DbContext), typeof(ITSolutionContext), ServiceLifetime.Scoped);
                    services.Replace(descriptor);
                }
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

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
        private DbContextOptions DbContextOptionsFactory(IServiceProvider provider)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(AppConfigManager.Configuration.ConnectionString);

            return optionsBuilder.Options;
        }
    }
}
