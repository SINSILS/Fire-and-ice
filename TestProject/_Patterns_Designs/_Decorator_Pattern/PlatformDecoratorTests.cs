namespace Test._Patterns_Designs._Decorator_Pattern
{
    using Client._Classes;
    using Client._Patterns_Designs._Decorator_Pattern;
    using System;
    using Xunit;

    public class PlatformDecoratorTests
    {
        private class TestPlatformDecorator : PlatformDecorator
        {
            public TestPlatformDecorator(IPlatform platform) : base(platform)
            {
            }
        }

        private TestPlatformDecorator _testClass;
        private IPlatform _platform;

        public PlatformDecoratorTests()
        {
            _platform = new Platform();
            _testClass = new TestPlatformDecorator(_platform);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TestPlatformDecorator(_platform);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPlatform()
        {
            Assert.Throws<ArgumentNullException>(() => new TestPlatformDecorator(default(IPlatform)));
        }
    }
}