namespace Client._Classes.Factories
{
    public class EnemyFactory
    {
        public static Enemy getEnemy(string type)
        {
            Enemy enemy;

            switch (type)
            {
                case "SpeedDemon":
                    enemy = new SpeedDemon(5, 1);
                    break;
                case "CrackDemon":
                    enemy = new CrackDemon(1, 3);
                    break;
                default:
                    enemy = new SpeedDemon(5, 1);
                    break;
            }

            return enemy;
        }

    }
}
