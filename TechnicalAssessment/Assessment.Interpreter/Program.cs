using Assessment.RabbitMqClient;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Assessment.Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening for incoming messages to interpret..");

            RabbitMqListenManager.Instance.CustomConsumer = new InterpretMessageConsumer(RabbitMqListenManager.Instance);

            RabbitMqListenManager.Instance.Listen();

            Console.ReadKey();
        }
    }

    class InterpretMessageConsumer : DefaultBasicConsumer
    {
        private readonly RabbitMqListenManager manager;

        public InterpretMessageConsumer(RabbitMqListenManager manager)
        {
            this.manager = manager;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            var command = new InterpretMessageCommand
            {
                IncomingMessage = Encoding.UTF8.GetString(body)
            };

            var result = InterpretMessageApp.Instance.ExecuteCommand(command).Result;

            manager.SendAck(deliveryTag);
        }
    }
}
