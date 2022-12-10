namespace Test._Classes
{
    using Client._Classes;
    using Xunit;
    using System;

    public class ScoreTests
    {
        private Score _testClass;

        public ScoreTests()
        {
            _testClass = Score.getInstance();
        }

        [Fact]
        public void CanCallgetInstance()
        {
            // Act
            var result = Score.getInstance();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CanCallincreaseScore()
        {
            // Arrange
            var firstScoreValue = _testClass.value;
            var x = 545480745;

            // Act
            _testClass.increaseScore(x);

            // Assert
            Assert.NotEqual(firstScoreValue, _testClass.value);
        }

        [Fact]
        public void CanSetAndGetvalue()
        {
            // Arrange
            var testValue = 724016163;

            // Act
            _testClass.value = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.value);
        }
    }
}