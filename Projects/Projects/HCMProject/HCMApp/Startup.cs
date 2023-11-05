using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using System.Data;
using System.ServiceModel;
using FormModel;
using System.ServiceProcess;

namespace HCMApp
{
    public class Startup
    {
        static void Main(string[] args)
        {
            if (AppInfo.ServiceMode)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new HCMCall() };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                HCMCall.StartProcessing();
            }
        }
    }
}
