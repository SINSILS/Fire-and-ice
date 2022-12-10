namespace Test._Classes.AbstractFactories
{
    using Client._Classes.AbstractFactories;
    using System;
    using Xunit;
    using Client._Classes.AbstractProducts;

    public class LevelFactoryTests
    {
        private class TestLevelFactory : LevelFactory
        {
            public override Interactable CreateInteractableLever()
            {
                return default(Interactable);
            }

            public override Interactable CreateInteractablePressurePlate()
            {
                return default(Interactable);
            }
        }

        private TestLevelFactory _testClass;

        public LevelFactoryTests()
        {
            _testClass = new TestLevelFactory();
        }
    }
}