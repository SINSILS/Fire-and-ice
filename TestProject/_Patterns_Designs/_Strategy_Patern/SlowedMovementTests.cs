namespace Test._Patterns_Designs._Strategy_Patern
{
    using Client._Patterns_Designs._Strategy_Patern;
    using System;
    using Xunit;
    using Client._Classes;

    public class SlowedMovementTests
    {
        private SlowedMovement _testClass;

        public SlowedMovementTests()
        {
            _testClass = new SlowedMovement();
        }

        [Fact]
        public void CanCallDoMovement()
        {
            // Arrange
            var player = new GamePlayer(1187188301, 122113747, 1249214464, 978423386, 834411806, 1834452128);

            // Act
            _testClass.DoMovement(player);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallDoMovementWithNullPlayer()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.DoMovement(default(GamePlayer)));
        }
    }
}