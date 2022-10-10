using Client._Classes.AbstractProducts;

namespace Client._Classes.ConcreteProducts
{
    public class Lever : Interactable
    {
        public Lever(bool isActivated = false)
        {
            this.isActivated = isActivated;
        }
    }
}
