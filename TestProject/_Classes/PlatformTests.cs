namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;
    using System.Drawing;
    using System.Windows.Forms;

    public class PlatformTests
    {
        private Platform _testClass;
        private Color _platformColor;
        private int _xPos;
        private int _yPos;
        private PictureBox _picture;
        private int _speed;

        public PlatformTests()
        {
            _platformColor = Color.Orange;
            _xPos = 518462283;
            _yPos = 512440444;
            _picture = new PictureBox();
            _speed = 1736851433;
            _testClass = new Platform(_platformColor, _xPos, _yPos, _picture, _speed);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Platform(_platformColor, _xPos, _yPos, _picture, _speed);

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new Platform(_picture);

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new Platform();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPicture()
        {
            Assert.Throws<ArgumentNullException>(() => new Platform(Color.Orange, 1522222887, 1753579945, default(PictureBox), 1578485978));
            Assert.Throws<ArgumentNullException>(() => new Platform(default(PictureBox)));
        }

        [Fact]
        public void CanCallCreatePlatform()
        {
            // Act
            var result = _testClass.CreatePlatform();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void PlatformColorIsInitializedCorrectly()
        {
            Assert.Equal(_platformColor, _testClass.PlatformColor);
        }

        [Fact]
        public void CanSetAndGetPlatformColor()
        {
            // Arrange
            var testValue = Color.Brown;

            // Act
            _testClass.PlatformColor = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PlatformColor);
        }

        [Fact]
        public void XPosIsInitializedCorrectly()
        {
            Assert.Equal(_xPos, _testClass.XPos);
        }

        [Fact]
        public void CanSetAndGetXPos()
        {
            // Arrange
            var testValue = 791033996;

            // Act
            _testClass.XPos = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.XPos);
        }

        [Fact]
        public void YPosIsInitializedCorrectly()
        {
            Assert.Equal(_yPos, _testClass.YPos);
        }

        [Fact]
        public void CanSetAndGetYPos()
        {
            // Arrange
            var testValue = 599071436;

            // Act
            _testClass.YPos = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.YPos);
        }

        [Fact]
        public void PictureIsInitializedCorrectly()
        {
            _testClass = new Platform(_platformColor, _xPos, _yPos, _picture, _speed);
            Assert.Same(_picture, _testClass.Picture);
            _testClass = new Platform(_picture);
            Assert.Same(_picture, _testClass.Picture);
        }

        [Fact]
        public void CanSetAndGetPicture()
        {
            // Arrange
            var testValue = new PictureBox();

            // Act
            _testClass.Picture = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Picture);
        }

        [Fact]
        public void SpeedIsInitializedCorrectly()
        {
            Assert.Equal(_speed, _testClass.Speed);
        }

        [Fact]
        public void CanSetAndGetSpeed()
        {
            // Arrange
            var testValue = 1418340676;

            // Act
            _testClass.Speed = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Speed);
        }
    }
}