namespace Test._Classes.AbstractProducts
{
    using Client._Classes.AbstractProducts;
    using System;
    using Xunit;

    public class InteractableTests
    {
        private class TestInteractable : Interactable
        {
        }

        private TestInteractable _testClass;

        public InteractableTests()
        {
            _testClass = new TestInteractable();
        }

        [Fact]
        public void CanCallSetActivated()
        {
            // Arrange
            var state = true;

            // Act
            _testClass.SetActivated(state);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetisActivated()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.isActivated = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.isActivated);
        }

        [Fact]
        public void CanSetAndGetcolor()
        {
            // Arrange
            var testValue = "TestValue1300166426";

            // Act
            _testClass.color = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.color);
        }
    }
}