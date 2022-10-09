using Client._Classes;
using Client._Patterns_Designs;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;
namespace TestProject
{
    public class GameTesting
    {
        [Fact]
        public void HealthTest()
        {
            GamePlayer a = new(3, false, false, false, false, 0, 0, 0, 7, 5, 3);
            a.LowerHealth(2);
            Assert.True(a.health == 1);
        }
    }
}