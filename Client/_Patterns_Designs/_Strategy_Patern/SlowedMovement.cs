using Client._Classes;

namespace Client._Patterns_Designs._Strategy_Patern
{
    public class SlowedMovement : MoveAlgorithm
    {

        public override void DoMovement(GamePlayer player)
        {
            player.jumpSpeed = -4;
            player.playerSpeed = 2;
        }

    }
}
