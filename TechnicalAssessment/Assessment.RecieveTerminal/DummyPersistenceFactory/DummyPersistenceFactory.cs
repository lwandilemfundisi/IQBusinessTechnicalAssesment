﻿using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.RecieveTerminal
{
    public class DummyPersistenceFactory : IPersistanceFactory
    {
        public IPersistance<TDomain> GetRepository<TDomain>() where TDomain : class
        {
            throw new NotImplementedException();
        }
    }
}
