using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace CalculatorService_Host
{
  [RunInstaller(true)]
  public partial class ProjectInstaller : System.Configuration.Install.Installer
  {

    public ProjectInstaller()
    {
      EventLog.WriteEntry("CalculatorServiceHostInstaller", "Project Installer .constr ....", EventLogEntryType.Information);
      InitializeComponent();
    }

    public override void Install(IDictionary stateSaver)
    {
      EventLog.WriteEntry("CalculatorServiceHostInstaller", "Project Installer Install Method  ....", EventLogEntryType.Information);

      string usr = this.Context.Parameters["username"];
      string pwd = this.Context.Parameters["password"];
      EventLog.WriteEntry("CalculatorServiceHostInstaller", "Project Installer Service Account " + usr + "::" + pwd, EventLogEntryType.Information);


      base.Install(stateSaver);
    }

    private void CalculatorServiceHostInstaller_AfterInstall(object sender, InstallEventArgs e)
    {
      EventLog.WriteEntry("CalculatorServiceHostInstaller", "CalculatorServiceHostInstaller_AfterInstall ... ", EventLogEntryType.Information);

      try
      {
        string WindowsServiceName = CalculatorServiceHostInstaller.ServiceName ?? string.Empty;
        EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Looking for service ({WindowsServiceName})", EventLogEntryType.Information);


        if (ServiceController.GetServices().Where(s => s.ServiceName == WindowsServiceName).Any())
        {

          EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Windows service ({WindowsServiceName}) does not exist.", EventLogEntryType.Information);
          // create the service 
          //string InstallExeAbsFilePath = Context.Parameters["assemblyPath"];
          //string strMainCmd = "sc.exe";
          //string strMainCmdArg = $"create \"{WindowsServiceName}\" binpath=\"{InstallExeAbsFilePath}\"";
          //EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Context.Paramenter install path testinng .. ({InstallExeAbsFilePath})", EventLogEntryType.Information);
          //Process p = new Process
          //{
          //  StartInfo =
          //  {
          //    FileName = strMainCmd,
          //    Arguments = strMainCmdArg
          //  }
          //};
          //EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Attempting to execute:: {strMainCmd} {strMainCmdArg}", EventLogEntryType.Information);

          //p.Start();

          ////Wait for the Window service to be created before starting it
          //Thread.Sleep(TimeSpan.FromSeconds(10));

          ServiceController sc = new ServiceController(WindowsServiceName);

          EventLog.WriteEntry("CalculatorServiceHostInstaller", "Created the object of type ServiceController ", EventLogEntryType.Information);
          Thread.Sleep(TimeSpan.FromSeconds(5));

          sc.Start();
          Thread.Sleep(TimeSpan.FromSeconds(5));

          //p.Close();
          //p.Dispose();

          EventLog.WriteEntry("CalculatorServiceHostInstaller", "Created the object of type ServiceController done starting ... ", EventLogEntryType.Information);

        }
        else
        {
          EventLog.WriteEntry("CalculatorServiceHostInstaller", $"Windows service ({WindowsServiceName}) already exists.", EventLogEntryType.Information);
        }
      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CalculatorServiceHostInstaller", "Error with AfterInstall Method --- " + ex.ToString(), EventLogEntryType.Error);
      }

    }

    //private void CalculatorServiceHostInstaller_BeforeUninstall(object sender, InstallEventArgs e)
    //{
    //  EventLog.WriteEntry("CalculatorServiceHostUnInstaller", "Project Installer Before Uninstall ....", EventLogEntryType.Information);
    //  try
    //  {
    //    string WindowsServiceName = CalculatorServiceHostInstaller.ServiceName ?? string.Empty;
    //    EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"Looking for service ({WindowsServiceName})", EventLogEntryType.Information);
    //    ServiceController service;

    //    if (ServiceController.GetServices().Where(s => s.ServiceName == WindowsServiceName).Any())
    //    {

    //      service  = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == WindowsServiceName);

    //      //Need to stop and then delete the window service 
    //      EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"({WindowsServiceName}) service status is currently set to {service.Status}", EventLogEntryType.Information);

    //      if (service.Status.Equals(ServiceControllerStatus.Stopped) || service.Status.Equals(ServiceControllerStatus.StopPending))
    //      {
    //        Thread.Sleep(TimeSpan.FromSeconds(1));
    //        //delete the service 
    //        string strMainCmd = "sc.exe";
    //        string strMainCmdArg = $"delete \"{WindowsServiceName}\"";

    //        Process p = new Process
    //        {
    //          StartInfo =
    //          {
    //            FileName = strMainCmd,
    //            Arguments = strMainCmdArg
    //          }
    //        };
    //        EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"Attempting to execute:: {strMainCmd} {strMainCmdArg}", EventLogEntryType.Information);

    //        p.Start();
    //        Thread.Sleep(TimeSpan.FromSeconds(10));
    //        p.Close();
    //        p.Dispose();

    //      }
    //      else
    //      {
    //        service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == WindowsServiceName);

    //        //stope the service and delete the service 
    //        string strMainCmd = "sc.exe";
    //        string strMainCmdArg = $"stop \"{WindowsServiceName}\"";

    //        Process p = new Process
    //        {
    //          StartInfo =
    //          {
    //            FileName = strMainCmd,
    //            Arguments = strMainCmdArg
    //          }
    //        };
    //        EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"Attempting to execute:: {strMainCmd} {strMainCmdArg}", EventLogEntryType.Information);

    //        p.Start();
    //        EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"Trying to stop {WindowsServiceName} service", EventLogEntryType.Information);

    //        Thread.Sleep(TimeSpan.FromSeconds(10)); 
    //        p.Close();
    //        p.Dispose();

    //        //delete the service 
    //        strMainCmd = "sc.exe";
    //        strMainCmdArg = $"delete \"{WindowsServiceName}\"";

    //        p = new Process
    //        {
    //            StartInfo =
    //          {
    //            FileName = strMainCmd,
    //            Arguments = strMainCmdArg
    //          }
    //        };
    //        EventLog.WriteEntry("CalculatorServiceHostUnInstaller", $"Attempting to execute:: {strMainCmd} {strMainCmdArg}", EventLogEntryType.Information);

    //        p.Start();
    //        Thread.Sleep(TimeSpan.FromSeconds(5));
    //        p.Close();
    //        p.Dispose();
    //      }

    //    }

    //  }
    //  catch (Exception ex)
    //  {
    //    EventLog.WriteEntry("CalculatorServiceHostUnInstaller", "Error with BeforeUninstall Method --- " + ex.ToString(), EventLogEntryType.Error);
    //  }

    //}
  
  }
}
