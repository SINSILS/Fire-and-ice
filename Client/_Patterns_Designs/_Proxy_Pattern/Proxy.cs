using Client._Patterns_Designs._State_Pattern;

namespace Client._Patterns_Designs._Proxy_Pattern
{
    public class Proxy : IDoor
    {
        private Door realDoor;
        public override void createDoor(State state)
        {
            if (realDoor == null)
            {
                realDoor = new Door(state);
            }
        }

        public override void Request()
        {
            realDoor.Request();
        }

        public override void setPicBox(PictureBox pickBox)
        {
            realDoor.setPicBox(pickBox);
        }
        public override PictureBox getPicBox()
        {
            return realDoor.getPicBox();
        }
        public override State getState()
        {
            return realDoor.getState();
        }

        public override void setState(State state)
        {
            realDoor.setState(state);
        }
    }
}
