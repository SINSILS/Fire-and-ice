namespace Client
{
    public class GamePlayer
    {
        public bool goLeft, goRight, jumping, isGameOver;

        public int jumpSpeed { get; set; }
        public int force { get; set; }
        public int score { get; set; }
        public int playerSpeed { get; set; }

        public int horizontalSpeed { get; set; }
        public int verticalSpeed { get; set; }

        public GamePlayer(bool goLeft, bool goRight, bool jumping, bool isGameOver, int jumpSpeed, int force, int score, int playerSpeed, int horizontalSpeed, int verticalSpeed)
        {
            this.goLeft = goLeft;
            this.goRight = goRight;
            this.jumping = jumping;
            this.isGameOver = isGameOver;
            this.jumpSpeed = jumpSpeed;
            this.force = force;
            this.score = score;
            this.playerSpeed = playerSpeed;
            this.horizontalSpeed = horizontalSpeed;
            this.verticalSpeed = verticalSpeed;
        }

    }
}