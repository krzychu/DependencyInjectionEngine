using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ConstructorInjection
{
    public class LongestConstructorResolver : AbstractConstructorResolver
    {
        public LongestConstructorResolver(AbstractConstructorResolver next)
            : base(next)
        {
        }

        public override ConstructorInfo GetConstructor(Type type)
        {
            var maxlen = type.GetConstructors().Max(x => x.GetParameters().Length);
            var candidates = type.GetConstructors()
                .Where(x => x.GetParameters().Length == maxlen)
                .ToArray();

            if (candidates.Length > 1)
                throw new DependencyConstructorException("Type {0} has at least two longest constructors", type.FullName);

            if (candidates.Length == 1)
                return candidates.First();

            return Next.GetConstructor(type);
        }
    }
}
