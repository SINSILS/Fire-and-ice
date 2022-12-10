namespace Test._Patterns_Designs._Iterator
{
    using Client._Patterns_Designs._Iterator;
    using System;
    using Xunit;

    public class PowerUpIteratorTests
    {
        private PowerUpIterator _testClass;
        private PowerUpCollection _powerUpCollection;

        public PowerUpIteratorTests()
        {
            _powerUpCollection = new PowerUpCollection();
            _testClass = new PowerUpIterator(_powerUpCollection);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PowerUpIterator(_powerUpCollection);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPowerUpCollection()
        {
            Assert.Throws<ArgumentNullException>(() => new PowerUpIterator(default(PowerUpCollection)));
        }

        [Fact]
        public void CanCallFirst()
        {
            // Act
            var result = _testClass.First();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallNext()
        {
            // Act
            var result = _testClass.Next();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallCurrentItem()
        {
            // Act
            var result = _testClass.CurrentItem();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallIsDone()
        {
            // Act
            var result = _testClass.IsDone();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallResetIterator()
        {
            // Act
            _testClass.ResetIterator();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}