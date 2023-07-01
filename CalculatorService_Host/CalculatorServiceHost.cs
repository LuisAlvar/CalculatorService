using CalculatorService.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace CalculatorService_Host
{
  public partial class CalculatorServiceHost : ServiceBase
  {
    private ServiceHost sh = null;

    public CalculatorServiceHost()
    {
      EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost .constr ", EventLogEntryType.Information);

      InitializeComponent();
    }

    protected override void OnStart(string[] args)
    {
      try
      {
        //string strMainCmd = "netsh";
        //string strMainCmdArg = $"http add urlacl url={ConfigurationManager.AppSettings["HttpServiceLink"]} user={ConfigurationManager.AppSettings["HttpServiceLinkUnderUser"]}";
        //EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Attempting to executing the following .... {strMainCmd} {strMainCmd}", EventLogEntryType.Information);
        //Process p = new Process
        //{
        //  StartInfo =
        //    {
        //      FileName = strMainCmd,
        //      Arguments = strMainCmdArg
        //    }
        //};
        //p.Start();
        //Thread.Sleep(TimeSpan.FromSeconds(5));
        //p.Close();
        //p.Dispose();
        //EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Done excuting {strMainCmd} {strMainCmdArg}", EventLogEntryType.Information);

        // TODO: Add code here to start your service.
        EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost OnStart Method", EventLogEntryType.Information);
        sh = new ServiceHost(typeof(CalculatorService.Services.CalculatorServiceSvc));
        EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost ServiceHost for type of CalculatorServiceSvc", EventLogEntryType.Information);

        sh.Open();

        while (sh.State != CommunicationState.Opened)
        {
          EventLog.WriteEntry("CalculatorServiceHost", "Current status - " + sh.State, EventLogEntryType.Information);

          if (sh.State == CommunicationState.Faulted || sh.State == CommunicationState.Closed) break;
        }


        EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost ServiceHost for type of CalculatorServiceSvc opening that service host", EventLogEntryType.Information);
        EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost ServiceHost for type of CalculatorServiceSvc current status is set to " + sh.State, EventLogEntryType.Information);

      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CalculatorServiceHost", "Error CalculatorServiceHost OnStart Method \n" + ex.ToString(), EventLogEntryType.Error);
      }
    }

    protected override void OnStop()
    {
      EventLog.WriteEntry("CalculatorServiceHost", "Within the CalculatorServiceHost OnStop Method", EventLogEntryType.Information);
      try
      {
        // TODO: Add code here to perform any tear-down necessary to stop your service.
        if (sh != null) sh.Close();
        sh = null;
      }
      catch (Exception ex )
      {
        EventLog.WriteEntry("CalculatorServiceHost", "Error at CalculatorServiceHost OnStop Method - " + ex.ToString(), EventLogEntryType.Error);
      }
      

    }
  }
}
