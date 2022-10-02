using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;

namespace Client
{
    public partial class Lobby : Form
    {
        private HubConnection connection;
        private Player me;
        private Player other;

        public Lobby()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connectedToLobbyPanel.BringToFront();
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();

            await connection.StartAsync();

            connection.On<Player>("NewPlayer", otherPlayer => { this.other = otherPlayer; setOtherPlayer(); }); connectedToLobbyPanel.BringToFront();
        }

        private void setOtherPlayer()
        {
            readyButton.Visible = true;
        }

        private async void readyButton_Click(object sender, EventArgs e)
        {
            readyButton.Visible = false;
            notReadyButton.Visible = true;
            connection.On<string>("checkReady", async (message) =>
            {
                if (Convert.ToInt32(message) == 2)
                {
                    readyButton.Visible = false;
                    notReadyButton.Visible = false;
                    connection.On<string>("resetCount", (message) =>
                    {
                        
                    });
                    await connection.SendAsync("ResetReady", "Reseted");
                    StartGame();
                }
                else
                {
                    readyButton.Visible = false;
                    notReadyButton.Visible = true;
                }
            });
            await connection.SendAsync("CheckHowManyReadyIs", "User checked");

        }

        private async void notReadyButton_Click(object sender, EventArgs e)
        {
            readyButton.Visible = true;
            notReadyButton.Visible = false;

            await connection.SendAsync("UndoReady", "User checked");
        }
        private async void StartGame()
        {
            
            var openedForms = 0;
            counter.Visible = true;
            connection.On<string>("counter", (message) =>
            {
                if (message != "BEGIN")
                {
                    counter.Text = message;
                }
                else
                {
                    counter.Text = "Game has started";
                    Thread.Sleep(300);
                    if(openedForms == 0)
                    {
                        Forma gameForm = new Forma();
                        gameForm.Visible = true;
                        openedForms++;
                    }

                }
                
            });

            await connection.SendAsync("StartCounting", "Counting started");
        }
    }
}