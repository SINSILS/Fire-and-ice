using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Interpreter
{
    public class Context
    {
        public Context(int input)
        {
            Input = input;
        }

        public int Input { get; set; }

        public string Output{ get; set; }
    }
}
