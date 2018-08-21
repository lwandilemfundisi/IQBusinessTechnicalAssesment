using Assessment.Domain;
using Framework.Application;
using Framework.Common;
using Framework.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.SendTerminal
{
    public class SendMessageCommadHandler : CommandHandler<SendMessageCommad>
    {
        public SendMessageCommadHandler(IPersistanceFactory repositoryFactory)
            : base(repositoryFactory)
        {
        }

        protected override AbstractResponse BuildResponse()
        {
            return new JsonResponse()
            {
                Json = JsonConvert.SerializeObject(Command),
                Type = Command.GetType()
            };
        }

        protected override async Task ExecuteCommand()
        {
            var message = new Message { Content = Command.Content };

            await Task.Run(() => 
            {
                Validate(message, (c) => 
                {
                    RabbitMQManager.Instance.Send(c.Content);
                });
            });
        }
    }
}
