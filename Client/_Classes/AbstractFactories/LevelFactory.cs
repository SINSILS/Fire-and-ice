using Client._Classes.AbstractProducts;

namespace Client._Classes.AbstractFactories
{
    public abstract class LevelFactory
    {
        public abstract Interactable CreateInteractableLever();
        public abstract Interactable CreateInteractablePressurePlate();
    }   
}
