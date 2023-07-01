using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService_LocalHosting
{
  class Program
  {
    static void Main(string[] args)
    {

      // Step 2: Create a ServiceHost instance.
      ServiceHost selfHost = new ServiceHost(typeof(CalculatorService.Services.CalculatorServiceSvc));

      try
      {
        // Step 5: Start the service.
        selfHost.Open();
        Console.WriteLine("The service is ready.");

        // Close the ServiceHost to stop the service.
        Console.WriteLine("Press <Enter> to terminate the service.");
        Console.WriteLine();
        Console.ReadKey();
        selfHost.Close();
      }
      catch (Exception ce)
      {
        Console.WriteLine("An exception occurred: {0}", ce.Message);
        Console.ReadKey();
        selfHost.Abort();
      }
    }
  }
}
