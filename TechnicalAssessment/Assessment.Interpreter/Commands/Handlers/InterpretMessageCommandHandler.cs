using Assessment.RabbitMqClient;
using Framework.Application;
using Framework.Common;
using Framework.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Interpreter
{
    public class InterpretMessageCommandHandler : CommandHandler<InterpretMessageCommand>
    {
        #region Constructors

        public InterpretMessageCommandHandler(IPersistanceFactory repositoryFactory)
            : base(repositoryFactory)
        {
        }

        #endregion

        #region Virtual Methods

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
            await Task.Run(() =>
            {
                RabbitMqSendManager.Instance.Send(Interpret(Command.IncomingMessage), "application/json");
            });
        }

        #endregion

        #region Private Methods

        private string Interpret(string incomingMessage)
        {
            switch (incomingMessage)
            {
                case "Lwandile": return $"You are the best, {incomingMessage}";
                case "Test": return $"You passed with flying colors!!!";
                default: return "I don't know what you mean there..!";
            }
        }

        #endregion
    }
}
