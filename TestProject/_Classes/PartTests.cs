namespace Test._Classes
{
    using Client._Classes;
    using System;
    using Xunit;

    public class PartTests
    {
        private Part _testClass;
        private string _name;
        private int _value;

        public PartTests()
        {
            _name = "TestValue1088908431";
            _value = 16954871;
            _testClass = new Part(_name, _value);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Part(_name, _value);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidName(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new Part(value, 972261948));
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
            var testValue = "TestValue2118495782";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void ValueIsInitializedCorrectly()
        {
            Assert.Equal(_value, _testClass.Value);
        }

        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var testValue = 553199601;

            // Act
            _testClass.Value = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Value);
        }
    }
}