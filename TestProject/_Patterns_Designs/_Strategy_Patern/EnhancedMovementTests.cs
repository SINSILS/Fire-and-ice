namespace Test._Patterns_Designs._Strategy_Patern
{
    using Client._Patterns_Designs._Strategy_Patern;
    using System;
    using Xunit;
    using Client._Classes;

    public class EnhancedMovementTests
    {
        private EnhancedMovement _testClass;

        public EnhancedMovementTests()
        {
            _testClass = new EnhancedMovement();
        }

        [Fact]
        public void CanCallDoMovement()
        {
            // Arrange
            var player = new GamePlayer(934048990, 1195349496, 2034297514, 821561950, 1779132310, 485899105);

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