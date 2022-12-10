namespace Test._Classes.Factories
{
    using Client._Classes.Factories;
    using System;
    using Xunit;

    public class Level3FactoryTests
    {
        private Level3Factory _testClass;

        public Level3FactoryTests()
        {
            _testClass = new Level3Factory();
        }

        [Fact]
        public void CanCallCreateInteractableLever()
        {
            // Act
            var result = _testClass.CreateInteractableLever();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallCreateInteractablePressurePlate()
        {
            // Act
            var result = _testClass.CreateInteractablePressurePlate();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}