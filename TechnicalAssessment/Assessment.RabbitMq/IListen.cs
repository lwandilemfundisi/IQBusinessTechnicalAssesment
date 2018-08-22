using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public interface IListen
    {
        void ConfigureListenChannel();

        void Listen(EventHandler<BasicDeliverEventArgs> recieved);
    }
}
