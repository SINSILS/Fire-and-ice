namespace Test._Patterns_Designs._Template_Pattern
{
    using Client._Patterns_Designs._Template_Pattern;
    using System;
    using Xunit;

    public class PowerupUpdateTests
    {
        private PowerupUpdate _testClass;

        public PowerupUpdateTests()
        {
            _testClass = new PowerupUpdate();
        }

        [Fact]
        public void CanCallLabelText()
        {
            // Act
            _testClass.LabelText();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}