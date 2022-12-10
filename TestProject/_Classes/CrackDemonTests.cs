namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;

    public class CrackDemonTests
    {
        private CrackDemon _testClass;
        private int _speed;
        private int _damage;

        public CrackDemonTests()
        {
            _speed = 845325551;
            _damage = 1665236466;
            _testClass = new CrackDemon(_speed, _damage);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CrackDemon(_speed, _damage);

            // Assert
            Assert.NotNull(instance);
        }
    }
}