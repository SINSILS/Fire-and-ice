using Client._Patterns_Designs._Bridge_Pattern;

namespace Client._Patterns_Designs._Iterator
{
    public abstract class Iterator
    {
        public abstract PowerUp First();
        public abstract PowerUp Next();
        public abstract bool IsDone();
        public abstract PowerUp CurrentItem();
    }
}
