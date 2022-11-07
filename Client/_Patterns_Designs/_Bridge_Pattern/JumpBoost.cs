namespace Client._Patterns_Designs._Bridge_Pattern
{
    internal class JumpBoost : PowerUp
    {
        public JumpBoost(int value)
        {
            this.value = value;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.JumpBoost;
        }

        public override int GetPowerUpValue()
        {
            return value;
        }
    }
}
