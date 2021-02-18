using FluentAssertions;
using Xunit;

namespace StringCalculator.UnitTests
{
    public class CalculatorUnitTests
    {
        private readonly Calculator _target;

        public CalculatorUnitTests()
        {
            _target = new Calculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1, 2, 3", 6)]
        [InlineData("1\n2, 3", 6)]
        public void Add_Should_Return_Correct_Sum_When_Numbers_Is_Valid(string expectedNumbers, int expected)
        {
            // Arrange
            // Act
            var actual = _target.Add(expectedNumbers);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
