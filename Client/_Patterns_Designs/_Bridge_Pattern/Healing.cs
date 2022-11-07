namespace Client._Patterns_Designs._Bridge_Pattern
{
    internal class Healing : PowerUp
    {
        public Healing(int value)
        {
            this.value = value;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.Healing;
        }

        public override int GetPowerUpValue()
        {
            return value;
        }
    }
}
