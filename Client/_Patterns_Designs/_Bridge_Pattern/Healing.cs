namespace Client._Patterns_Designs._Bridge_Pattern
{
    public class Healing : PowerUp
    {
        public Healing(int value)
        {
            this.value = value;
            this.isCollected = false;
        }

        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.Healing;
        }

        public override int GetPowerUpValue(int health)
        {
            int newValue;
            if (health == 3)
            {
                newValue = 3;
            }
            else if (health <= 0)
            {
                newValue = 0;
            }
            else
            {
                newValue = health + value;
            }

            return newValue;
        }

    }
}
