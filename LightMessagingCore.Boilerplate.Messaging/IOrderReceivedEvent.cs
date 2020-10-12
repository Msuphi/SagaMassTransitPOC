using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.Messaging
{
    public interface IOrderReceivedEvent
    {
        Guid CorrelationId { get; }
        int OrderId { get; }
        string OrderCode { get; }
    }
}
