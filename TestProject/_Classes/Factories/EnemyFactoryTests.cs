namespace Test._Classes.Factories
{
    using Client._Classes.Factories;
    using System;
    using Xunit;

    public class EnemyFactoryTests
    {
        private EnemyFactory _testClass;

        public EnemyFactoryTests()
        {
            _testClass = new EnemyFactory();
        }

        [Fact]
        public void CanCallgetEnemy()
        {
            // Arrange
            var @type = "TestValue1749863717";

            // Act
            var result = EnemyFactory.getEnemy(type);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallgetEnemyWithInvalidType(string value)
        {
            Assert.Throws<ArgumentNullException>(() => EnemyFactory.getEnemy(value));
        }
    }
}