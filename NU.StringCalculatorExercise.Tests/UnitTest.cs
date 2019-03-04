using FluentAssertions;
using Xunit;

namespace NU.StringCalculatorExercise.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var t = true;
            t.Should().Be(true);
        }
    }
}
