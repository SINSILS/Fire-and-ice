namespace Client._Classes.AbstractProducts
{
    public abstract class Interactable
    {
        enum Color
        {
            Red,
            Blue,
            None
        }
        
        public bool isActivated { get; set; }
        public Color color {get; set;}

        public 

        public void SetActivated(bool state)
        {
            isActivated = state;
        }
    }
}
