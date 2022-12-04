namespace Client._Patterns_Designs._State_Pattern
{
    public class OpenDoorState : State
    {
        public override void Handle(Door door)
        {
            door.State = new ClosedDoorState();
            door.picBox.BackColor = Color.Red;
        }
    }
}
