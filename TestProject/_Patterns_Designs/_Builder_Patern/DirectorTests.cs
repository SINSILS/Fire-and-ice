namespace Test._Patterns_Designs._Builder_Patern
{
    using Client._Patterns_Designs._Builder_Patern;
    using System;
    using Xunit;
    public class DirectorTests
    {
        private Director _testClass;

        public DirectorTests()
        {
            _testClass = new Director();
        }

        [Fact]
        public void CanCallConstruct()
        {
            // Arrange
            GreenCoinBuilder builder = new GreenCoinBuilder();
            // Act
            _testClass.Construct(builder);

            // Assert
            Assert.True(builder.GetCoin() != null);
        }

        [Fact]
        public void CannotCallConstructWithNullBuilder()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Construct(default(IBuilder)));
        }
    }
}