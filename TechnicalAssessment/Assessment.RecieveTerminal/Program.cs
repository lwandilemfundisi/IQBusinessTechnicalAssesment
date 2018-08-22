using Assessment.RabbitMqClient;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Assessment.RecieveTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening for incoming messages..");

            RabbitMqListenManager.Instance.Listen((chan, eventArgs) =>
            {
                var command = new PrintMessageCommand
                {
                    Message = Encoding.UTF8.GetString(eventArgs.Body)
                };

                var result = RecieveMessageApp.Instance.ExecuteCommand(command).Result;

                RabbitMqListenManager.Instance.SendAck(eventArgs.DeliveryTag);
            });

            Console.ReadKey();
        }
    }
}
