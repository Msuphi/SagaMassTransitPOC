using LightMessagingCore.Boilerplate.Common;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.BillingService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "BillingService";

            var bus = BusConfigurator.Instance
                .ConfigureBus((cfg, host) =>
                {
                    cfg.ReceiveEndpoint(host, ConfigurationManager.AppSettings["OrderQueueName"], e =>
                    {
                        e.Consumer<OrderProcessedConsumer>();
                    });
                });

            bus.StartAsync();

            Console.WriteLine("Listening order processed event..");
            Console.ReadLine();
        }
    }
}
