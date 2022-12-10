namespace Test._Patterns_Designs._Bridge_Pattern
{
    using Client._Patterns_Designs._Bridge_Pattern;
    using Xunit;
    using System;

    public class SpeedBoostTests
    {
        private SpeedBoost _testClass;
        private int _value;

        public SpeedBoostTests()
        {
            _value = 1849312586;
            _testClass = new SpeedBoost(_value);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new SpeedBoost(_value);

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
            var speed = 938616507;

            // Act
            var result = _testClass.GetPowerUpValue(speed);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}