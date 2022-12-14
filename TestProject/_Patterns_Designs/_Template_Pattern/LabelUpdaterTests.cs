using Client._Patterns_Designs._Visitor_Pattern;

namespace Test._Patterns_Designs._Template_Pattern
{
    using Client._Patterns_Designs._Template_Pattern;
    using System;
    using Xunit;

    public class LabelUpdaterTests
    {
        private class TestLabelUpdater : LabelUpdater
        {
            public override void LabelText()
            {
            }

            public override string Accept(Visitor visitor)
            {
                throw new NotImplementedException();
            }
        }

        private TestLabelUpdater _testClass;

        public LabelUpdaterTests()
        {
            _testClass = new TestLabelUpdater();
        }

        [Fact]
        public void CanCallUpdate()
        {
            // Act
            _testClass.Update();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}