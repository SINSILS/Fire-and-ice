using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Decorator_Pattern
{
    public class VerticalPlatformDecorator : PlatformDecorator
    {
        public VerticalPlatformDecorator(IPlatform platform) : base(platform)
        {
        }

        public override IPlatform CreatePlatform()
        {
            platform.CreatePlatform();
            AddProperties(platform);
            return platform;
        }

        public void AddProperties(IPlatform platform)
        {
            if (platform is Platform)
            {
                Platform VerticalPlatformDecorator = (Platform)platform;
                VerticalPlatformDecorator.Picture.BackColor = Color.BlanchedAlmond;
                VerticalPlatformDecorator.Picture.Tag="Vertical";
            }
        }
    }
}
