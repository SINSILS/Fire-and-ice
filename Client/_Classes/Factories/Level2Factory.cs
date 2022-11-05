using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.ConcreteProducts;

namespace Client._Classes.Factories
{
    public class LeverFactory : InteractableFactory
    {
        public override CreateInteractableLever()
        {
            return new Lever("Red");
        }

        public override CreateInteractablePressurePlate()
        {
            return new PressurePlate("Blue");
        }
    }
}
