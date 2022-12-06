using Client._Classes;
using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.Factories;
using Client._Patterns_Designs._Adapter_Pattern;
using Client._Patterns_Designs._Bridge_Pattern;
using Client._Patterns_Designs._Builder_Patern;
using Client._Patterns_Designs._Command_Pattern;
using Client._Patterns_Designs._Decorator_Pattern;
using Client._Patterns_Designs._Interpreter;
using Client._Patterns_Designs._Iterator;
using Client._Patterns_Designs._State_Pattern;
using Client._Patterns_Designs._Strategy_Patern;
using Client._Patterns_Designs._Template_Pattern;
using Client._Patterns_Designs.Observer;
using Microsoft.AspNetCore.SignalR.Client;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class Forma : Form
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

        PowerUpCollection concreteAggregate = new PowerUpCollection();
        Iterator iterator;
        PowerUp powerUp;

        int speed, speedVertical;


        private CharacterMoveClean enemyMovement = new CharacterMoveClean();
        private bool moveEnemyOneRight = true;

        LabelUpdater onecoiner = new OneCoinUpdate();
        LabelUpdater twocoiner = new TwoCoinUpdate();
        LabelUpdater threecoiner = new ThreeCoinUpdate();
        LabelUpdater powerup = new PowerupUpdate();

        Door doors = new Door(new ClosedDoorState());

        int timePassed = 0;

        public Forma()
        {
            InitializeComponent();
            DoubleBuffered = true;
            player = player1;
            AsignPlayers();
            buildCoins();
            lever = levelFactory.CreateInteractableLever();

            observer1.Subscribe(provider);

            provider.AddApplication(lever);
            observer1.List();
            SendLeverState_Async();

            PictureBox a = CreatePicBoxDyn(Color.Black, 50, 50, 300, 300, "obstacle");
            PictureBox b = CreatePicBoxDyn(Color.DeepPink, 75, 75, 738, 387, "obstacle");

            PictureBox platform = CreatePicBoxDyn(Color.AliceBlue, 148, 35, 699, 500, "platform");
            PictureBox platformVertical = CreatePicBoxDyn(Color.AliceBlue, 148, 35, 400, 400, "platform");
            PictureBox regPlatform = CreatePicBoxDyn(Color.AliceBlue, 148, 35, 706, 204, "platform");
            obs = new(a, 5);

            GCHandle objHandle = GCHandle.Alloc(obs, GCHandleType.WeakTrackResurrection);
            long address = GCHandle.ToIntPtr(objHandle).ToInt64();

            Console.WriteLine("Adress of first obstacle: " + address.ToString());

            Console.WriteLine("Obstacle 1 damage: " + obs.Damage.ToString());
            clone = (Obstacle)obs.DeepCopy();

            GCHandle objHandle1 = GCHandle.Alloc(clone, GCHandleType.WeakTrackResurrection);
            long address1 = GCHandle.ToIntPtr(objHandle1).ToInt64();
            Console.WriteLine("Adress of cloned:" + address1.ToString());

            clone.pic = b;


            b.Tag = "clone";
            clone.Damage = 0;
            Console.WriteLine("Cloned obstacle damage: " + clone.Damage.ToString());



            IPlatform createdPlatform = new Platform(platform);
            createdPlatform.CreatePlatform();

            IPlatform createdPlatformReg = new Platform(regPlatform);
            createdPlatformReg.CreatePlatform();

            HorizontalPlatformDecorator horizontal = new HorizontalPlatformDecorator(createdPlatform);
            horizontal.CreatePlatform();
            speed = horizontal.Speed;


            IPlatform createdPlatform2 = new Platform(platformVertical);
            VerticalPlatformDecorator vertical = new VerticalPlatformDecorator(createdPlatform2);
            vertical.CreatePlatform();
            speedVertical = vertical.Speed;

            doors.picBox = door;


            Expression[] expressions = new Expression[]
{
    new TenExpression(),
    new OneExpression(),
};

            var context = new Context(99);

            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }

            Console.WriteLine(context.Output);

            //PowerUp iterator
            concreteAggregate[0] = new SpeedBoost(13);
            concreteAggregate[1] = new JumpBoost(-10);
            concreteAggregate[2] = new Healing(1);
            concreteAggregate[3] = new SpeedBoost(7);

            iterator = concreteAggregate.CreateIterator();

            powerUp = iterator.First();

            //Army army = new Army();
            //army.Add(new SpeedDemon(5, 1));
            //army.Add(new CrackDemon(1, 1));
            //Army army1 = new Army();
            //army1.Add(new SpeedDemon(5, 5));
            //army1.Add(new SpeedDemon(3, 3));
            //army.Add(army1);
            //army.Add(new CrackDemon(10, 10));

            //army.Display(1);
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
                    playerStats.SetMovement(new NormalMovement());
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

        private void gameTimer_TickAsync(object sender, EventArgs e)
        {
            timePassed += 1;
            txtScore.Text = "Score: " + score.value;

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

                    if ((string)x.Tag == "Vertical")
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
                            if (coins[x.Name].value == 1)
                            {
                                onecoiner.Update();
                            }
                            if (coins[x.Name].value == 2)
                            {
                                twocoiner.Update();
                            }

                            if (coins[x.Name].value == 3)
                            {
                                threecoiner.Update();
                            }
                            SendCoinsState_Async(x.Name);
                            txtScore.Refresh();
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            //gameTimer.Stop();
                            //playerStats.isGameOver = true;
                            //txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                            player.Left = 593;
                            player.Top = 564;
                            playerStats.LowerHealth(enemy.Damage);
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

                    if ((string)x.Tag == "lever")
                    {
                        CanPress = true;
                        if (player.Bounds.IntersectsWith(x.Bounds) && playerStats.canPress == true && CanPress == true && lever.isActivated == false)
                        {
                            Leveer.BackColor = Color.Green;

                            playerStats.canPress = false;
                            lever.SetActivated(true);
                            observer1.List();
                            SendLeverState_Async();

                        }

                        if (player.Bounds.IntersectsWith(x.Bounds) && playerStats.canPress == true && CanPress == true && lever.isActivated == true)
                        {
                            Leveer.BackColor = Color.Red;
                            playerStats.canPress = false;
                            lever.SetActivated(false);
                            observer1.List();
                            SendLeverState_Async();
                        }
                    }

                    if ((string)x.Tag == "PowerUp")
                    {
                        if (x.Visible && player.Bounds.IntersectsWith(x.Bounds) && powerUp.isCollected == false && !playerStats.activePowerUp)
                        {
                            x.Visible = false;
                            powerUp.isCollected = true;
                            playerStats.ApplyPowerUp(powerUp);
                            timePassed = 0;
                            SendPowerUpState_Async(x.Name);
                            powerup.Update();
                            powerUp = iterator.Next();
                            //SelectedGun selectedGun = new PistolWeapon();
                            //selectedGun.SelectNewGun();
                        }
                    }

                    if (playerStats.activePowerUp && timePassed >= 60) playerStats.RemovePowerUp();
                }
            }
            horizontalPlatform.Left -= playerStats.horizontalSpeed / 3;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                playerStats.horizontalSpeed = playerStats.horizontalSpeed * -1;
            }

            foreach (var pb in this.Controls
                                .OfType<PictureBox>()
                                .Where(x => (string)x.Tag == "Horizontal")
                                .ToList())
            {
                pb.Left -= playerStats.horizontalSpeed / 3;

                if (pb.Left < 0 || pb.Left + pb.Width > this.ClientSize.Width)
                {
                    playerStats.horizontalSpeed = playerStats.horizontalSpeed * -1;
                }
            }

            foreach (var pb in this.Controls
                    .OfType<PictureBox>()
                    .Where(x => (string)x.Tag == "Vertical")
                    .ToList())
            {
                pb.Top += playerStats.verticalSpeed * -speedVertical;

                if (pb.Top < 600)
                {
                    playerStats.verticalSpeed = playerStats.verticalSpeed * -1;
                }
            }

            verticalPlatform.Top += playerStats.verticalSpeed * -1;

            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 581)
            {
                playerStats.verticalSpeed = playerStats.verticalSpeed * -1;
            }


            if (moveEnemyOneRight)
            {
                ICommand moveEnemyRightCommand = new MoveEnemyRight(enemy.Speed, enemyOne);
                enemyMovement.commandHandler.AddCommand(moveEnemyRightCommand);
            }
            else
            {
                ICommand moveEnemyLeftCommand = new MoveEnemyLeft(enemy.Speed, enemyOne);
                enemyMovement.commandHandler.AddCommand(moveEnemyLeftCommand);
            }


            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                moveEnemyOneRight = !moveEnemyOneRight;
            }

            if (player1.Bounds.IntersectsWith(doors.picBox.Bounds) && doors.State.GetType().Name == "OpenDoorState")
            {
                // gameTimer.Stop();
                //playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                Level2 newLevel = new Level2();
                this.Hide();
                player1.Visible = false;

                gameTimer.Stop();
                newLevel.Show();
            }
            if (player2.Bounds.IntersectsWith(doors.picBox.Bounds) && doors.State.GetType().Name == "OpenDoorState")
            {
                // gameTimer.Stop();
                //playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                Level2 newLevel = new Level2();
                this.Hide();
                player2.Visible = false;

                gameTimer.Stop();
                newLevel.Show();
            }

            //if (score.value == 36 && doors.State.GetType().Name == "ClosedDoorState")
            //{
            //    txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
            //    doors.Request();
            //}

            if (score.value > 0)
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
                doors.Request();
            }

            if (score.value == 0)
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Collect coins to complete the quest!";
            }


            if (playerStats.health <= 0)
            {
                gameTimer.Stop();
                playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                playerStats.health = 3;
            }

            SendCordinates_TickAsync();
            SendCoinsState_Async("");
            SendPowerUpState_Async("");

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

        public async Task SendPowerUpState_Async(string powerUpName)
        {
            if (int.Parse(playerLabel.Text) == 1)
            {
                connection.On<string>("secondPowerUp", (message) =>
                {
                    if (message != "")
                    {
                        this.Controls.Find(message, true)[0].Visible = false;
                    }
                });
                await connection.SendAsync("GetFirstPowerUpStatus", powerUpName);
            }
            else
            {
                connection.On<string>("firstPowerUp", (message) =>
                {
                    if (message != "")
                    {
                        this.Controls.Find(message, true)[0].Visible = false;
                    }
                });
                await connection.SendAsync("GetSecondPowerUpStatus", powerUpName);
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

        public async Task SendLeverState_Async()
        {
            var temp = "";
            var temp2 = "";
            if (int.Parse(playerLabel.Text) == 1)
            {
                connection.On<string>("secondLever", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    temp = message;
                    if (message == "True")
                    {
                        Leveer.BackColor = Color.Green;
                    }
                    if (message == "False")
                    {
                        Leveer.BackColor = Color.Red;
                    }
                });
                await connection.SendAsync("GetFirstLeverStatus", lever.isActivated.ToString());
                //await connection.SendAsync("GetSecondLeverStatus", lever.isActivated.ToString());
            }
            else
            {
                connection.On<string>("firstLever", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    temp2 = message;
                    if (message == "True")
                    {
                        Leveer.BackColor = Color.Green;
                    }
                    if (message == "False")
                    {
                        Leveer.BackColor = Color.Red;
                    }

                });
                await connection.SendAsync("GetSecondLeverStatus", lever.isActivated.ToString());
                //await connection.SendAsync("GetFirstLeverStatus", lever.isActivated.ToString());

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


            //txtScore.Text = "Score: " + score;
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

            enemyOne.Left = 471;

            horizontalPlatform.Left = 275;
            verticalPlatform.Top = 581;
            score.value = 0;
            gameTimer.Start();

            if (doors.State.GetType().Name == "OpenDoorState")
            {
                doors.Request();
            }
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
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}