namespace Client._Patterns_Designs._Bridge_Pattern
{
    public class JumpBoost : PowerUp
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
            if (jumpingHeight == -20)
            {
                newValue = -20;
            }
            else
            {
                newValue = jumpingHeight + this.value;

                if (newValue < -20) newValue = -20;
            }

            return newValue;
        }

    }
}
