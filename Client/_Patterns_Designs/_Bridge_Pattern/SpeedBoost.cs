namespace Client._Patterns_Designs._Bridge_Pattern
{
    public class SpeedBoost : PowerUp
    {
        public SpeedBoost(int value)
        {
            this.value = value;
            this.isCollected = false;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.SpeedBoost;
        }

        public override int GetPowerUpValue(int speed)
        {
            int newValue;
            if (speed >= 30)
            {
                newValue = 30;
            }
            else
            {
                newValue = value + speed;

                if (newValue >= 30) newValue = 30;
            }
            return newValue;
        }
    }
}
