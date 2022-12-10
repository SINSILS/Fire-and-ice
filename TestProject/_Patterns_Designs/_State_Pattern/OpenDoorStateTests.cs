namespace Test._Patterns_Designs._State_Pattern
{
    using Client._Patterns_Designs._State_Pattern;
    using System;
    using Xunit;

    public class OpenDoorStateTests
    {
        private OpenDoorState _testClass;

        public OpenDoorStateTests()
        {
            _testClass = new OpenDoorState();
        }

        [Fact]
        public void CanCallHandle()
        {
            // Arrange
            var door = new Door(new ClosedDoorState());

            // Act
            _testClass.Handle(door);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallHandleWithNullDoor()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Handle(default(Door)));
        }
    }
}