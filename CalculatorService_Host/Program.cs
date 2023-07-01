using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService_Host
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        EventLog.WriteEntry("CalculatorServiceHost", "At Main()", EventLogEntryType.Warning);

        ServiceBase[] ServicesToRunWithinThisConsole;
        ServicesToRunWithinThisConsole = new ServiceBase[]
        {
          new CalculatorServiceHost()
        };
        ServiceBase.Run(ServicesToRunWithinThisConsole);
      }
      catch (Exception ex)
      {
        EventLog.WriteEntry("CalculatorServiceHost", "At Main() Error --- " + ex.ToString(), EventLogEntryType.Error);
      }
    }
  }
}
