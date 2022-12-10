namespace Test._Patterns_Designs._Bridge_Pattern
{
    using Client._Patterns_Designs._Bridge_Pattern;
    using Xunit;
    using System;

    public class JumpBoostTests
    {
        private JumpBoost _testClass;
        private int _value;

        public JumpBoostTests()
        {
            _value = 1032340235;
            _testClass = new JumpBoost(_value);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new JumpBoost(_value);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetPowerUpType()
        {
            // Act
            var result = _testClass.GetPowerUpType();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetPowerUpValue()
        {
            // Arrange
            var jumpingHeight = 1964161787;

            // Act
            var result = _testClass.GetPowerUpValue(jumpingHeight);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}