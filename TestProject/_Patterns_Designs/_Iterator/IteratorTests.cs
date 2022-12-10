namespace Test._Patterns_Designs._Iterator
{
    using Client._Patterns_Designs._Iterator;
    using System;
    using Xunit;
    using Client._Patterns_Designs._Bridge_Pattern;

    public class IteratorTests
    {
        private class TestIterator : Iterator
        {
            public override PowerUp First()
            {
                return default(PowerUp);
            }

            public override PowerUp Next()
            {
                return default(PowerUp);
            }

            public override bool IsDone()
            {
                return default(bool);
            }

            public override PowerUp CurrentItem()
            {
                return default(PowerUp);
            }

            public override void ResetIterator()
            {
            }
        }

        private TestIterator _testClass;

        public IteratorTests()
        {
            _testClass = new TestIterator();
        }
    }
}