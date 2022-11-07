namespace Client._Patterns_Designs._Bridge_Pattern
{
    public enum PowerUpType
    {
        Healing,
        SpeedBoost,
        JumpBoost,
    }

    public abstract class PowerUp
    {
        protected int value;
        public bool isCollected;
        public abstract PowerUpType GetPowerUpType();
        public abstract int GetPowerUpValue(int startingValue);
    }
}
