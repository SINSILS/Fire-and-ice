using Client._Patterns_Designs._Bridge_Pattern;

namespace Client._Patterns_Designs._Iterator
{
    public class PowerUpIterator : Iterator
    {
        PowerUpCollection aggregate;
        int current = 0;

        // Constructor
        public PowerUpIterator(PowerUpCollection aggregate)
        {
            this.aggregate = aggregate;
        }

        // Gets first iteration item
        public override PowerUp First()
        {
            return aggregate[0];
        }

        // Gets next iteration item
        public override PowerUp Next()
        {
            PowerUp ret = null;

            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }

            return ret;
        }

        // Gets current iteration item
        public override PowerUp CurrentItem()
        {
            return aggregate[current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}
