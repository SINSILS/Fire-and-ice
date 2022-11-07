using Client._Classes;

namespace Client._Patterns_Designs._Strategy_Patern
{
    public class NormalMovement : MoveAlgorithm
    {
        public override void DoMovement(GamePlayer player)
        {
            player.jumpSpeed = -8;
            player.playerSpeed = 7;
        }
    }
}
