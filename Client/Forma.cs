using Client._Classes;
using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.Factories;
using Client._Patterns_Designs;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class Forma : Form
    {
        private HubConnection connection;

        GamePlayer playerStats = new(3, false, false, false, false, 0, 0, 0, 7, 5, 3);
        Enemy enemy = new(3);
        Dictionary<string, Coin> coins = new Dictionary<string, Coin>();
        Score score = Score.getInstance();
        PictureBox player;

        bool CanPress;
        string temp, temp2;

        InteractableFactory leverFactory = new LeverFactory();
        Interactable lever;

        ObserverHelper observer1 = new ObserverHelper("Observer I");
        ObserverHandler provider = new ObserverHandler();



        public Forma()
        {
            InitializeComponent();
            DoubleBuffered = true;
            player = player1;
            AsignPlayers();
            getCoins();
            lever = leverFactory.CreateInteractable();

            observer1.Subscribe(provider);

            provider.AddApplication(lever);
            observer1.List();

            SendLeverState_Async();

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

                }
                else
                {
                    playerIndex = int.Parse(message);
                    playerLabel.Text = message;
                    label1.Text = "Fire Boy";
                    player = player2;
                }
            });
            await connection.SendAsync("AsignPlayer", "");
        }

        private void gameTimer_TickAsync(object sender, EventArgs e)
        {
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
                playerStats.jumpSpeed = -8;
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

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            coins[x.Name].setInvisible();
                            score.increaseScore(1);
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
                        else
                        {
                            txtScore.Text = "Score: " + score.value + Environment.NewLine + "Collect all the coins";
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
                            lever.isPushed=true;
                            observer1.List();
                            SendLeverState_Async();

                        }

                        if (player.Bounds.IntersectsWith(x.Bounds) && playerStats.canPress == true && CanPress == true && lever.isActivated == true)
                        {
                            Leveer.BackColor = Color.Red;
                            playerStats.canPress = false;
                            lever.SetActivated(false);
                            lever.isPushed=false;
                            observer1.List();
                            SendLeverState_Async();


                        }
                    }
                }
            }

            horizontalPlatform.Left -= playerStats.horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                playerStats.horizontalSpeed = playerStats.horizontalSpeed * -1;
            }

            verticalPlatform.Top += playerStats.verticalSpeed * -1;

            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 581)
            {
                playerStats.verticalSpeed = playerStats.verticalSpeed * -1;
            }

            enemyOne.Left -= enemy.Speed;

            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemy.Speed = enemy.Speed * -1;
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && playerStats.score == 26)
            {
                gameTimer.Stop();
                playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
            }

            if (playerStats.score > 5)
            {
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "Your quest is complete!";
            }

            if(playerStats.health == 0)
            {
                gameTimer.Stop();
                playerStats.isGameOver = true;
                txtScore.Text = "Score: " + score.value + Environment.NewLine + "You were killed in your journey!!";
                playerStats.health=3;
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
                    coins[splitedText[0]].setInvisible();
                    score.value = Convert.ToInt32(splitedText[1]);
                    txtScore.Text = "Score: " + score.value;
                });
                await connection.SendAsync("GetFirstCoinsStatus", coinName + "," + score.value);
            }
            else
            {
                connection.On<string>("firstCoins", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    coins[splitedText[0]].setInvisible();
                    score.value = Convert.ToInt32(splitedText[1]);
                    txtScore.Text = "Score: " + score.value;
                });
                await connection.SendAsync("GetSecondCoinsStatus", coinName + "," + score.value);

            }


        }

        public async Task SendLeverState_Async()
        {

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
                    if (message=="False")
                    {
                        Leveer.BackColor=Color.Red;
                    }
                });
                await connection.SendAsync("GetFirstLeverStatus", lever.isActivated.ToString());
                await connection.SendAsync("GetFirstLeverStatus",lever.isPushed.ToString());
                await connection.SendAsync("GetSecondLeverStatus",lever.isPushed.ToString());
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
                    if (message=="False")
                    {
                        Leveer.BackColor=Color.Red;
                    }

                });
                await connection.SendAsync("GetSecondLeverStatus", lever.isActivated.ToString());
                await connection.SendAsync("GetSecondLeverStatus", lever.isPushed.ToString());
                await connection.SendAsync("GetFirstLeverStatus", lever.isPushed.ToString());

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
        }

        //Gets all coins pictureBoxes to Dictionary for player
        public void getCoins()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    Coin coin = new Coin((PictureBox)x);
                    coins.Add(x.Name, coin);
                }
            }
        }
    }
}