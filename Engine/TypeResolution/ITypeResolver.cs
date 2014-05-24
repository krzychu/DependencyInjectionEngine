using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TypeResolution
{
    public interface ITypeResolver
    {
        object Resolve();

        IEnumerable<Type> Dependencies { get; }
    }
}
