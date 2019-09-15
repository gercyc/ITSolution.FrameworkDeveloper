using ITSolution.Framework.BaseClasses;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ITSolution.Framework.Core.BaseClasses
{
    public class ITSAssemblyResolve : AssemblyLoadContext
    {
        #region Singleton
        static ITSAssemblyResolve _loader;
        public static ITSAssemblyResolve ITSLoader
        {
            get
            {
                if (_loader == null)
                {
                    _loader = new ITSAssemblyResolve();
                }
                return _loader;
            }
        }
        #endregion


        protected override Assembly Load(AssemblyName assemblyName)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFile(Path.Combine(EnvironmentInformation.CoreAssemblyFolder, assemblyName.Name + ".dll"));
                DependencyContext.Load(assembly);
                return assembly;
            }
            catch (FileNotFoundException fileNotFound)
            {
                try
                {
                    assembly = Assembly.LoadFile(Path.Combine(EnvironmentInformation.APIAssemblyFolder, assemblyName.Name + ".dll"));
                    DependencyContext.Load(assembly);
                    return assembly;
                }
                catch (Exception exApi)
                {
                    Utils.ShowExceptionStack(exApi);
                    Utils.ShowExceptionStack(fileNotFound);

                }

            }
            catch (Exception exAsmNotFound)
            {
                Utils.ShowExceptionStack(exAsmNotFound);
                throw;
            }
            return assembly;
        }

        public Assembly Load(string assemblyPath)
        {
            AssemblyName assemblyName = InternalLoad(assemblyPath).GetName();
            return this.Load(assemblyName);
        }

        /// <summary>
        /// Get server assemblies for add parts on application
        /// </summary>
        /// <returns></returns>
        public string[] GetServerAssemblies()
        {
            return InternalGetServerAssemblies();
        }

        internal Assembly InternalLoad(string assemblyPath)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFile(assemblyPath);
                AssemblyName[] refAssemblies;
                var dps = DependencyContext.Default;

                //try resolve dependencies
                if (assembly != null)
                {
                    DependencyContext.Load(assembly);
                    refAssemblies = assembly.GetReferencedAssemblies();

                    foreach (var asm in refAssemblies.Where(n => n.FullName.Contains("ITSolution.Framework.Core")
                    || n.FullName.Contains("ITSolution.Framework.Server.Core")))
                    {
                        this.Load(asm);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível carregar o assembly especificado: '{0}' \n Exception: '{1}' \n '{2}'", assemblyPath, ex.Message, ex.StackTrace);
            }

            return assembly;
        }

        internal string[] InternalGetServerAssemblies()
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(EnvironmentInformation.APIAssemblyFolder, "*.dll")
                    .Where(f => f.Contains("ITSolution.Framework.Servers.Core")).ToArray();

            }
            catch (Exception ex)
            {
                Utils.ShowExceptionStack(ex);
            }
            return files;
        }
    }
}
