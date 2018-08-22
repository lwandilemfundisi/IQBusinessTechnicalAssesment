using Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Interpreter
{
    public class InterpretMessageApp : App
    {
        private static readonly object sync = new object();
        private static InterpretMessageApp _instance;

        #region Constructors

        public InterpretMessageApp()
            : base(new InterpretMessageAppInstaller())
        {
            RegisterCommandHandlers();
        }

        public InterpretMessageApp(ApplicationWindsorInstaller appInstaller)
            : base(appInstaller)
        {
            RegisterCommandHandlers();
        }

        #endregion

        #region Properties

        public static InterpretMessageApp Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new InterpretMessageApp();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        protected override void RegisterCommandHandlers()
        {
            CommandProcessor.RegisterHandler<InterpretMessageCommand, InterpretMessageCommandHandler>();
        }
    }
}
