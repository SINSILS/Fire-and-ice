namespace Test._Classes
{
    using Client._Classes;
    using Client._Patterns_Designs._Bridge_Pattern;
    using Client._Patterns_Designs._Strategy_Patern;
    using System;
    using Xunit;

    public class GamePlayerTests
    {
        private GamePlayer _testClass;
        private int _health;
        private int _force;
        private int _horizontalSpeed;
        private int _verticalSpeed;
        private int _jumpSpeed;
        private int _playerSpeed;

        public GamePlayerTests()
        {
            _health = 714241017;
            _force = 1680886332;
            _horizontalSpeed = 1901930396;
            _verticalSpeed = 124944727;
            _jumpSpeed = 881469095;
            _playerSpeed = 1197649121;
            _testClass = new GamePlayer(_health, _force, _horizontalSpeed, _verticalSpeed, _jumpSpeed, _playerSpeed);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new GamePlayer(_health, _force, _horizontalSpeed, _verticalSpeed, _jumpSpeed, _playerSpeed);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetMovement()
        {
            // Act
            var result = _testClass.GetMovement();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallSetMovementWithNullMoveType()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.SetMovement(default(MoveAlgorithm)));
        }

        [Fact]
        public void CanCallMovementAction()
        {
            // Arrange
            var player = new GamePlayer(1755498, 598032954, 105769921, 1677058302, 863759648, 1416981193);

            // Act
            _testClass.MovementAction(player);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallMovementActionWithNullPlayer()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.MovementAction(default(GamePlayer)));
        }

        [Fact]
        public void CanCallLowerHealth()
        {
            // Arrange
            var value = 840109135;

            // Act
            _testClass.LowerHealth(value);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallApplyPowerUpWithNullPowerUp()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.ApplyPowerUp(default(PowerUp)));
        }

        [Fact]
        public void CanCallRemovePowerUp()
        {
            // Act
            _testClass.RemovePowerUp();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void healthIsInitializedCorrectly()
        {
            Assert.Equal(_health, _testClass.health);
        }

        [Fact]
        public void CanSetAndGethealth()
        {
            // Arrange
            var testValue = 924219204;

            // Act
            _testClass.health = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.health);
        }

        [Fact]
        public void jumpSpeedIsInitializedCorrectly()
        {
            Assert.Equal(_jumpSpeed, _testClass.jumpSpeed);
        }

        [Fact]
        public void CanSetAndGetjumpSpeed()
        {
            // Arrange
            var testValue = 1401252073;

            // Act
            _testClass.jumpSpeed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.jumpSpeed);
        }

        [Fact]
        public void forceIsInitializedCorrectly()
        {
            Assert.Equal(_force, _testClass.force);
        }

        [Fact]
        public void CanSetAndGetforce()
        {
            // Arrange
            var testValue = 1984047114;

            // Act
            _testClass.force = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.force);
        }

        [Fact]
        public void playerSpeedIsInitializedCorrectly()
        {
            Assert.Equal(_playerSpeed, _testClass.playerSpeed);
        }

        [Fact]
        public void CanSetAndGetplayerSpeed()
        {
            // Arrange
            var testValue = 1647624164;

            // Act
            _testClass.playerSpeed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.playerSpeed);
        }

        [Fact]
        public void horizontalSpeedIsInitializedCorrectly()
        {
            Assert.Equal(_horizontalSpeed, _testClass.horizontalSpeed);
        }

        [Fact]
        public void CanSetAndGethorizontalSpeed()
        {
            // Arrange
            var testValue = 1804741319;

            // Act
            _testClass.horizontalSpeed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.horizontalSpeed);
        }

        [Fact]
        public void verticalSpeedIsInitializedCorrectly()
        {
            Assert.Equal(_verticalSpeed, _testClass.verticalSpeed);
        }

        [Fact]
        public void CanSetAndGetverticalSpeed()
        {
            // Arrange
            var testValue = 491495697;

            // Act
            _testClass.verticalSpeed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.verticalSpeed);
        }

        [Fact]
        public void CanCallSetMovement()
        {
            // Arrange
            EnhancedMovement moveType = new EnhancedMovement();

            // Act
            _testClass.SetMovement(moveType);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallApplyPowerUp()
        {
            // Arrange
            var powerUp = new Healing(10);

            // Act
            _testClass.ApplyPowerUp(powerUp);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}