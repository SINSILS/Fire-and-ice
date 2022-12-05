namespace Client._Patterns_Designs._State_Pattern
{
    public class Door
    {
        public PictureBox picBox;
        State state;
        public Door(State state)
        {
            this.state = state;
        }

        public State State
        {
            get { return state; }
            set
            {
                state = value;
                //Console.WriteLine("State: " + state.GetType().Name);
            }

        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
