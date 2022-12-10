namespace Test._Patterns_Designs._Interpreter
{
    using Client._Patterns_Designs._Interpreter;
    using System;
    using Xunit;

    public class OneExpressionTests
    {
        private OneExpression _testClass;

        public OneExpressionTests()
        {
            _testClass = new OneExpression();
        }

        [Fact]
        public void CanCallInterpret()
        {
            // Arrange
            //var value = new Context(1307082262);

            // Act
            //_testClass.Interpret(value);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallInterpretWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Interpret(default(Context)));
        }
    }
}