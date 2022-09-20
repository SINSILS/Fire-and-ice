using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class Fire_And_Ice : Form
    {
        private HubConnection connection;
        public Fire_And_Ice()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:7021/gameHub").Build();
            connection.On<string>("recievingMessage", (message) =>
            {
                label4.Text = message;
            });
            await connection.StartAsync();
            label2.Text = "Yes";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await connection.SendAsync("SendMessage", textBox1.Text);
        }
    }
}