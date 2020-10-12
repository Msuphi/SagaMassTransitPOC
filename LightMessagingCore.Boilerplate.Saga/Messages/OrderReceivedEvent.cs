using LightMessagingCore.Boilerplate.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.Saga.Messages
{
    public class OrderReceivedEvent : IOrderReceivedEvent
    {
        private readonly OrderSagaState _orderSagaState;
        public OrderReceivedEvent(OrderSagaState orderSagaState)
        {
            _orderSagaState = orderSagaState;
        }
        public Guid CorrelationId => _orderSagaState.CorrelationId;

        public int OrderId => _orderSagaState.OrderId;

        public string OrderCode => _orderSagaState.OrderCode;
    }
}
