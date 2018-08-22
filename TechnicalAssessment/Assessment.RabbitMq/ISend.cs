using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public interface ISend
    {
        void Send(object content, string mimeType);

        void ConfigureSendChannel();
    }
}
