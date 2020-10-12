using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.Messaging
{
    public interface IOrderProcessedEvent
    {
        Guid CorrelationId { get; set; }
        int OrderId { get; set; }
    }
}
