using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.ServiceFramework.Service
{
    [RunInstaller(true)]
    public class ItsServiceInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ItsServiceInstaller()
        {
            
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            
            service = new ServiceInstaller();
            service.ServiceName = "ITSolutionFrameworkServer";
            
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
