using LightMessagingCore.Boilerplate.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMessagingCore.Boilerplate.OrderUI.Models
{
    public class OrderModel : IOrderCommand
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
    }
}
