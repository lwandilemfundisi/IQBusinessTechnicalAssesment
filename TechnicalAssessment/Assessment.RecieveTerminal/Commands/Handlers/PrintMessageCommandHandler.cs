using Framework.Application;
using Framework.Common;
using Framework.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.RecieveTerminal
{
    public class PrintMessageCommandHandler : CommandHandler<PrintMessageCommand>
    {
        #region Constructors

        public PrintMessageCommandHandler(IPersistanceFactory repositoryFactory)
            : base(repositoryFactory)
        {
        }

        #endregion

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
                Console.WriteLine($"Here is the message: {Command.Message}.");
            });
        }
    }
}
