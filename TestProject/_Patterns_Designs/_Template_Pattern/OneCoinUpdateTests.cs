namespace Test._Patterns_Designs._Template_Pattern
{
    using Client._Patterns_Designs._Template_Pattern;
    using System;
    using Xunit;

    public class OneCoinUpdateTests
    {
        private OneCoinUpdate _testClass;

        public OneCoinUpdateTests()
        {
            _testClass = new OneCoinUpdate();
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