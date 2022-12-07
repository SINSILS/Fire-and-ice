using Client._Classes;
using Client._Patterns_Designs._Adapter_Pattern;
using Client._Patterns_Designs._Bridge_Pattern;
using Client._Patterns_Designs._Builder_Patern;
using Client._Patterns_Designs._Decorator_Pattern;
using Client._Patterns_Designs._Proxy_Pattern;
using Client._Patterns_Designs._State_Pattern;
using Client._Patterns_Designs._Strategy_Patern;
using System.Drawing;
using System.Windows.Forms;

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
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
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
            Assert.True(player.playerSpeed > playerSpeed);
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

        [Fact]
        public void YellowCoinValue()
        {
            int expectedValue = 1;
            Director director = new Director();
            var yellowCoinBuilder = new YellowCoinBuilder();
            director.Construct(yellowCoinBuilder);
            var coin = yellowCoinBuilder.GetCoin();
            coin.picBox = new PictureBox();
            coin.setValueAndColor();
            Assert.True(expectedValue == coin.value);
        }

        [Fact]
        public void GreenCoinValue()
        {
            var expectedValue = 2;
            Director director = new Director();
            var greenCoinBuilder = new GreenCoinBuilder();
            director.Construct(greenCoinBuilder);
            var coin = greenCoinBuilder.GetCoin();
            coin.picBox = new PictureBox();
            coin.setValueAndColor();
            Assert.True(expectedValue == coin.value);
        }

        [Fact]
        public void RedCoinValue()
        {
            var expectedValue = 3;
            Director director = new Director();
            var redCoinBuilder = new RedCoinBuilder();
            director.Construct(redCoinBuilder);
            var coin = redCoinBuilder.GetCoin();
            coin.picBox = new PictureBox();
            coin.setValueAndColor();
            Assert.True(expectedValue == coin.value);
        }

        [Fact]
        public void DoorStateAfterRequest()
        {
            var startState = new ClosedDoorState();
            Proxy doors = new Proxy();
            doors.createDoor(new ClosedDoorState());
            doors.setPicBox(new PictureBox());
            doors.Request();
            Assert.True(doors.getState().GetType().Name != startState.GetType().Name);
        }

        [Fact]
        public void ScoreInstanceCheck()
        {
            Score score = Score.getInstance();
            Score score2 = Score.getInstance();
            score.increaseScore(2);
            Assert.True(score.value == score2.value);
        }

        [Fact]
        public void FakeCoinValue()
        {
            Director director = new Director();
            var redCoinBuilder = new RedCoinBuilder();
            director.Construct(redCoinBuilder);
            var coin = redCoinBuilder.GetCoin();
            coin.picBox = new PictureBox();
            coin.setValueAndColor();
            int realValue = coin.value;
            FakeCoinAdapter fakeCoin = new FakeCoinAdapter(coin);
            fakeCoin.isFake();
            Assert.True(realValue != fakeCoin.getValue());
        }
    }
}