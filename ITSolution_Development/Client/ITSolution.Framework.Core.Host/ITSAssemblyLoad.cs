using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ITSolution.Framework.Core.Host
{
    public class ITSAssemblyLoader : AssemblyLoadContext
    {
        #region Singleton
        static ITSAssemblyLoader _loader;
        public static ITSAssemblyLoader ITSLoader
        {
            get
            {
                if (_loader == null)
                    _loader = new ITSAssemblyLoader();

                return _loader;
            }
        }
        #endregion
        public Assembly Load(string assemblyPath)
        {
            Assembly assembly = null;
            string assemblyDllFile = assemblyPath.Split("\\").Last();
            try
            {
                assembly = Assembly.LoadFile(assemblyPath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível carregar o assembly especificado: '{0}' \n Exception: '{1}' \n '{2}'", assemblyDllFile, ex.Message, ex.StackTrace);
            }

            return assembly;
        }
        protected override Assembly Load(AssemblyName assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName.FullName);
            return assembly;
        }
    }
}
