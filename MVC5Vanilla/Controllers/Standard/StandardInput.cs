using System;

namespace MVC5Vanilla.Controllers.Standard
{
    public class StandardInput : IHaveThing
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}