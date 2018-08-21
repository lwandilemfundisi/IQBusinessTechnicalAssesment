using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.SendTerminal
{
    public class SendMessageApp : App
    {
        private static readonly object sync = new object();
        private static SendMessageApp _instance;

        #region Constructors

        public SendMessageApp()
            : base(new SendMessageAppInstaller())
        {
            RegisterCommandHandlers();
        }

        public SendMessageApp(ApplicationWindsorInstaller appInstaller)
            : base(appInstaller)
        {
            RegisterCommandHandlers();
        }

        #endregion

        #region Properties

        public static SendMessageApp Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new SendMessageApp();
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
            CommandProcessor.RegisterHandler<SendMessageCommad, SendMessageCommadHandler>();
        }

        #endregion
    }
}
