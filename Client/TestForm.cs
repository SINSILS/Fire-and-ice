using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class TestForm : Form
    {
        HubConnection hubConnection;
        public TestForm()
        {
            InitializeComponent();
            hubConnection = new HubConnectionBuilder()
                .WithAutomaticReconnect()
                .WithUrl("http://localhost:7021/gameHub")
                .Build();
        }

        private async void TestForm_Load(object sender, EventArgs e)
        {
            hubConnection.On<string>("recievingMessage", (message) =>
            {
                listBox1.Items.Add(message);
            });
            try
            {
                await hubConnection.StartAsync();
                listBox1.Items.Add("Connection started!");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                await hubConnection.SendAsync("SendMessage", textBox1.Text);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
