namespace Test._Patterns_Designs._Template_Pattern
{
    using Client._Patterns_Designs._Template_Pattern;
    using System;
    using Xunit;

    public class ThreeCoinUpdateTests
    {
        private ThreeCoinUpdate _testClass;

        public ThreeCoinUpdateTests()
        {
            _testClass = new ThreeCoinUpdate();
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