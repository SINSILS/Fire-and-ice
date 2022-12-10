namespace Test._Patterns_Designs._Bridge_Pattern
{
    using Client._Patterns_Designs._Bridge_Pattern;
    using System;
    using Xunit;

    public class HealingTests
    {
        private Healing _testClass;
        private int _value;

        public HealingTests()
        {
            _value = 316313474;
            _testClass = new Healing(_value);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Healing(_value);

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
            var health = 737513780;

            // Act
            var result = _testClass.GetPowerUpValue(health);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}