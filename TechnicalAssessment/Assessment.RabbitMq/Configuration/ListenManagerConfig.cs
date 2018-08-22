using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class ListenManagerConfig
    {
        public string RabbitMqUri { get; set; }
        public QueueConfig QueueConfig { get; set; }
        public BasicQos BasicQos { get; set; }
    }
}
