using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class BasicQos
    {
        public string PrefetchSize { get; set; }
        public string PrefetchCount { get; set; }
        public bool Global { get; set; }
    }
}
