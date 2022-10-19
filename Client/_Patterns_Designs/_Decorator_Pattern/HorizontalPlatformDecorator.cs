using Client._Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Decorator_Pattern
{
    public class HorizontalPlatformDecorator : PlatformDecorator
    {
        public HorizontalPlatformDecorator(IPlatform platform) : base(platform)
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
                Platform HorizontalPlatform = (Platform)platform;
                HorizontalPlatform.Picture.BackColor = Color.ForestGreen;
                HorizontalPlatform.Picture.Tag="Horizontal";
                HorizontalPlatform.Speed=2;
            }
        }
    }
}
