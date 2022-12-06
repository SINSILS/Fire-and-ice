namespace Client._Patterns_Designs._Composite_Pattern
{
    public class Army : GroupedEnemy
    {
        List<GroupedEnemy> children = new List<GroupedEnemy>();

        public Army()
        {
        }

        public override void Add(GroupedEnemy enemy)
        {
            children.Add(enemy);
        }

        public override void Remove(GroupedEnemy enemy)
        {
            children.Remove(enemy);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + "Army");

            foreach (GroupedEnemy enemy in children)
            {
                enemy.Display(depth + 1);
            }
        }

        public override bool IsEnemy()
        {
            throw new NotImplementedException();
        }
    }
}
