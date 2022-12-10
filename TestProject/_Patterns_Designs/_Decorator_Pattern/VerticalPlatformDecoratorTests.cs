namespace Test._Patterns_Designs._Decorator_Pattern
{
    using Client._Patterns_Designs._Decorator_Pattern;
    using System;
    using Xunit;

    public class VerticalPlatformDecoratorTests
    {
        private VerticalPlatformDecorator _testClass;
        private IPlatform _platform;

        public VerticalPlatformDecoratorTests()
        {
            _testClass = new VerticalPlatformDecorator(_platform);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new VerticalPlatformDecorator(_platform);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPlatform()
        {
            Assert.Throws<ArgumentNullException>(() => new VerticalPlatformDecorator(default(IPlatform)));
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