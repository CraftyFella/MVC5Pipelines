using System;

namespace MVC5Vanilla.Config
{
    public class ThingFinder
    {
        public bool Exists(Guid id)
        {
            return id.ToString().StartsWith("c");
        }
    }
}