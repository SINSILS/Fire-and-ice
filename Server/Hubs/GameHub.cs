using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    //https://localhost:7021/gameHub
    public class GameHub : Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine($"Message recieved: {message}");
            await Clients.All.SendAsync("recievingMessage", message);
        }
    }
}
