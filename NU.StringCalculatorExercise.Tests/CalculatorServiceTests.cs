using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using NU.StringCalculatorExercise.Logic.Services;

namespace NU.StringCalculatorExercise.Tests
{
    // Should_ExpectedBehaviour_When_Condition

    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData("not an integer")]
        public void Should_ThrowException_When_InputIsText(string input)
        {
            // Arrange
            var calculatorService = new CalculatorService();

            // Act
            Action result = () => calculatorService.Calculate(input);   // On invoking this class, it should throw an exception

            // Assert
            result.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("")]    // No value
        [InlineData("     ")]    // Spaces should not count as input either
        public void Should_ReturnZero_When_InputIsBlank(string input)
        {
            // Arrange
            var calculatorService = new CalculatorService();

            // Act
            var result = calculatorService.Calculate(input);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("1")]   // Single value
        [InlineData("1,2")] // Two values
        [InlineData("25,75")] // Two larger values
        public void Should_ReturnSum_When_InputIsCommaSeparatedIntegers(string input)
        {
            // Arrange
            var calculatorService = new CalculatorService();
            var values = input.Split(',');
            var sum = values.Sum(int.Parse);

            // Act
            var result = calculatorService.Calculate(input);

            // Assert
            result.Should().Be(sum);
        }
    }
}
