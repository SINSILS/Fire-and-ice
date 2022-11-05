using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.ConcreteProducts;

namespace Client._Classes.Factories
{
    public class Level3Factory : LevelFactory
    {
        public override Interactable CreateInteractableLever()
        {
            return new Lever("Blue");
        }

        public override Interactable CreateInteractablePressurePlate()
        {
            return new PressurePlate("Red");
        }
    }
}
