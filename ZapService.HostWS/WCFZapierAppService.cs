using System;
using System.ServiceModel;
using System.ServiceProcess;
using ZapServiceNS;


namespace ZapService.HostWS
{
    public class WCFZapierAppService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public WCFZapierAppService()
        {            
            ServiceName = "WCFZapierAppService";
        }

        public static void Main()
        {
            ServiceBase.Run(new WCFZapierAppService());
        }
        
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(ZapServiceNS.ZapService));
                        
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }

}
