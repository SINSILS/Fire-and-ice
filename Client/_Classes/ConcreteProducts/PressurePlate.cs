using Client._Classes.AbstractProducts;

namespace Client._Classes.ConcreteProducts
{
    public class PressurePlate : Interactable
    {
        public PressurePlate(string color, bool isActivated = false)
        {
            this.isActivated = isActivated;
            this.color = color;
        }
    }
}
