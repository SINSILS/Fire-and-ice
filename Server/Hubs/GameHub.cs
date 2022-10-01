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

        public async Task<Player> ConnectPlayer(string nickname)
        {
            if (UserHandler.GamePlayers.Count == 2)
            {
                return null;
            }

            var player = new Player()
            {
                Id = UserHandler.GamePlayers.Count,
                isReady = false
            };
            UserHandler.GamePlayers.Add(player);

            await Clients.Others.SendAsync("NewPlayer", player);
            return player;
        }

        public async Task<Player> GetOtherPlayer(int id)
        {
            foreach (Player p in UserHandler.GamePlayers)
            {
                if (p.Id != id)
                {
                    return p;
                }
            }

            return null;
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

        public async Task CheckHowManyReadyIs(string message)
        {
            //if (!UserHandler.ConnectedIds.Contains(Context.ConnectionId))
            {
                GameInfo.HowManyIsRead++;
            }
            Console.WriteLine(GameInfo.HowManyIsRead);
            Console.WriteLine(UserHandler.ConnectedIds.ToString());
            await Clients.All.SendAsync("checkReady", GameInfo.HowManyIsRead.ToString());
        }

        public async Task UndoReady(string message)
        {
            GameInfo.HowManyIsRead--;
            //Console.WriteLine($"Check recieved: {message}");
            await Clients.All.SendAsync("undoReady", GameInfo.HowManyIsRead.ToString());
        }

        public async Task StartCounting(string message)
        {
            for (int i = 0; i < 3; i++)
            {
                var time = i + 1;
                await Clients.All.SendAsync("counter", time.ToString());
                Thread.Sleep(1000);
            }
            GameInfo.GameIsStarted = true;
            Thread.Sleep(1000);
            await Clients.All.SendAsync("counter", "BEGIN");
        }

        public async Task ResetReady(string message)
        {
            GameInfo.HowManyIsRead = 0;
            await Clients.All.SendAsync("resetCount", "Reseted");
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