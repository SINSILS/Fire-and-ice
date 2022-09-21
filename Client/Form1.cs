using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Forma : Form
    {
        HubConnection hubConnection;

        Player playerOne = new(false, false, false, false, 0, 0, 0, 7, 5, 3, "owahfoiawifha");
        Enemy enemy = new(3);

        //int enemyTwoSpeed = 3;



        public Forma()
        {
            InitializeComponent();
            DoubleBuffered = true;

            hubConnection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl("http://localhost:7021/gameHub")
                .Build();        
        }

        private async void Forma_Load(object sender, EventArgs e)
        {
            await hubConnection.StartAsync();
            // Sends message as soon as client is launched
            await hubConnection.SendAsync("SendMessage", $"Joined Game {hubConnection.ConnectionId}");
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + playerOne.score;

            player.Top += playerOne.jumpSpeed;

            if (playerOne.goLeft == true)
            {
                player.Left -= playerOne.playerSpeed;
            }
            if (playerOne.goRight == true)
            {
                player.Left += playerOne.playerSpeed;
            }

            if (playerOne.jumping == true && playerOne.force < 0)
            {
                playerOne.jumping = false;
            }

            if (playerOne.jumping == true)
            {
                playerOne.jumpSpeed = -8;
                playerOne.force -= 1;
            }
            else
            {
                playerOne.jumpSpeed = 10;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {


                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            playerOne.force = 8;
                            player.Top = x.Top - player.Height;


                            if ((string)x.Name == "horizontalPlatform" && playerOne.goLeft == false || (string)x.Name == "horizontalPlatform" && playerOne.goRight == false)
                            {
                                player.Left -= playerOne.horizontalSpeed;
                            }


                        }

                        x.BringToFront();

                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            playerOne.score++;
                        }
                    }


                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            playerOne.isGameOver = true;
                            txtScore.Text = "Score: " + playerOne.score + Environment.NewLine + "You were killed in your journey!!";
                        }
                        else
                        {
                            txtScore.Text = "Score: " + playerOne.score + Environment.NewLine + "Collect all the coins";
                        }
                    }

                }
            }


            horizontalPlatform.Left -= playerOne.horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                playerOne.horizontalSpeed = playerOne.horizontalSpeed *-1;
            }

            verticalPlatform.Top += playerOne.verticalSpeed * -1;

            if (verticalPlatform.Top < 195 || verticalPlatform.Top > 581)
            {
                playerOne.verticalSpeed = playerOne.verticalSpeed * -1;
            }


            enemyOne.Left -= enemy.speed;

            if (enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemy.speed = enemy.speed * -1;
            }

            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                playerOne.isGameOver = true;
                txtScore.Text = "Score: " + playerOne.score + Environment.NewLine + "You fell to your death!";
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && playerOne.score == 26)
            {
                gameTimer.Stop();
                playerOne.isGameOver = true;
                txtScore.Text = "Score: " + playerOne.score + Environment.NewLine + "Your quest is complete!";
            }

            if(playerOne.score == 26)
            {
                txtScore.Text = "Score: " + playerOne.score + Environment.NewLine + "Your quest is complete!";
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerOne.goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerOne.goRight = true;
            }
            if (e.KeyCode == Keys.Space && playerOne.jumping == false)
            {
                playerOne.jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerOne.goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                playerOne.goRight = false;
            }
            if (playerOne.jumping == true)
            {
                playerOne.jumping = false;
            }

            if (e.KeyCode == Keys.Enter && playerOne.isGameOver == true)
            {
                RestartGame();
            }

            if (e.KeyCode == Keys.R)
            {
                RestartGame();
            }


        }

        private void RestartGame()
        {

            playerOne.jumping = false;
            playerOne.goLeft = false;
            playerOne.goRight = false;
            playerOne.isGameOver = false;
            playerOne.score = 0;

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

            gameTimer.Start();


        }
    }
}