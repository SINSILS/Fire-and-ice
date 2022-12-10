namespace Test._Patterns_Designs._Template_Pattern
{
    using Client._Patterns_Designs._Template_Pattern;
    using System;
    using Xunit;

    public class TwoCoinUpdateTests
    {
        private TwoCoinUpdate _testClass;

        public TwoCoinUpdateTests()
        {
            _testClass = new TwoCoinUpdate();
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