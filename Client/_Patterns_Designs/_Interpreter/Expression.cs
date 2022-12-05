using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Interpreter
{
    public abstract class Expression
    {
        public abstract void Interpret(Context value);
    }
}
