namespace Test._Patterns_Designs._State_Pattern
{
    using Client._Patterns_Designs._State_Pattern;
    using System;
    using System.Windows.Forms;
    using Xunit;

    public class DoorTests
    {
        private Door _testClass;
        private State _state;
        public DoorTests()
        {
            _state = new ClosedDoorState();
            _testClass = new Door(_state);
            _testClass.setPicBox(new PictureBox());
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Door(_state);
            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullState()
        {
            Assert.Throws<ArgumentNullException>(() => new Door(default(State)));
        }

        [Fact]
        public void CanCallcreateDoor()
        {
            // Arrange
            var state = new ClosedDoorState();
            // Act
            _testClass.createDoor(state);
            // Assert
            Assert.NotNull(_testClass.getState());
        }

        [Fact]
        public void CannotCallcreateDoorWithNullState()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.createDoor(default(State)));
        }

        [Fact]
        public void CanCallRequest()
        {
            // Act
            State firstState = _testClass.getState();
            _testClass.Request();
            State secondState = _testClass.getState();
            // Assert
            Assert.NotEqual(firstState.GetType().Name, secondState.GetType().Name);
        }

        [Fact]
        public void CanCallsetPicBox()
        {
            // Arrange
            var pickBox = new PictureBox();
            // Act
            _testClass.setPicBox(pickBox);
            // Assert
            Assert.NotNull(_testClass.getState());
        }

        [Fact]
        public void CannotCallsetPicBoxWithNullPickBox()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setPicBox(default(PictureBox)));
        }

        [Fact]
        public void CanCallgetPicBox()
        {
            // Act
            var result = _testClass.getPicBox();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CanCallgetState()
        {
            // Act
            var result = _testClass.getState();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CanCallsetState()
        {
            // Arrange
            var firstState = _testClass.getState();
            var secondState = new OpenDoorState();

            // Act
            _testClass.setState(secondState);

            // Assert
            Assert.Equal(_testClass.getState().GetType().Name, secondState.GetType().Name);
        }

        [Fact]
        public void CannotCallsetStateWithNullState()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setState(default(State)));
        }
    }
}