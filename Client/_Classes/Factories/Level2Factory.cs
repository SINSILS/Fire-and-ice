using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.ConcreteProducts;

namespace Client._Classes.Factories
{
    public class Level2Factory : LevelFactory
    {
        public override Interactable CreateInteractableLever()
        {
            return new Lever("Red");
        }

        public override Interactable CreateInteractablePressurePlate()
        {
            return new PressurePlate("Blue");
        }
    }
}
