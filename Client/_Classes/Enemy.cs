using Client._Patterns_Designs._Composite_Pattern;

namespace Client._Classes
{
    public class Enemy : GroupedEnemy
    {
        public int Speed { get; set; }
        public int Damage { get; set; }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);
        }

        public override bool IsEnemy()
        {
            return true;
        }
    }
}
