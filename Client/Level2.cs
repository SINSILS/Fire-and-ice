using Client._Classes;
using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.Factories;
using Client._Patterns_Designs._Adapter_Pattern;
using Client._Patterns_Designs._Builder_Patern;
using Client._Patterns_Designs._Decorator_Pattern;
using Client._Patterns_Designs._Interpreter;
using Client._Patterns_Designs._Proxy_Pattern;
using Client._Patterns_Designs._State_Pattern;
using Client._Patterns_Designs._Strategy_Patern;
using Client._Patterns_Designs._Template_Pattern;
using Client._Patterns_Designs._Visitor_Pattern;
using Client._Patterns_Designs.Observer;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class Level2 : Form
    {
        private HubConnection connection;

        GamePlayer playerStats = new GamePlayer(3, 0, 5, 3, -8, 7);
        Enemy enemy = EnemyFactory.getEnemy("SpeedDemon");
        Dictionary<string, Coin> coins = new Dictionary<string, Coin>();
        Score score = Score.getInstance();
        PictureBox player;

        bool CanPress;

        LevelFactory levelFactory = new Level1Factory();
        Interactable lever;

        ObserverHelper observer1 = new ObserverHelper("Observer I");
        ObserverHandler provider = new ObserverHandler();

        Obstacle obs, clone;

        int speed;
        LabelUpdater onecoiner = new OneCoinUpdate();
        LabelUpdater twocoiner = new TwoCoinUpdate();
        LabelUpdater threecoiner = new ThreeCoinUpdate();

        Proxy doors = new Proxy();

        Expression[] expressions = new Expression[]
{
    new TenExpression(),
    new OneExpression(),
};

         TextVisitor textVisitor;

        public Level2()
        {
            InitializeComponent();
            DoubleBuffered = true;
            player = player1;
            AsignPlayers();
            buildCoins();
            lever = levelFactory.CreateInteractableLever();
            gameTimer2.Start();

            observer1.Subscribe(provider);

            provider.AddApplication(lever);
            observer1.List();

            // PictureBox a = CreatePicBoxDyn(Color.Black, 50, 50, 300, 300, "obstacle");
            // PictureBox b = CreatePicBoxDyn(Color.DeepPink, 50, 50, 350, 350, "obstacle");

            PictureBox platform = CreatePicBoxDyn(Color.AliceBlue, 148, 35, 699, 500, "platform");
            //obs = new(a, 5);

            //GCHandle objHandle = GCHandle.Alloc(obs, GCHandleType.WeakTrackResurrection);
            //long address = GCHandle.ToIntPtr(objHandle).ToInt64();

            //Console.WriteLine("Adress of first obstacle: " + address.ToString());

            //Console.WriteLine("Obstacle 1 damage: " + obs.Damage.ToString());
            ////clone = (Obstacle)obs.DeepCopy();

            //GCHandle objHandle1 = GCHandle.Alloc(clone, GCHandleType.WeakTrackResurrection);
            //long address1 = GCHandle.ToIntPtr(objHandle1).ToInt64();
            //Console.WriteLine("Adress of cloned:" + address1.ToString());

            //clone.pic = b;


            // b.Tag = "clone";
            //clone.Damage = 0;
            //Console.WriteLine("Cloned obstacle damage: " + clone.Damage.ToString());


            textVisitor = new TextVisitor();
            IPlatform createdPlatform = new Platform(platform);
            createdPlatform.CreatePlatform();

            HorizontalPlatformDecorator horizontal = new HorizontalPlatformDecorator(createdPlatform);
            horizontal.CreatePlatform();
            speed = horizontal.Speed;


            IPlatform createdPlatform2 = new Platform();
            VerticalPlatformDecorator vertical = new VerticalPlatformDecorator(createdPlatform2);
            vertical.CreatePlatform();

            doors.createDoor(new ClosedDoorState());
            doors.setPicBox(door);
        }
        private async void AsignPlayers()
        {
            int playerIndex;
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();
            connection.On<string>("asigningPlayers", (message) =>
            {
                if (message == "1")
                {
                    playerIndex = int.Parse(message);
                    playerLabel.Text = message;
                    label1.Text = "Ice Girl";
                    player = player1;
                    ////cia galima pakeist: new NormalMovement() arba new SlowedMovement()
                    playerStats.SetMovement(new EnhancedMovement());
                    playerStats.MovementAction(playerStats);

                }
                else
                {
                    playerIndex = int.Parse(message);
                    playerLabel.Text = message;
                    label1.Text = "Fire Boy";
                    player = player2;
                    ////cia pakeist: new EnhancedMovement() arba new SlowedMovement()
                    playerStats.SetMovement(new NormalMovement());
                    playerStats.MovementAction(playerStats);
                }
            });
            await connection.SendAsync("AsignPlayer", "");
        }

        private void gameTimer2_TickAsync(object sender, EventArgs e)
        {
            //txtScore.Text = "Score: " + score.value;
            var context = new Context(score.value);
            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }

            Console.WriteLine(context.Output);
            txtScore.Text = "Score: " + context.Output;

            player.Top += playerStats.jumpSpeed;

            if (playerStats.goLeft == true)
            {
                player.Left -= playerStats.playerSpeed;
            }
            if (playerStats.goRight == true)
            {
                player.Left += playerStats.playerSpeed;
            }

            if (playerStats.jumping == true && playerStats.force < 0)
            {
                playerStats.jumping = false;
            }

            if (playerStats.jumping == true)
            {
                playerStats.MovementAction(playerStats);
                playerStats.force -= 1;
            }
            else
            {
                playerStats.jumpSpeed = 10;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            playerStats.force = 8;
                            player.Top = x.Top - player.Height;


                            if ((string)x.Name == "horizontalPlatform" && playerStats.goLeft == false || (string)x.Name == "horizontalPlatform" && playerStats.goRight == false)
                            {
                                player.Left -= playerStats.horizontalSpeed;
                            }
                        }

                        x.BringToFront();
                    }

                    if ((string)x.Tag == "Horizontal")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            playerStats.force = 8;
                            player.Top = x.Top - player.Height;
                            player.Left -= playerStats.horizontalSpeed;
                        }

                        x.BringToFront();
                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            coins[x.Name].setInvisible();
                            score.increaseScore(coins[x.Name].value);
                            string text;
                            if (coins[x.Name].value == 1)
                            {
                                text = onecoiner.Accept(textVisitor);
                                onecoiner.Update(text);
                            }
                            if (coins[x.Name].value == 2)
                            {
                                text = twocoiner.Accept(textVisitor);
                                twocoiner.Update(text);
                            }

                            if (coins[x.Name].value == 3)
                            {
                                text = threecoiner.Accept(textVisitor);
                                threecoiner.Update(text);
                            }
                            SendCoinsState_Async(x.Name);
                            txtScore.Refresh();
                        }
                    }

                    if ((string)x.Tag == "obstacle")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            //gameTimer.Stop();
                            //playerStats.isGameOver = true;
                            //txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                            player.Left = 593;
                            player.Top = 564;
                            playerStats.LowerHealth(obs.Damage);
                        }

                    }

                    if ((string)x.Tag == "clone")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            //gameTimer.Stop();
                            //playerStats.isGameOver = true;
                            //txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                            player.Left = 593;
                            player.Top = 564;
                            playerStats.LowerHealth(clone.Damage);
                        }

                    }
                }
            }
            horizontalPlatform.Left -= playerStats.horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                playerStats.horizontalSpeed = playerStats.horizontalSpeed * -1;
            }

            foreach (var pb in this.Controls
                                .OfType<PictureBox>()
                                .Where(x => (string)x.Tag == "Horizontal")
                                .ToList())
            {
                pb.Left -= speed;

                if (pb.Left < 0 || pb.Left + pb.Width > this.ClientSize.Width)
                {
                    playerStats.horizontalSpeed = playerStats.horizontalSpeed * -1;
                }
            }

            verticalPlatform.Top += playerStats.verticalSpeed * -1;

            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 581)
            {
                playerStats.verticalSpeed = playerStats.verticalSpeed * -1;
            }

            if ((score.value == 67 || score.value == 31) && doors.getState().GetType().Name == "ClosedDoorState")
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                doors.Request();
            }

            if (score.value == 67)
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
            }

            if (score.value < 32)
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Collect coins to complete the quest!";
            }


            if (player1.Bounds.IntersectsWith(doors.getPicBox().Bounds) && doors.getState().GetType().Name == "OpenDoorState")
            {
                // gameTimer.Stop();
                //playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                Level3 newLevel = new Level3();
                player1.Visible = false;
                this.Hide();
                gameTimer2.Stop();
                newLevel.Show();
            }
            if (player2.Bounds.IntersectsWith(doors.getPicBox().Bounds) && doors.getState().GetType().Name == "OpenDoorState")
            {
                // gameTimer.Stop();
                //playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                Level3 newLevel = new Level3();
                player2.Visible = false;
                this.Hide();
                gameTimer2.Stop();
                newLevel.Show();
            }


            if (playerStats.health <= 0)
            {
                //gameTimer2.Stop();
                playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                playerStats.health = 3;
            }

            SendCordinates_TickAsync();
            SendCoinsState_Async("");


        }

        public async Task SendCordinates_TickAsync()
        {
            if (int.Parse(playerLabel.Text) == 1)
            {
                connection.On<string>("secondPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player2.Left = Convert.ToInt32(splitedText[0]);
                    player2.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetFirtPlayerCordinates", player.Left + "," + player.Top);
            }
            else
            {
                connection.On<string>("firstPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player1.Left = Convert.ToInt32(splitedText[0]);
                    player1.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetSecondPlayerCordinates", player.Left + "," + player.Top);
            }
        }

        //Sets taken coins to invisible from another player and updates score
        public async Task SendCoinsState_Async(string coinName)
        {

            if (int.Parse(playerLabel.Text) == 1)
            {
                connection.On<string>("secondCoins", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    if (message != "" && coins.ContainsKey(splitedText[0]))
                    {
                        coins[splitedText[0]].setInvisible();
                        score.value = Convert.ToInt32(splitedText[1]);
                        txtScore.Text = "Score: " + score.value;
                    }
                });
                await connection.SendAsync("GetFirstCoinsStatus", coinName + "," + score.value);
            }
            else
            {
                connection.On<string>("firstCoins", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    if (message != "" && coins.ContainsKey(splitedText[0]))
                    {
                        coins[splitedText[0]].setInvisible();
                        score.value = Convert.ToInt32(splitedText[1]);
                        txtScore.Text = "Score: " + score.value;
                    }
                });
                await connection.SendAsync("GetSecondCoinsStatus", coinName + "," + score.value);

            }


        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerStats.goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerStats.goRight = true;
            }
            if (e.KeyCode == Keys.Space && playerStats.jumping == false)
            {
                playerStats.jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerStats.goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerStats.goRight = false;
            }
            if (playerStats.jumping == true)
            {
                playerStats.jumping = false;
            }

            if (e.KeyCode == Keys.Enter && playerStats.isGameOver == true)
            {
                RestartGame();
            }

            if (e.KeyCode == Keys.R)
            {
                RestartGame();
            }

            if (e.KeyCode == Keys.A)
            {
                playerStats.canPress = true;
            }
        }
        private void RestartGame()
        {

            playerStats.jumping = false;
            playerStats.goLeft = false;
            playerStats.goRight = false;
            playerStats.isGameOver = false;


            txtScore.Text = "Score: " + score;
            txtScore.Refresh();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            // reset the position of player, platform and enemies
            player.Left = 593;
            player.Top = 564;

            horizontalPlatform.Left = 275;
            verticalPlatform.Top = 581;
            score.value = 0;
        }

        //Builds all coins parts and puts them into Dictionary for player
        public void buildCoins()
        {
            Director director = new Director();
            int i = 0;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "coin" && i == 1)
                {
                    var yellowCoinBuilder = new YellowCoinBuilder();
                    director.Construct(yellowCoinBuilder);
                    var coin = yellowCoinBuilder.GetCoin();
                    coin.picBox = (PictureBox)x;
                    coin.setValueAndColor();
                    coins.Add(x.Name, coin);
                    i++;
                }
                else if (x is PictureBox && (string)x.Tag == "coin" && i == 2)
                {
                    var greenCoinBuilder = new GreenCoinBuilder();
                    director.Construct(greenCoinBuilder);
                    var coin = greenCoinBuilder.GetCoin();
                    coin.picBox = (PictureBox)x;
                    coin.setValueAndColor();
                    coins.Add(x.Name, coin);
                    i++;
                }
                else if (x is PictureBox && (string)x.Tag == "coin" && i == 3)
                {
                    var redCoinBuilder = new RedCoinBuilder();
                    director.Construct(redCoinBuilder);
                    var coin = redCoinBuilder.GetCoin();
                    coin.picBox = (PictureBox)x;
                    coin.setValueAndColor();
                    coins.Add(x.Name, coin);
                    i = 1;
                }
                else if (x is PictureBox && (string)x.Tag == "coin" && i == 0)
                {
                    var redCoinBuilder = new RedCoinBuilder();
                    director.Construct(redCoinBuilder);
                    var coin = redCoinBuilder.GetCoin();
                    coin.picBox = (PictureBox)x;
                    FakeCoinAdapter fakeCoin = new FakeCoinAdapter(coin);
                    fakeCoin.isFake();
                    coins.Add(x.Name, coin);
                    i = 1;
                }

            }

        }

        public PictureBox CreatePicBoxDyn(Color color, int xsize, int ysize, int locationx, int locationy, string tag)
        {
            var picture = new PictureBox
            {
                BackColor = color,
                Size = new Size(xsize, ysize),
                Location = new Point(locationx, locationy),
                Tag = tag
            };
            Controls.Add(picture);
            picture.Show();
            return picture;
        }

        private void Level2_Load(object sender, EventArgs e)
        {

        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
