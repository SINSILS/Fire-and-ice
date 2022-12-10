namespace Test._Patterns_Designs._Iterator
{
    using Client._Patterns_Designs._Iterator;
    using System;
    using Xunit;

    public class IAbstractCollectionTests
    {
        private class TestIAbstractCollection : IAbstractCollection
        {
            public override Iterator CreateIterator()
            {
                return default(Iterator);
            }

            public override void ResetItemState()
            {
            }
        }

        private TestIAbstractCollection _testClass;

        public IAbstractCollectionTests()
        {
            _testClass = new TestIAbstractCollection();
        }
    }
}