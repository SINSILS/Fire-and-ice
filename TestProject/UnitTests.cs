using Client._Classes;
using Client._Patterns_Designs;
using Client._Patterns_Designs._Strategy_Patern;
using Client._Patterns_Designs._Bridge_Pattern;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;
using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.Factories;
using System.Windows.Forms;
using System.Drawing;
using Client._Patterns_Designs._Decorator_Pattern;

namespace TestProject
{
    public class GameTesting
    {
        [Fact]
        public void DecoratorTest()
        {
            var picture = new PictureBox
            {
                BackColor = Color.White,
                Size = new Size(10, 10),
                Location = new Point(10, 10),
                Tag = "Test"
            };

            IPlatform createdPlatformReg = new Platform(picture);
            createdPlatformReg.CreatePlatform();

            HorizontalPlatformDecorator horizontal = new HorizontalPlatformDecorator(createdPlatformReg);
            horizontal.CreatePlatform();
            Assert.True(horizontal.Speed > 0);
        }
        [Fact]
        public void DamageTest()
        {
            GamePlayer player = new(3,2,4,5,6,7);
            player.LowerHealth(2);
            Assert.True(player.health == 1);
        }
        [Fact]
        public void MovementTest()
        {
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
            var movementType = player.GetMovement();
            player.SetMovement(new EnhancedMovement());
            Assert.True(movementType != player.GetMovement());
        }
        [Fact]
        public void ApplySpeedPowerUp()
        {
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
            SpeedBoost speedPowerUp = new SpeedBoost(13);
            var playerSpeed = player.playerSpeed;
            player.ApplyPowerUp(speedPowerUp);
            Assert.True(player.playerSpeed> playerSpeed);
        }
        [Fact]
        public void ApplyHealthPowerUp()
        {
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
            Healing HealingPotion = new Healing(13);
            var playerHealth = player.health;
            player.ApplyPowerUp(HealingPotion);
            Assert.True(player.health > playerHealth);
        }
    }
}