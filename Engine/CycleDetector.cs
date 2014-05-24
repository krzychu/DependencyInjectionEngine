using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class CycleDetector
    {
        public static void CheckForCycles(Type root, IContainer container)
        {
            Stack<Type> stack = new Stack<Type>();
            HashSet<Type> visited = new HashSet<Type>();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                foreach (var next in container.GetDependencies(current))
                {
                    if (visited.Contains(next))
                        throw new CyclicDependencyException(root);

                    stack.Push(next);
                }
            }
        }
    }
}
