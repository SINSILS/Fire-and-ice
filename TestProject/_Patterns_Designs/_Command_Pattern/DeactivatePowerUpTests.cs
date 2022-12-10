namespace Test._Patterns_Designs._Command_Pattern
{
    using Client._Patterns_Designs._Command_Pattern;
    using System;
    using Xunit;

    public class DeactivatePowerUpTests
    {
        private DeactivatePowerUp _testClass;

        public DeactivatePowerUpTests()
        {
            _testClass = new DeactivatePowerUp();
        }

        [Fact]
        public void CanCallExecute()
        {
            // Act
            _testClass.Execute();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUndo()
        {
            // Act
            _testClass.Undo();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}