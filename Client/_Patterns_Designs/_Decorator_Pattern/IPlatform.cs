using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Decorator_Pattern
{
    public interface IPlatform
    {
        IPlatform CreatePlatform();
        int Speed
        {
            get;
        }
    }
}
