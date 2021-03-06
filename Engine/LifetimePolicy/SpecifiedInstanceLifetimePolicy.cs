﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public class SpecifiedInstanceLifetimePolicy : ILifetimePolicy
    {
        private object _instance;
        
        public SpecifiedInstanceLifetimePolicy(object instance)
        {
            if (instance == null)
                throw new NotImplementedException("instance");

            _instance = instance;
        }

        public object GetInstance()
        {
            return _instance;
        }

        public IEnumerable<Type> Dependencies
        {
            get { return Enumerable.Empty<Type>(); }
        }
    }
}
