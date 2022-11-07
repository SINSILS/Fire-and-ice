namespace Client._Patterns_Designs._Bridge_Pattern
{
    internal class SpeedBoost : PowerUp
    {
        public SpeedBoost(int value)
        {
            this.value = value;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.SpeedBoost;
        }

        public override int GetPowerUpValue()
        {
            return value;
        }
    }
}
