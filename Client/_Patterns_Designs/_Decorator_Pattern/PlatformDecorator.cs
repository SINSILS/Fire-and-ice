using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Decorator_Pattern
{
    public abstract class PlatformDecorator : IPlatform
    {
        protected IPlatform platform;
        public PlatformDecorator(IPlatform platform)
        {
            this.platform = platform;
        }

        public int Speed => platform.Speed;

        public virtual IPlatform CreatePlatform()
        {
            return platform.CreatePlatform();
        }
    }
}
