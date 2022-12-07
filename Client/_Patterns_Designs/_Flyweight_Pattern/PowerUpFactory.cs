using Client._Patterns_Designs._Bridge_Pattern;

namespace Client._Patterns_Designs._Flyweight_Pattern
{
    public class PowerUpFactory
    {
        private Dictionary<string, PowerUp> powerUps { get; set; } = new Dictionary<string, PowerUp>();

        public PowerUpFactory() { }

        public PowerUp GetPowerUp(string key)
        {
            if (powerUps.ContainsKey(key)) return powerUps[key];
            PowerUp powerUp = AddPowerUp(key);
            powerUps.Add(key, powerUp);
            return powerUp;
        }

        public PowerUp AddPowerUp(string key)
        {
            string[] parts = key.Split(' ');
            PowerUp powerUp = null;

            switch (parts[0])
            {
                case "SpeedBoost":
                    powerUp = new SpeedBoost(int.Parse(parts[1]));
                    break;
                case "Healing":
                    powerUp = new Healing(int.Parse(parts[1]));
                    break;
                case "JumpBoost":
                    powerUp = new JumpBoost(int.Parse(parts[1]));
                    break;
                default:
                    powerUp = new SpeedBoost(10);
                    break;
            }

            return powerUp;
        }
    }
}
