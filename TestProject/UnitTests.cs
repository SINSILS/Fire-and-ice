using Client._Classes;
using Client._Classes.AbstractFactories;
using Client._Classes.AbstractProducts;
using Client._Classes.Factories;
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
            Healing HealingPotion = new Healing(1);
            player.LowerHealth(2);
            player.ApplyPowerUp(HealingPotion);
            Assert.True(player.health == 2);
        }

        [Fact]
        public void ApplyJumpPowerUp()
        {
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
            int playerJumpSpeed = player.boostedJumpSpeed;
            JumpBoost jumpPowerUp = new JumpBoost(-10);
            player.ApplyPowerUp(jumpPowerUp);
            Assert.True(player.boostedJumpSpeed < playerJumpSpeed);
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

        [Fact]
        public void SpeedPowerUpValue()
        {
            SpeedBoost speedPowerUp = new SpeedBoost(10);
            int value = speedPowerUp.GetPowerUpValue(7);
            int expectedValue = 17;
            Assert.True(value == expectedValue);
        }

        [Fact]
        public void HealingPowerUpValue()
        {
            Healing healPowerUp = new Healing(10);
            int value = healPowerUp.GetPowerUpValue(2);
            int expectedValue = 3;
            Assert.True(value == expectedValue);
        }

        [Fact]
        public void JumpPowerUpValue()
        {
            JumpBoost jumpPowerUp = new JumpBoost(-10);
            int value = jumpPowerUp.GetPowerUpValue(-8);
            int expectedValue = -18;
            Assert.True(value == expectedValue);
        }

        [Fact]
        public void Level1Factory()
        {
            LevelFactory levelFactory = new Level1Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            Interactable pressurePlate = levelFactory.CreateInteractablePressurePlate();

            Assert.True((lever.color == "None") && (pressurePlate.color == "None"));
        }

        [Fact]
        public void Level2Factory()
        {
            LevelFactory levelFactory = new Level2Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            Interactable pressurePlate = levelFactory.CreateInteractablePressurePlate();

            Assert.True((lever.color == "Red") && (pressurePlate.color == "Blue"));
        }

        [Fact]
        public void Level3Factory()
        {
            LevelFactory levelFactory = new Level3Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            Interactable pressurePlate = levelFactory.CreateInteractablePressurePlate();

            Assert.True((lever.color == "Blue") && (pressurePlate.color == "Red"));
        }

        [Fact]
        public void LeverActivated()
        {
            LevelFactory levelFactory = new Level3Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            lever.SetActivated(true);

            Assert.True(lever.isActivated == true);
        }

        [Fact]
        public void LeverDeactivated()
        {
            LevelFactory levelFactory = new Level3Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            lever.SetActivated(false);

            Assert.True(lever.isActivated == false);
        }

        [Fact]
        public void PressurePlateDeactivated()
        {
            LevelFactory levelFactory = new Level3Factory();
            Interactable pressurePlate = levelFactory.CreateInteractablePressurePlate();
            pressurePlate.SetActivated(false);

            Assert.True(pressurePlate.isActivated == false);
        }

        [Fact]
        public void CoinScoreIntegrationTest()
        {
            Director director = new Director();
            var redCoinBuilder = new RedCoinBuilder();
            director.Construct(redCoinBuilder);
            var coin = redCoinBuilder.GetCoin();
            coin.picBox = new PictureBox();
            coin.setValueAndColor();

            Score score = Score.getInstance();

            score.increaseScore(coin.value);

            Assert.True(score.value == 3);
        }

        [Fact]
        public void PlayerEnemyDamageHealIntegrationTest()
        {
            GamePlayer player = new(3, 2, 4, 5, 6, 7);
            Healing HealingPotion = new Healing(1);
            Enemy enemy = EnemyFactory.getEnemy("SpeedDemon");

            player.LowerHealth(enemy.Damage);
            Assert.True(player.health == 2);
            player.LowerHealth(enemy.Damage);
            player.ApplyPowerUp(HealingPotion);
            Assert.True(player.health == 2);
        }
    }
}