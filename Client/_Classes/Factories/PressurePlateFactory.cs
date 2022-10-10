using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.ConcreteProducts;

namespace Client._Classes.Factories
{
    public class PressurePlateFactory : InteractableFactory
    {
        public override Interactable CreateInteractable()
        {
            return new PressurePlate();
        }
    }
}
