using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class QueueConfig
    {
        public string QueueName { get; set; }
        public bool Exclusive { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
    }
}
