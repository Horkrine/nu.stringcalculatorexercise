using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace NU.StringCalculatorExercise.Tests
{
    // Should_ExpectedBehaviour_When_Condition

    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData("")]
        public void Should_ThrowException_When_NotIntegers(string input)
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
