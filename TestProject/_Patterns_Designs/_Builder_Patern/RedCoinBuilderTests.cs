namespace Test._Patterns_Designs._Builder_Patern
{
    using Client._Patterns_Designs._Builder_Patern;
    using System;
    using Xunit;

    public class RedCoinBuilderTests
    {
        private RedCoinBuilder _testClass;

        public RedCoinBuilderTests()
        {
            _testClass = new RedCoinBuilder();
        }

        [Fact]
        public void CanCallAddRing()
        {
            // Act
            _testClass.AddRing();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallAddNeckless()
        {
            // Act
            _testClass.AddNeckless();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallAddCrown()
        {
            // Act
            _testClass.AddCrown();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetCoin()
        {
            // Act
            var result = _testClass.GetCoin();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}