using Client._Classes;

namespace Client._Patterns_Designs._Strategy_Patern
{
    public class EnhancedMovement : MoveAlgorithm
    {
        public override void DoMovement(GamePlayer player)
        {
            player.jumpSpeed = player.boostedJumpSpeed;
            player.playerSpeed = player.playerSpeed;
        }
    }
}
