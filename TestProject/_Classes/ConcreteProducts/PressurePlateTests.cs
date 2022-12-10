namespace Test._Classes.ConcreteProducts
{
    using Client._Classes.ConcreteProducts;
    using System;
    using Xunit;

    public class PressurePlateTests
    {
        private PressurePlate _testClass;
        private string _color;
        private bool _isActivated;

        public PressurePlateTests()
        {
            _color = "TestValue1635015975";
            _isActivated = true;
            _testClass = new PressurePlate(_color, _isActivated);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PressurePlate(_color, _isActivated);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidColor(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new PressurePlate(value, false));
        }
    }
}