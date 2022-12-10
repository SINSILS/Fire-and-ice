namespace Client._Patterns_Designs._Interpreter
{
    public class TenExpression : Expression
    {
        public override void Interpret(Context value)
        {
            if (value == null) { throw new ArgumentNullException(); }
            while ((value.Input - 90) >= 0)
            {
                value.Output += "XC";

                value.Input -= 90;
            }

            while ((value.Input - 50) >= 0)
            {
                value.Output += "L";

                value.Input -= 50;
            }

            while ((value.Input - 40) >= 0)
            {
                value.Output += "XL";

                value.Input -= 40;
            }

            while ((value.Input - 30) >= 0)
            {
                value.Output += "XXX";

                value.Input -= 30;
            }

            while ((value.Input - 20) >= 0)
            {
                value.Output += "XX";

                value.Input -= 20;
            }

            while ((value.Input - 10) >= 0)
            {
                value.Output += "X";

                value.Input -= 10;
            }
        }
    }
}
