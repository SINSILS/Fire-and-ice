namespace Test._Patterns_Designs._Proxy_Pattern
{
    using Client._Patterns_Designs._Proxy_Pattern;
    using Client._Patterns_Designs._State_Pattern;
    using System;
    using System.Windows.Forms;
    using Xunit;

    public class ProxyTests
    {
        private Proxy _testClass;

        public ProxyTests()
        {
            _testClass = new Proxy();
        }

        [Fact]
        public void CanCallcreateDoor()
        {
            // Arrange
            var state = new OpenDoorState();

            // Act
            _testClass.createDoor(state);

            // Assert
            throw new NotImplementedException("Create or modify test");
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
            _testClass.Request();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallsetPicBox()
        {
            // Arrange
            var pickBox = new PictureBox();

            // Act
            _testClass.setPicBox(pickBox);

            // Assert
            throw new NotImplementedException("Create or modify test");
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
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallgetState()
        {
            // Act
            var result = _testClass.getState();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallsetState()
        {
            // Arrange
            var state = new ClosedDoorState();

            // Act
            _testClass.setState(state);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallsetStateWithNullState()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.setState(default(State)));
        }
    }
}