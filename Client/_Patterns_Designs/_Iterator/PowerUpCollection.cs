using Client._Patterns_Designs._Bridge_Pattern;

namespace Client._Patterns_Designs._Iterator
{
    public class PowerUpCollection : IAbstractCollection
    {
        List<PowerUp> items = new List<PowerUp>();
        public override Iterator CreateIterator()
        {
            return new PowerUpIterator(this);
        }
        // Get item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public PowerUp this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }
}
