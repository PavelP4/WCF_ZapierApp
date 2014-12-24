using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;


namespace ZapService.HostWS
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller();
            service.ServiceName = "WCFZapierAppService";
            service.Description = "WCF REST service for test Zapier's app.";
            service.StartType = ServiceStartMode.Automatic;            

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
