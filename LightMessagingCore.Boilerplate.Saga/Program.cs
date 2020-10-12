using LightMessagingCore.Boilerplate.Common;
using MassTransit;
using MassTransit.Saga;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.Saga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Saga";
            var orderSaga = new OrderSaga();
            var repo = new InMemorySagaRepository<OrderSagaState>();

            var bus = BusConfigurator.Instance
               .ConfigureBus((cfg,host) =>
               {
                   cfg.ReceiveEndpoint(host, ConfigurationManager.AppSettings["SagaQueueName"], e =>
                   {
                       e.StateMachineSaga(orderSaga, repo);
                   });
               });

            bus.StartAsync();

            Console.WriteLine("Order saga started..");
            Console.ReadLine();
        }
    }
}
