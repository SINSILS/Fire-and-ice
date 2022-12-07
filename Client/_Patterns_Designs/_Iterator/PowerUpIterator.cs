using Client._Patterns_Designs._Bridge_Pattern;

namespace Client._Patterns_Designs._Iterator
{
    public class PowerUpIterator : Iterator
    {
        PowerUpCollection powerUpCollection;
        int current = 0;

        // Constructor
        public PowerUpIterator(PowerUpCollection powerUpCollection)
        {
            this.powerUpCollection = powerUpCollection;
        }

        // Gets first iteration item
        public override PowerUp First()
        {
            return powerUpCollection[0];
        }

        // Gets next iteration item
        public override PowerUp Next()
        {
            PowerUp ret = null;

            if (current < powerUpCollection.Count - 1)
            {
                ret = powerUpCollection[++current];
            }

            return ret;
        }

        // Gets current iteration item
        public override PowerUp CurrentItem()
        {
            return powerUpCollection[current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return current >= powerUpCollection.Count;
        }

        public override void ResetIterator()
        {
            current = 0;
            powerUpCollection.ResetItemState();
        }
    }
}
