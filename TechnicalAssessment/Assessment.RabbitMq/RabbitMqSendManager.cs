using Framework.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class RabbitMqSendManager : RabbitMqManager, ISend
    {
        private static RabbitMqSendManager _instance;
        private static object _syncer = new object();

        private readonly SendManagerConfig _config;

        #region Constructors

        public RabbitMqSendManager(SendManagerConfig config)
            : base(config.RabbitMqUri)
        {
            _config = config;
            ConfigureSendChannel();
        }

        #endregion

        #region Properties

        public static RabbitMqSendManager Instance
        {
            get
            {
                if(_instance.IfNull())
                {
                    lock(_syncer)
                    {
                        if (_instance.IfNull())
                        {
                            _instance = new RabbitMqSendManager(AppConfig.GetConfig("sendManagerConfig.json").Get<SendManagerConfig>());
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region ISend

        public void ConfigureSendChannel()
        {
            channel.ExchangeDeclare(
                exchange: _config.ExchangeConfig.ExchangeName,
                type: _config.ExchangeConfig.ExchangeType);

            channel.QueueDeclare(
                queue: _config.QueueConfig.QueueName, durable: _config.QueueConfig.Durable,
                exclusive: _config.QueueConfig.Exclusive, autoDelete: _config.QueueConfig.AutoDelete, arguments: null);
            channel.QueueBind(
                queue: _config.QueueConfig.QueueName,
                exchange: _config.ExchangeConfig.ExchangeName,
                routingKey: _config.RoutingKey);
        }

        public void Send(object content, string mimeType)
        {
            var messageProperties = channel.CreateBasicProperties();
            messageProperties.ContentType = mimeType;

            channel.BasicPublish(
                exchange: _config.ExchangeConfig.ExchangeName,
                routingKey: _config.RoutingKey,
                basicProperties: messageProperties,
                body: Encoding.UTF8.GetBytes(content as string));
        }

        #endregion
    }
}
