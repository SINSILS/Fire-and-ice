namespace Client._Patterns_Designs._Bridge_Pattern
{
    internal class JumpBoost : PowerUp
    {
        public JumpBoost(int value)
        {
            this.value = value;
            this.isCollected = false;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.JumpBoost;
        }

        public override int GetPowerUpValue(int jumpingHeight)
        {
            int newValue;
            if (jumpingHeight == 15)
            {
                newValue = 15;
            }
            else
            {
                newValue = jumpingHeight + value;

                if (newValue >= 15) newValue = 15;
            }

            return newValue;
        }

    }
}
