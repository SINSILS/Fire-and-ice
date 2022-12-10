namespace Test._Patterns_Designs._Strategy_Patern
{
    using Client._Patterns_Designs._Strategy_Patern;
    using System;
    using Xunit;
    using Client._Classes;

    public class MoveAlgorithmTests
    {
        private class TestMoveAlgorithm : MoveAlgorithm
        {
            public override void DoMovement(GamePlayer player)
            {
            }
        }

        private TestMoveAlgorithm _testClass;

        public MoveAlgorithmTests()
        {
            _testClass = new TestMoveAlgorithm();
        }
    }
}