using System.Text;
using AutoFixture.Xunit2;
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
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Add_Should_Return_Zero_When_String_Is_Null_Or_Empty(string expectedNumbers)
        {
            // Arrange
            const int expected = 0;

            // Act
            var actual = _target.Add(expectedNumbers);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory, AutoData]
        public void Add_Should_Return_Single_Number(int number)
        {
            // Arrange
            var expected = number;
            var numbers = $"{number}";

            // Act
            var actual = _target.Add(numbers);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory, AutoData]
        public void Add_Should_Return_Sum(int number1, int number2)
        {
            // Arrange
            var expected = number1 + number2;
            var numbers = $"{number1},{number2}";

            // Act
            var actual = _target.Add(numbers);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory, AutoData]
        public void Add_Should_Return_Sum_N(int n)
        {
            // Arrange
            StringBuilder stringBuilder = new StringBuilder();
            int expected = 0;
            for (int i = 1; i <= n; i++)
            {
                expected += i;
                stringBuilder.Append(i);
                if (n != i)
                {
                    stringBuilder.Append(',');
                }
            }

            var numbers = stringBuilder.ToString();

            // Act
            var actual = _target.Add(numbers);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
