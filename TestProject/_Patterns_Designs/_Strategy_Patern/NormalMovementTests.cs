namespace Test._Patterns_Designs._Strategy_Patern
{
    using Client._Patterns_Designs._Strategy_Patern;
    using System;
    using Xunit;
    using Client._Classes;

    public class NormalMovementTests
    {
        private NormalMovement _testClass;

        public NormalMovementTests()
        {
            _testClass = new NormalMovement();
        }

        [Fact]
        public void CanCallDoMovement()
        {
            // Arrange
            var player = new GamePlayer(3523429, 632695784, 1624422413, 1543579237, 1639325567, 2122579273);

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