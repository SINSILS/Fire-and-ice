namespace Test._Patterns_Designs._Adapter_Pattern
{
    using Client._Classes;
    using Client._Patterns_Designs._Adapter_Pattern;
    using System;
    using Xunit;

    public class FakeCoinAdapterTests
    {
        private FakeCoinAdapter _testClass;
        private Coin _coin;

        public FakeCoinAdapterTests()
        {
            _coin = new Coin();
            _testClass = new FakeCoinAdapter(_coin);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new FakeCoinAdapter(_coin);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullCoin()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeCoinAdapter(default(Coin)));
        }

        [Fact]
        public void CanCallisFake()
        {
            // Act
            _testClass.isFake();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallgetValue()
        {
            // Act
            var result = _testClass.getValue();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}