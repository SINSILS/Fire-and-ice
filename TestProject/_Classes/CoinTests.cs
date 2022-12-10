namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;
    using System.Collections.Generic;

    public class CoinTests
    {
        private Coin _testClass;

        public CoinTests()
        {
            _testClass = new Coin();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Coin();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallsetInvisible()
        {
            // Act
            _testClass.setInvisible();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallsetValueAndColor()
        {
            // Act
            _testClass.setValueAndColor();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetname()
        {
            // Arrange
            var testValue = "TestValue1449992679";

            // Act
            _testClass.name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.name);
        }

        [Fact]
        public void CanSetAndGetParts()
        {
            // Arrange
            var testValue = new List<Part>();

            // Act
            _testClass.Parts = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Parts);
        }
    }
}