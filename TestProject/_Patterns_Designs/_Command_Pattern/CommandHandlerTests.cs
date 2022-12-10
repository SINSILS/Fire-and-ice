namespace Test._Patterns_Designs._Command_Pattern
{
    using Client._Classes;
    using Client._Classes.Factories;
    using Client._Patterns_Designs._Command_Pattern;
    using System;
    using System.Windows.Forms;
    using Xunit;

    public class CommandHandlerTests
    {
        private CommandHandler _testClass;

        public CommandHandlerTests()
        {
            _testClass = new CommandHandler();
        }

        [Fact]
        public void CanCallAddCommand()
        {
            // Arrange
            Enemy enemy = EnemyFactory.getEnemy("SpeedDemon");
            ICommand moveEnemyRightCommand = new MoveEnemyRight(enemy.Speed, new PictureBox());

            // Act
            _testClass.AddCommand(moveEnemyRightCommand);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallAddCommandWithNullCommand()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddCommand(default(ICommand)));
        }

        [Fact]
        public void CanCallUndoCommand()
        {
            // Act
            _testClass.UndoCommand();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallRedoCommand()
        {
            // Act
            _testClass.RedoCommand();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}