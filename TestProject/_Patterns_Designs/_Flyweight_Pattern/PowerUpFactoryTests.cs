namespace Test._Patterns_Designs._Flyweight_Pattern
{
    using Client._Patterns_Designs._Flyweight_Pattern;
    using System;
    using Xunit;

    public class PowerUpFactoryTests
    {
        private PowerUpFactory _testClass;

        public PowerUpFactoryTests()
        {
            _testClass = new PowerUpFactory();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PowerUpFactory();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetPowerUp()
        {
            // Arrange
            var key = "TestValue409342267";

            // Act
            var result = _testClass.GetPowerUp(key);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallGetPowerUpWithInvalidKey(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.GetPowerUp(value));
        }

        [Fact]
        public void CanCallAddPowerUp()
        {
            // Arrange
            var key = "TestValue396096089";

            // Act
            var result = _testClass.AddPowerUp(key);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallAddPowerUpWithInvalidKey(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddPowerUp(value));
        }
    }
}