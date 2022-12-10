using Client._Patterns_Designs._Proxy_Pattern;

namespace Client._Patterns_Designs._State_Pattern
{
    public class Door : IDoor
    {
        private PictureBox? picBox;
        State state;
        public Door(State state)
        {
            if (state != null)
            {
                this.state = state;
            }
            else
                throw new ArgumentNullException();
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
            if (pickBox == null) { throw new ArgumentNullException(); }
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
            if (state == null) { throw new ArgumentNullException(); }
            this.state = state;
        }
    }
}
