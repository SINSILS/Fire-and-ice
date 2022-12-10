namespace Test._Patterns_Designs._State_Pattern
{
    using Client._Patterns_Designs._State_Pattern;
    using System;
    using Xunit;

    public class StateTests
    {
        private class TestState : State
        {
            public override void Handle(Door door)
            {
            }
        }

        private TestState _testClass;

        public StateTests()
        {
            _testClass = new TestState();
        }
    }
}