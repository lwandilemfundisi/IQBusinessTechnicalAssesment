using Framework.Common;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RabbitMqClient
{
    public class RabbitMqListenManager : RabbitMqManager, IListen
    {
        private static RabbitMqListenManager _instance;
        private static object _syncer = new object();

        private readonly ListenManagerConfig _config;

        #region Constructors

        public RabbitMqListenManager(ListenManagerConfig config)
            : base(config.RabbitMqUri)
        {
            _config = config;
            ConfigureListenChannel();
        }

        #endregion

        #region Properties

        public static RabbitMqListenManager Instance
        {
            get
            {
                if (_instance.IfNull())
                {
                    lock (_syncer)
                    {
                        if (_instance.IfNull())
                        {
                            _instance = new RabbitMqListenManager(AppConfig.GetConfig("listenManagerConfig.json").Get<ListenManagerConfig>());
                        }
                    }
                }

                return _instance;
            }
        }

        public IBasicConsumer CustomConsumer { get; set; }

        #endregion

        #region IListen

        public void ConfigureListenChannel()
        {
            channel.QueueDeclare(queue: _config.QueueConfig.QueueName,
                                 durable: _config.QueueConfig.Durable, 
                                 exclusive: _config.QueueConfig.Exclusive,
                                 autoDelete: _config.QueueConfig.AutoDelete, arguments: null);

            channel.BasicQos(prefetchSize: uint.Parse(_config.BasicQos.PrefetchSize), 
                             prefetchCount: ushort.Parse(_config.BasicQos.PrefetchCount), 
                             global: _config.BasicQos.Global);
        }

        public void Listen(EventHandler<BasicDeliverEventArgs> recieved = null)
        {
            channel.BasicConsume(
                queue: _config.QueueConfig.QueueName,
                autoAck: false,
                consumer: BuildConsumer(recieved));
        }

        #endregion

        #region Methods

        public void SendAck(ulong deliveryTag)
        {
            channel.BasicAck(deliveryTag: deliveryTag, multiple: false);
        }

        private IBasicConsumer BuildConsumer(EventHandler<BasicDeliverEventArgs> recieved)
        {
            IBasicConsumer consumer = null;

            if (CustomConsumer.IfNull())
            {
                consumer = new EventingBasicConsumer(channel);

                ((EventingBasicConsumer)consumer).Received += recieved;
            }
            else
            {
                return CustomConsumer;
            }

            return consumer;
        }

        #endregion
    }
}
