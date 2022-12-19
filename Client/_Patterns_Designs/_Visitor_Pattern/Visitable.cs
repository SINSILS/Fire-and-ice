using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Visitor_Pattern
{
    public interface Visitable
    {
        public string Accept(Visitor visitor);
    }
}
