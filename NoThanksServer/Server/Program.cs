using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Services;


namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Services.PlayerManager)))
            {
                try
                {
                    host.Open();
                    /*NetTcpBinding binding = new NetTcpBinding()
                    {

                        OpenTimeout = new TimeSpan(0, 10, 0),
                        CloseTimeout = new TimeSpan(0, 10, 0),
                        SendTimeout = new TimeSpan(0, 10, 0),
                        ReceiveTimeout = new TimeSpan(0, 10, 0),
                    };*/
                    Console.WriteLine("Server is running");
                }
                catch (AddressAccessDeniedException)
                {
                    Console.WriteLine("Server isn't running");
                }
                Console.ReadLine();
            }
        }
    }
}
