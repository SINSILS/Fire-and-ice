namespace Test._Patterns_Designs._Composite_Pattern
{
    using Client._Classes;
    using Client._Patterns_Designs._Composite_Pattern;
    using System;
    using Xunit;

    public class ArmyTests
    {
        private Army _testClass;

        public ArmyTests()
        {
            _testClass = new Army();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Army();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallAdd()
        {
            _testClass.Add(new SpeedDemon(5, 1));

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallAddWithNullEnemy()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Add(default(GroupedEnemy)));
        }

        [Fact]
        public void CanCallRemove()
        {
            // Act
            _testClass.Remove(new SpeedDemon(5, 1));

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallRemoveWithNullEnemy()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Remove(default(GroupedEnemy)));
        }

        [Fact]
        public void CanCallDisplay()
        {
            // Arrange
            var depth = 1680583577;

            // Act
            _testClass.Display(depth);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallIsEnemy()
        {
            // Act
            var result = _testClass.IsEnemy();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}