namespace Test._Patterns_Designs._Command_Pattern
{
    using Client._Patterns_Designs._Command_Pattern;
    using System;
    using Xunit;
    using System.Windows.Forms;

    public class MoveEnemyLeftTests
    {
        private MoveEnemyLeft _testClass;
        private int _speed;
        private PictureBox _enemyBox;

        public MoveEnemyLeftTests()
        {
            _speed = 920201445;
            _enemyBox = new PictureBox();
            _testClass = new MoveEnemyLeft(_speed, _enemyBox);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new MoveEnemyLeft(_speed, _enemyBox);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullEnemyBox()
        {
            Assert.Throws<ArgumentNullException>(() => new MoveEnemyLeft(1832254742, default(PictureBox)));
        }

        [Fact]
        public void CanCallExecute()
        {
            // Act
            _testClass.Execute();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUndo()
        {
            // Act
            _testClass.Undo();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}