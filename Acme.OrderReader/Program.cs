using System;
using System.ServiceModel;

namespace Acme.OrderReader
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrderInboundMessageHandlerService));
            host.Faulted += host_Faulted;
            host.Open();
            Console.WriteLine("The service is ready");
            Console.WriteLine("Press <ENTER> to terminate the service");
            Console.ReadLine();
            if (host != null)
            {
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }
                host.Close();
            }
        }

        static void host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Faulted!");
        }
    }
}
