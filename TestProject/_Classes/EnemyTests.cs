namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;

    public class EnemyTests
    {
        private Enemy _testClass;

        public EnemyTests()
        {
            _testClass = new Enemy();
        }

        [Fact]
        public void CanCallDisplay()
        {
            // Arrange
            var depth = 713119949;

            // Act
            _testClass.Display(depth);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallIsEnemy()
        {
            // Act
            var result = _testClass.IsEnemy();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetSpeed()
        {
            // Arrange
            var testValue = 442489205;

            // Act
            _testClass.Speed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Speed);
        }

        [Fact]
        public void CanSetAndGetDamage()
        {
            // Arrange
            var testValue = 411751532;

            // Act
            _testClass.Damage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Damage);
        }
    }
}