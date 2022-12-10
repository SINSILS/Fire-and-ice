namespace Test._Classes.ConcreteProducts
{
    using Client._Classes.ConcreteProducts;
    using System;
    using Xunit;

    public class LeverTests
    {
        private Lever _testClass;
        private string _color;
        private bool _isActivated;

        public LeverTests()
        {
            _color = "TestValue504697093";
            _isActivated = true;
            _testClass = new Lever(_color, _isActivated);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Lever(_color, _isActivated);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidColor(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Lever(value, false));
        }
    }
}