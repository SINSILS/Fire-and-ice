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

        //public State State
        //{
        //    get { return state; }
        //    set
        //    {
        //        state = value;
        //        //Console.WriteLine("State: " + state.GetType().Name);
        //    }
        //}

        public override void createDoor(State state)
        {
            Door newDoor = new Door(state);
            //return newDoor;
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
