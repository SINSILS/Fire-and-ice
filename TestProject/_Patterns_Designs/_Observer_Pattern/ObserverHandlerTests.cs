namespace Test._Patterns_Designs.Observer
{
    using Client._Classes.AbstractFactories;
    using Client._Classes.AbstractProducts;
    using Client._Classes.Factories;
    using Client._Patterns_Designs.Observer;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ObserverHandlerTests
    {
        private ObserverHandler _testClass;

        public ObserverHandlerTests()
        {
            _testClass = new ObserverHandler();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ObserverHandler();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallSubscribe()
        {
            // Arrange
            ObserverHelper observer = new ObserverHelper("Observer I");

            // Act
            var result = _testClass.Subscribe(observer);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallSubscribeWithNullObserver()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Subscribe(default(IObserver<Interactable>)));
        }

        [Fact]
        public void CanCallAddApplication()
        {
            // Arrange
            LevelFactory levelFactory = new Level1Factory();
            Interactable lever = levelFactory.CreateInteractableLever();
            _testClass.AddApplication(lever);

            // Act
            _testClass.AddApplication(lever);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallAddApplicationWithNullApp()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddApplication(default(Interactable)));
        }

        [Fact]
        public void CanCallCloseApplications()
        {
            // Act
            _testClass.CloseApplications();

            // Assert
            throw new NotImplementedException("Create or modify test");
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

    public class UnsubscriberTests
    {
        private Unsubscriber _testClass;
        private List<IObserver<Interactable>> _observers;
        private IObserver<Interactable> _observer;

        public UnsubscriberTests()
        {
            _observers = new List<IObserver<Interactable>>();
            _testClass = new Unsubscriber(_observers, _observer);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Unsubscriber(_observers, _observer);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullObserver()
        {
            Assert.Throws<ArgumentNullException>(() => new Unsubscriber(new List<IObserver<Interactable>>(), default(IObserver<Interactable>)));
        }

        [Fact]
        public void CanCallDispose()
        {
            // Act
            _testClass.Dispose();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}