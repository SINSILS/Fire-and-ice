namespace Test._Patterns_Designs._Iterator
{
    using Client._Patterns_Designs._Bridge_Pattern;
    using Client._Patterns_Designs._Iterator;
    using System;
    using Xunit;

    public class PowerUpCollectionTests
    {
        private PowerUpCollection _testClass;

        public PowerUpCollectionTests()
        {
            _testClass = new PowerUpCollection();
        }

        [Fact]
        public void CanCallCreateIterator()
        {
            // Act
            var result = _testClass.CreateIterator();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallResetItemState()
        {
            // Act
            _testClass.ResetItemState();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanGetCount()
        {
            // Assert
            Assert.IsType<int>(_testClass.Count);

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetIndexer()
        {
            var testValue = new Healing(10);
            Assert.IsType<PowerUp>(_testClass[798087698]);
            _testClass[798087698] = testValue;
            Assert.Same(testValue, _testClass[798087698]);
        }
    }
}