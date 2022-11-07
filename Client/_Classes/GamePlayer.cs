using Client._Patterns_Designs._Strategy_Patern;

namespace Client._Classes
{
    public class GamePlayer
    {
        public bool goLeft, goRight, jumping, isGameOver, canPress;
        public int health { get; set; }
        public int score { get; set; }


        public static int jumpSpeed { get; set; }
        public int force { get; set; }
        public static int playerSpeed { get; set; }
        public int horizontalSpeed { get; set; }
        public int verticalSpeed { get; set; }



        private MoveAlgorithm moveventType;

        //public GamePlayer(int health, bool goLeft, bool goRight, bool jumping, bool isGameOver, int jumpSpeed, int force, int score, int playerSpeed, int horizontalSpeed, int verticalSpeed)


        public GamePlayer(int health, bool goLeft, bool goRight, bool jumping, bool isGameOver, int score, int force, int horizontalSpeed, int verticalSpeed)
        {
            this.health = health;
            this.goLeft = goLeft;
            this.goRight = goRight;
            this.jumping = jumping;
            this.isGameOver = isGameOver;
            this.score = score;
            this.force = force;
            this.horizontalSpeed = horizontalSpeed;
            this.verticalSpeed = verticalSpeed;
            //this.jumpSpeed = jumpSpeed;
            //this.force = force;
            //this.playerSpeed = playerSpeed;
            //this.horizontalSpeed = horizontalSpeed;
            //this.verticalSpeed = verticalSpeed;
        }


        public MoveAlgorithm GetMovement()
        {
            return moveventType;
        }

        public void SetMovement(MoveAlgorithm moveType)
        {
            this.moveventType = moveType;
        }

        public void MovementAction()
        {
            this.moveventType.DoMovement();
        }

        public void LowerHealth(int value)
        {
            health -= value;
        }

        public void IncreaseScore(int value)
        {
            score = score + value;
        }

    }
}