using Client._Classes.AbstractProducts;

namespace Client._Classes.ConcreteProducts
{
    public class PressurePlate : Interactable
    {
        public PressurePlate(bool isActivated = false)
        {
            this.isActivated = isActivated;
        }
    }
}
