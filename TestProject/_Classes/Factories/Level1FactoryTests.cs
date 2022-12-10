namespace Test._Classes.Factories
{
    using Client._Classes.Factories;
    using System;
    using Xunit;

    public class Level1FactoryTests
    {
        private Level1Factory _testClass;

        public Level1FactoryTests()
        {
            _testClass = new Level1Factory();
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