using LightMessagingCore.Boilerplate.Messaging;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.BillingService
{
    public class OrderProcessedConsumer : IConsumer<IOrderProcessedEvent>
    {

        public async Task Consume(ConsumeContext<IOrderProcessedEvent> context)
        {
            var orderCommand = context.Message;

            await Console.Out.WriteLineAsync($"Order id: {orderCommand.OrderId} is being billed.");
        }
    }
}
