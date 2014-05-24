using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ConstructorInjection
{
    public class AttributeConstructorResolver : AbstractConstructorResolver
    {
        public AttributeConstructorResolver(AbstractConstructorResolver next)
            : base(next)
        {
        }

        public override ConstructorInfo GetConstructor(Type type)
        {
            var constructorsWithAttribute = type
                .GetConstructors()
                .Where(x => x.CustomAttributes.OfType<DependencyConstructorAttribute>().Any())
                .ToArray();

            if (constructorsWithAttribute.Length > 1)
                throw new DependencyConstructorException("Type {0} has too many constructors marked with attribute",
                    type.FullName);

            if (constructorsWithAttribute.Length == 1)
                return constructorsWithAttribute.First();

            return Next.GetConstructor(type);
        }
    }
}
