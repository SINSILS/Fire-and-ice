namespace Test
{
    using Shared.Shared;
    using System;
    using Xunit;

    public class PlayerTests
    {
        private Player _testClass;

        public PlayerTests()
        {
            _testClass = new Player();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1578538431;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetisReady()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.isReady = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.isReady);
        }
    }
}