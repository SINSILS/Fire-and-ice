using Client._Patterns_Designs._Bridge_Pattern;
using Client._Patterns_Designs._Strategy_Patern;

namespace Client._Classes
{
    public class GamePlayer
    {
        public bool goLeft, goRight, jumping, isGameOver, canPress;
        public int health { get; set; }
        public int jumpSpeed { get; set; }
        public int boostedJumpSpeed;
        public int force { get; set; }
        public int playerSpeed { get; set; }
        public int horizontalSpeed { get; set; }
        public int verticalSpeed { get; set; }

        public bool activePowerUp = false;


        private MoveAlgorithm movementType;
        public GamePlayer(int health, int force, int horizontalSpeed, int verticalSpeed, int jumpSpeed, int playerSpeed)
        {
            this.health = health;
            goLeft = false;
            goRight = false;
            jumping = false;
            isGameOver = false;
            this.force = force;
            this.horizontalSpeed = horizontalSpeed;
            this.verticalSpeed = verticalSpeed;
            this.jumpSpeed = jumpSpeed;
            boostedJumpSpeed = jumpSpeed;
            this.playerSpeed = playerSpeed;
        }

        public MoveAlgorithm GetMovement()
        {
            return movementType;
        }

        public void SetMovement(MoveAlgorithm moveType)
        {
            movementType = moveType;
        }

        public void MovementAction(GamePlayer player)
        {
            movementType.DoMovement(player);
        }

        public void LowerHealth(int value)
        {
            health -= value;
        }

        public void ApplyPowerUp(PowerUp powerUp)
        {
            PowerUpType type = powerUp.GetPowerUpType();

            switch (type)
            {
                case PowerUpType.SpeedBoost:
                    int newSpeed = powerUp.GetPowerUpValue(playerSpeed);
                    playerSpeed = newSpeed;
                    SetMovement(new EnhancedMovement());
                    //MovementAction(this);
                    activePowerUp = true;
                    break;
                case PowerUpType.Healing:
                    int newHealth = powerUp.GetPowerUpValue(health);
                    health = newHealth;
                    break;
                case PowerUpType.JumpBoost:
                    int newJumpheight = powerUp.GetPowerUpValue(boostedJumpSpeed);
                    boostedJumpSpeed = newJumpheight;
                    SetMovement(new EnhancedMovement());
                    // MovementAction(this);
                    activePowerUp = true;
                    break;
            }
        }

        public void RemovePowerUp()
        {
            SetMovement(new NormalMovement());
            MovementAction(this);
            activePowerUp = false;
        }
    }
}