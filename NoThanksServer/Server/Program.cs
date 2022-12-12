using log4net;
using Logs;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        private static readonly ILog Log = Logger.GetLogger();
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Services.GameService)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Server is running");
                }
                catch (AddressAccessDeniedException ex)
                {
                    Log.Error($"{ex.Message}");
                    Console.WriteLine("Server isn't running");
                }
                Console.ReadLine();
            }
        }
    }
}
