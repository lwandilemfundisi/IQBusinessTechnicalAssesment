using Assessment.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.SendTerminal
{
    public class RabbitMQManager : IDisposable
    {
        private static RabbitMQManager _instance;
        private static object _syncer = new object();

        private readonly IModel channel;
        public RabbitMQManager()
        {
            var connectionFactory =
                new ConnectionFactory { Uri = new Uri(AssessmentConstants.RabbitMqUri) };
            var connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
        }

        public static RabbitMQManager Instance
        {
            get
            {
                if(_instance.IfNull())
                {
                    lock (_syncer)
                    {
                        if (_instance.IfNull())
                        {
                            _instance = new RabbitMQManager();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Send(string message)
        {
            channel.ExchangeDeclare(
                exchange: AssessmentConstants.SendHelloExchange,
                type: ExchangeType.Direct);
            channel.QueueDeclare(
                queue: AssessmentConstants.SendHelloQueue, durable: false,
                exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(
                queue: AssessmentConstants.SendHelloQueue,
                exchange: AssessmentConstants.SendHelloExchange,
                routingKey: "");

            var messageProperties = channel.CreateBasicProperties();
            messageProperties.ContentType =
                AssessmentConstants.JsonMimeType;

            channel.BasicPublish(
                exchange: AssessmentConstants.SendHelloExchange,
                routingKey: "",
                basicProperties: messageProperties,
                body: Encoding.UTF8.GetBytes(message));
        }

        public void Dispose()
        {
            if (!channel.IsClosed)
                channel.Close();
        }
    }
}
