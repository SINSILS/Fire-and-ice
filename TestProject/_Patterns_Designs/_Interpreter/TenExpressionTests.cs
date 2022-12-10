namespace Test._Patterns_Designs._Interpreter
{
    using Client._Patterns_Designs._Interpreter;
    using System;
    using Xunit;

    public class TenExpressionTests
    {
        private TenExpression _testClass;

        public TenExpressionTests()
        {
            _testClass = new TenExpression();
        }

        [Fact]
        public void CanCallInterpret()
        {
            // Arrange
            //var value = new Context(1688644848);

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