using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client._Patterns_Designs._Template_Pattern;

namespace Client._Patterns_Designs._Visitor_Pattern
{
    public interface Visitor
    {
        public string Visit(OneCoinUpdate item);
        public string Visit(TwoCoinUpdate item);
        public string Visit(ThreeCoinUpdate item);
        public string Visit(PowerupUpdate item);
    }
}
