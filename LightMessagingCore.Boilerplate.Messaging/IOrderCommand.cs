using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.Messaging
{
    public interface IOrderCommand
    {
        int OrderId { get; set; }
        string OrderCode { get; set; }
    }
}
