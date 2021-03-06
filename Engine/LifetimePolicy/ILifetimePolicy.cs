﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.LifetimePolicy
{
    public interface ILifetimePolicy
    {
        object GetInstance();

        IEnumerable<Type> Dependencies { get; }
    }
}
