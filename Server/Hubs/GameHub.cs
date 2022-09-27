using Microsoft.AspNetCore.SignalR;
using Shared.Shared;

namespace Server.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();

        public static bool[] Players = new bool[2];

        public static List<Player> GamePlayers = new List<Player>();
    }

    static class GameInfo
    {
        public static int HowManyIsRead { get; set; } = 0;
        public static bool GameIsStarted { get; set; } = false;
        public static int MaxPlayers = 2;
    }

    public class GameHub : Hub
    {
        public GameHub()
        {

        }

        public async Task CheckHowManyOnlineIs(string message)
        {
            Console.WriteLine($"Check recieved: {message}");
            await Clients.All.SendAsync("checkOnline", UserHandler.ConnectedIds.Count.ToString());
        }

        public async override Task<Task> OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            UserHandler.Players[0] = false;
            UserHandler.Players[1] = false;
            await CheckHowManyOnlineIs("Disconected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task AsignPlayer(string message)
        {
            int index = 0;
            if (!UserHandler.Players[0])
            {
                index = 1;
                UserHandler.Players[0] = true;
            }
            else
            {
                index = 2;
                UserHandler.Players[1] = true;
            }
            Console.WriteLine("PLayer index:" + index); 
            await Clients.Caller.SendAsync("asigningPlayers", index.ToString());
        }

        public async Task GetFirtPlayerCordinates(string message)
        {
            //Console.WriteLine("Player first:" + message);
            await Clients.All.SendAsync("firstPlayer", message);
        }


        public async Task GetSecondPlayerCordinates(string message)
        {
            //Console.WriteLine("Player Second:" + message);
            await Clients.All.SendAsync("secondPlayer", message);
        }
    }
}


//Kol antras neprisijungia kitam nepasileidzia zaidimas
//Singleton - tasku skaiciavimas
//Nubraizyt klasiu diagrama (10 klasiu (coin ir tt.))