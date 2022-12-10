namespace Test._Patterns_Designs._Interpreter
{
    using Client._Patterns_Designs._Interpreter;
    using System;
    using Xunit;

    public class ContextTests
    {
        private Context _testClass;
        private int _input;

        public ContextTests()
        {
            _input = 341217848;
            _testClass = new Context(_input);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Context(_input);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void InputIsInitializedCorrectly()
        {
            Assert.Equal(_input, _testClass.Input);
        }

        [Fact]
        public void CanSetAndGetInput()
        {
            // Arrange
            var testValue = 1585376870;

            // Act
            _testClass.Input = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Input);
        }

        [Fact]
        public void CanSetAndGetOutput()
        {
            // Arrange
            var testValue = "TestValue672268695";

            // Act
            _testClass.Output = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Output);
        }
    }
}