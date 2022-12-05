using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Interpreter
{
    public class OneExpression : Expression
    {
        public override void Interpret(Context value)
        {
            while ((value.Input - 9) >= 0)
            {
                value.Output += "IX";

                value.Input -= 9;
            }

            while ((value.Input - 5) >= 0)
            {
                value.Output += "V";

                value.Input -= 5;
            }

            while ((value.Input - 4) >= 0)
            {
                value.Output += "IV";

                value.Input -= 4;
            }

            while ((value.Input - 3) >= 0)
            {
                value.Output += "III";

                value.Input -= 3;
            }

            while ((value.Input - 2) >= 0)
            {
                value.Output += "II";

                value.Input -= 2;
            }

            while ((value.Input - 1) >= 0)
            {
                value.Output += "I";

                value.Input -= 1;
            }
        }
    }
}
