using Client._Patterns_Designs._State_Pattern;

namespace Client._Patterns_Designs._Proxy_Pattern
{
    public abstract class IDoor
    {
        public abstract void Request();
        public abstract void createDoor(State state);
        public abstract void setPicBox(PictureBox pickBox);
        public abstract PictureBox getPicBox();
        public abstract void setState(State state);
        public abstract State getState();
    }
}
