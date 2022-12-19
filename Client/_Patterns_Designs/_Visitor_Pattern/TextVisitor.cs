using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client._Patterns_Designs._Template_Pattern;

namespace Client._Patterns_Designs._Visitor_Pattern
{
    public class TextVisitor : Visitor
    {

        public TextVisitor()
        {

        }

        public string Visit(OneCoinUpdate item)
        {
            return "You got one coin!";
        }

        public string Visit(TwoCoinUpdate item)
        {
            return "You got two coins!";
        }

        public string Visit(ThreeCoinUpdate item)
        {
            return "You got three coins!";
        }

        public string Visit(PowerupUpdate item)
        {
            return "Your speed increased!!!";
        }
    }
}
