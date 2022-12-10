namespace Test._Patterns_Designs._Builder_Patern
{
    using Client._Patterns_Designs._Builder_Patern;
    using Xunit;
    using System;

    public class GreenCoinBuilderTests
    {
        private GreenCoinBuilder _testClass;

        public GreenCoinBuilderTests()
        {
            _testClass = new GreenCoinBuilder();
        }

        [Fact]
        public void CanCallAddRing()
        {
            // Act
            _testClass.AddRing();

            // Assert
            Assert.Equal(1, _testClass.GetCoin().Parts.Count);
        }

        [Fact]
        public void CanCallAddNeckless()
        {
            // Act
            _testClass.AddNeckless();

            // Assert
            Assert.Equal(1, _testClass.GetCoin().Parts.Count);
        }

        [Fact]
        public void CanCallAddCrown()
        {
            // Act
            _testClass.AddCrown();

            // Assert
            Assert.Equal(1, _testClass.GetCoin().Parts.Count);
        }

        [Fact]
        public void CanCallGetCoin()
        {
            // Act
            var result = _testClass.GetCoin();

            // Assert
            Assert.True(result != null);
        }
    }
}