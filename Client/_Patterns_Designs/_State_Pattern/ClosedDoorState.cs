namespace Client._Patterns_Designs._State_Pattern
{
    public class ClosedDoorState : State
    {
        public override void Handle(Door door)
        {
            door.setState(new OpenDoorState());
            door.getPicBox().BackColor = Color.Green;
        }
    }
}
