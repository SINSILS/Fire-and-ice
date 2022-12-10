namespace Test._Patterns_Designs._Composite_Pattern
{
    using Client._Classes;
    using Client._Classes.Factories;
    using Client._Patterns_Designs._Composite_Pattern;
    using System;
    using Xunit;

    public class GroupedEnemyTests
    {
        private class TestGroupedEnemy : GroupedEnemy
        {
            public TestGroupedEnemy() : base()
            {
            }

            public override void Display(int depth)
            {
            }

            public override bool IsEnemy()
            {
                return default(bool);
            }
        }

        private TestGroupedEnemy _testClass;

        public GroupedEnemyTests()
        {
            _testClass = new TestGroupedEnemy();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TestGroupedEnemy();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallAdd()
        {
            // Arrange
            Enemy enemy = EnemyFactory.getEnemy("SpeedDemon");

            // Act
            _testClass.Add(enemy);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallAddWithNullC()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Add(default(GroupedEnemy)));
        }

        [Fact]
        public void CanCallRemove()
        {
            // Arrange
            Enemy enemy = EnemyFactory.getEnemy("SpeedDemon");

            // Act
            _testClass.Remove(enemy);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CannotCallRemoveWithNullC()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.Remove(default(GroupedEnemy)));
        }
    }
}