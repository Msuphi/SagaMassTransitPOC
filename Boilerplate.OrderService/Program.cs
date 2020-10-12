using LightMessagingCore.Boilerplate.Common;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "OrderService";

            var bus = BusConfigurator.Instance
                .ConfigureBus((cfg, host) =>
                {
                    cfg.ReceiveEndpoint(host, ConfigurationManager.AppSettings["OrderQueueName"], e =>
                    {
                        e.Consumer<OrderReceivedConsumer>();
                    });
                });

            bus.Start();

            Console.WriteLine("Listening order command..");
            Console.ReadLine();
        }
    }
}
