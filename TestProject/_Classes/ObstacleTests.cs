namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;
    using System.Windows.Forms;

    public class ObstacleTests
    {
        private Obstacle _testClass;
        private PictureBox _pic;
        private int _damage;

        public ObstacleTests()
        {
            _pic = new PictureBox();
            _damage = 96455641;
            _testClass = new Obstacle(_pic, _damage);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Obstacle(_pic, _damage);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullPic()
        {
            Assert.Throws<ArgumentNullException>(() => new Obstacle(default(PictureBox), 1037214025));
        }

        [Fact]
        public void CanCallClone()
        {
            // Act
            var result = _testClass.Clone();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeepCopy()
        {
            // Act
            var result = _testClass.DeepCopy();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void picIsInitializedCorrectly()
        {
            Assert.Same(_pic, _testClass.pic);
        }

        [Fact]
        public void CanSetAndGetpic()
        {
            // Arrange
            var testValue = new PictureBox();

            // Act
            _testClass.pic = testValue;

            // Assert
            Assert.Same(testValue, _testClass.pic);
        }

        [Fact]
        public void DamageIsInitializedCorrectly()
        {
            Assert.Equal(_damage, _testClass.Damage);
        }

        [Fact]
        public void CanSetAndGetDamage()
        {
            // Arrange
            var testValue = 991245461;

            // Act
            _testClass.Damage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Damage);
        }
    }
}