using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RecieveTerminal
{
    public class PrintMessageCommand : Command
    {
        public string Message { get; set; }
    }
}
