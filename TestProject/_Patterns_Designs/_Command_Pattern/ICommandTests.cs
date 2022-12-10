namespace Test._Patterns_Designs._Command_Pattern
{
    using Client._Patterns_Designs._Command_Pattern;
    using System;
    using Xunit;

    public class ICommandTests
    {
        private class TestICommand : ICommand
        {
            public override void Execute()
            {
            }

            public override void Undo()
            {
            }
        }

        private TestICommand _testClass;

        public ICommandTests()
        {
            _testClass = new TestICommand();
        }
    }
}