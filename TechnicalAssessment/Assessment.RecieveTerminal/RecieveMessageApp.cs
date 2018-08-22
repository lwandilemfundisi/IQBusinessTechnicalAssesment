using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RecieveTerminal
{
    public class RecieveMessageApp : App
    {
        private static readonly object sync = new object();
        private static RecieveMessageApp _instance;

        #region Constructors

        public RecieveMessageApp()
            : base(new RecieveMessageAppInstaller())
        {
            RegisterCommandHandlers();
        }

        public RecieveMessageApp(ApplicationWindsorInstaller appInstaller)
            : base(appInstaller)
        {
            RegisterCommandHandlers();
        }

        #endregion

        #region Properties

        public static RecieveMessageApp Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new RecieveMessageApp();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region Abstract Methods

        protected override void RegisterCommandHandlers()
        {
            CommandProcessor.RegisterHandler<PrintMessageCommand, PrintMessageCommandHandler>();
        }

        #endregion
    }
}
