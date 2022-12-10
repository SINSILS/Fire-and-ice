namespace Test._Patterns_Designs._Interpreter
{
    using Client._Patterns_Designs._Interpreter;
    using System;
    using Xunit;

    public class ExpressionTests
    {
        private class TestExpression : Expression
        {
            public override void Interpret(Context value)
            {
            }
        }

        private TestExpression _testClass;

        public ExpressionTests()
        {
            _testClass = new TestExpression();
        }
    }
}