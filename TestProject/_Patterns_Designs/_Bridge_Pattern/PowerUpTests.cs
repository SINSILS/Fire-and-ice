namespace Test._Patterns_Designs._Bridge_Pattern
{
    using Client._Patterns_Designs._Bridge_Pattern;
    using System;
    using Xunit;

    public class PowerUpTests
    {
        private class TestPowerUp : PowerUp
        {
            public override PowerUpType GetPowerUpType()
            {
                return default(PowerUpType);
            }

            public override int GetPowerUpValue(int startingValue)
            {
                return default(int);
            }
        }

        private TestPowerUp _testClass;

        public PowerUpTests()
        {
            _testClass = new TestPowerUp();
        }
    }
}