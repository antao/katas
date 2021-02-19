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
        [InlineData("1, 2", 3)]
        [InlineData("1, 2, 3", 6)]
        [InlineData("1\n2, 3", 6)]
        [InlineData("//;\n", 0)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//$\n40$2", 42)]
        [InlineData("//*\n40*2", 42)]
        public void Add_Should_Return_Correct_Sum_When_Numbers_And_Delimiters_Are_Valid(string expectedNumbers, int expected)
        {
            // Arrange
            // Act
            var actual = _target.Add(expectedNumbers);

            // Assert
            actual.Should().Be(expected);
        }
	}
}
