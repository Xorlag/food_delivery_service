using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.MessageBrokerListener.Configuration
{
    public class OrderServiceConfiguration
    {
        public string RabbitMqConnectionString { get; set; }
        public string DatabaseConnectionString { get; set; }
    }
}
