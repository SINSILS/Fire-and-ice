namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;

    public class SpeedDemonTests
    {
        private SpeedDemon _testClass;
        private int _speed;
        private int _damage;

        public SpeedDemonTests()
        {
            _speed = 690434536;
            _damage = 797885942;
            _testClass = new SpeedDemon(_speed, _damage);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new SpeedDemon(_speed, _damage);

            // Assert
            Assert.NotNull(instance);
        }
    }
}