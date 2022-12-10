namespace Test._Patterns_Designs.Observer
{
    using Client._Classes.AbstractFactories;
    using Client._Classes.AbstractProducts;
    using Client._Classes.Factories;
    using Client._Patterns_Designs.Observer;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ObserverHelperTests
    {
        private ObserverHelper _testClass;
        private string _name;

        public ObserverHelperTests()
        {
            _name = "TestValue583040278";
            _testClass = new ObserverHelper(_name);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ObserverHelper(_name);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new ObserverHelper(value));
        }

        [Fact]
        public void CanCallList()
        {
            // Act
            _testClass.List();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSubscribe()
        {
            // Arrange
            var provider = new ObserverHandler();

            // Act
            _testClass.Subscribe(provider);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallSubscribeWithNullProvider()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Subscribe(default(ObserverHandler)));
        }

        [Fact]
        public void CanCallUnsubscribe()
        {
            // Act
            _testClass.Unsubscribe();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallOnCompleted()
        {
            // Act
            _testClass.OnCompleted();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallOnError()
        {
            // Arrange
            var error = new Exception();

            // Act
            _testClass.OnError(error);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallOnErrorWithNullError()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnError(default(Exception)));
        }

        [Fact]
        public void CanCallOnNext()
        {
            // Arrange
            LevelFactory levelFactory = new Level1Factory();
            Interactable lever;
            lever = levelFactory.CreateInteractableLever();

            // Act
            _testClass.OnNext(lever);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallOnNextWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.OnNext(default(Interactable)));
        }

        [Fact]
        public void NameIsInitializedCorrectly()
        {
            Assert.Equal(_name, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1658303706";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetLevers()
        {
            // Arrange
            var testValue = new List<Interactable>();

            // Act
            _testClass.Levers = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Levers);
        }
    }
}