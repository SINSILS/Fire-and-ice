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
    public partial class TestForm2 : Form
    {
        HubConnection hubConnection;
        List<Player> players = new List<Player>();

        public TestForm2()
        {
            InitializeComponent();
            hubConnection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl("http://localhost:7021/gameHub")
                .Build();
        }

        private async void TestForm2_Load_1(object sender, EventArgs e)
        {
            await hubConnection.StartAsync();
            await hubConnection.SendAsync("SendMessage", hubConnection.ConnectionId);

            hubConnection.On<string>("recievingMessage", (message) =>
            {               
                Player player = new Player(false, false, false, false, 0, 0, 0, 7, 5, 3, message);

                players.Add(player);

                label1.Text = players.Count().ToString();

                if(players.Count == 1) playerOne.Visible = true;
                else if (players.Count == 2) playerTwo.Visible = true;
            });
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            
        }
    }
}
