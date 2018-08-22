using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class SendManagerConfig
    {
        public string RoutingKey { get; set; }
        public string RabbitMqUri { get; set; }
        public ExchangeConfig ExchangeConfig { get; set; }
        public QueueConfig QueueConfig { get; set; }
    }
}
