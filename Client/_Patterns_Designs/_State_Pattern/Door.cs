using Client._Patterns_Designs._Proxy_Pattern;

namespace Client._Patterns_Designs._State_Pattern
{
    public class Door : IDoor
    {
        private PictureBox? picBox;
        State state;
        public Door(State state)
        {
            this.state = state;
        }

        public override void createDoor(State state)
        {
            Door newDoor = new Door(state);
        }

        public override void Request()
        {
            state.Handle(this);
        }

        public override void setPicBox(PictureBox pickBox)
        {
            this.picBox = pickBox;
        }

        public override PictureBox getPicBox()
        {
            return picBox;
        }
        public override State getState()
        {
            return state;
        }

        public override void setState(State state)
        {
            this.state = state;
        }
    }
}
