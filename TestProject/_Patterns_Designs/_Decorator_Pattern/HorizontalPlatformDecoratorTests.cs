namespace Test._Patterns_Designs._Decorator_Pattern
{
    using Client._Patterns_Designs._Decorator_Pattern;
    using System;
    using Xunit;
    public class HorizontalPlatformDecoratorTests
    {
        private HorizontalPlatformDecorator _testClass;
        private IPlatform _platform;

        public HorizontalPlatformDecoratorTests()
        {
            _testClass = new HorizontalPlatformDecorator(_platform);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new HorizontalPlatformDecorator(_platform);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPlatform()
        {
            Assert.Throws<ArgumentNullException>(() => new HorizontalPlatformDecorator(default(IPlatform)));
        }

        [Fact]
        public void CanCallCreatePlatform()
        {
            // Act
            var result = _testClass.CreatePlatform();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }


        [Fact]
        public void CannotCallAddPropertiesWithNullPlatform()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddProperties(default(IPlatform)));
        }
    }
}