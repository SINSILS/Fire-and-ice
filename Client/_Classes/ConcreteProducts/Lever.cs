using Client._Classes.AbstractProducts;

namespace Client._Classes.ConcreteProducts
{
    public class Lever : Interactable
    {
        public Lever(string color, bool isActivated = false)
        {
            this.isActivated = isActivated;
            this.color = color;
        }
    }
}
