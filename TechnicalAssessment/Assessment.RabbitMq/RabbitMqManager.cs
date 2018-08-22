using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public abstract class RabbitMqManager : IDisposable
    {
        protected readonly IModel channel;

        protected RabbitMqManager(string rabbitMqUri)
        {
            var connectionFactory =
                new ConnectionFactory { Uri = new Uri(rabbitMqUri) };
            var connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
        }

        #region IDisposable

        public void Dispose()
        {
            if (!channel.IsClosed)
                channel.Close();
        }

        #endregion
    }
}
