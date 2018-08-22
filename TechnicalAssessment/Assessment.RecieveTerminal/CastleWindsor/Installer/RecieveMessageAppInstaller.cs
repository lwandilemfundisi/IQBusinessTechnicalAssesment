using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Framework.Application;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RecieveTerminal
{
    public class RecieveMessageAppInstaller : ApplicationWindsorInstaller
    {
        public override void RegisterActions(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<PrintMessageCommandHandler>().LifestyleTransient());
        }

        public override void RegisterRepositoryFactory(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPersistanceFactory>().ImplementedBy<DummyPersistenceFactory>());
        }
    }
}
