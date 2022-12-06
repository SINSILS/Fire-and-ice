namespace Client._Patterns_Designs._Composite_Pattern
{
    public abstract class GroupedEnemy
    {
        protected string? Name;
        public GroupedEnemy() { }

        public virtual void Add(GroupedEnemy c)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(GroupedEnemy c)
        {
            throw new NotImplementedException();
        }

        public abstract void Display(int depth);

        public abstract bool IsEnemy();
    }
}
