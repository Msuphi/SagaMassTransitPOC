using LightMessagingCore.Boilerplate.Common;
using LightMessagingCore.Boilerplate.OrderUI.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightMessagingCore.Boilerplate.OrderUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISendEndpoint _bus;
        public OrderController()
        {
            var busControl = BusConfigurator.Instance.ConfigureBus();
            //var sendToUri = new Uri($"{MqConstants.RabbitMQUri}{ConfigurationManager.AppSettings["OrderQueueName"]}");

            var sendToUri = new Uri($"{MqConstants.RabbitMQUri}{ConfigurationManager.AppSettings["SagaQueueName"]}");

            _bus = busControl.GetSendEndpoint(sendToUri).Result;
        }
        public ActionResult Index(OrderModel orderModel)
        {
            if (orderModel.OrderId > 0)
                CreateOrder(orderModel);

            return View();
        }

        private void CreateOrder(OrderModel orderModel)
        {
            _bus.Send(orderModel).Wait();
        }
    }
}