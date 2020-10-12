using LightMessagingCore.Boilerplate.Messaging;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.OrderService
{
    public class OrderReceivedConsumer : IConsumer<IOrderReceivedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderReceivedEvent> context)
        {
            var orderReceive = context.Message;

            await Console.Out.WriteLineAsync($"Order code: {orderReceive.OrderCode} Order id: {orderReceive.OrderId} is received.");

            //bla bla

            await context.Publish<IOrderReceivedEvent>(
                new { CorrelationId = context.Message.CorrelationId, OrderId = orderReceive.OrderId });
        }
    }
}
