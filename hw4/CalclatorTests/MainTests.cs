using Calclator;
using Xunit;


namespace CalclatorTests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new[] {"6", "-", "4"}, 0)]
        [InlineData(new[] {"0", "+", "-"}, 1)]
        [InlineData(new[] {"2", "aa", "2"}, 2)]
        public void MainTest(string[] args, int expected)
        {
            // Arrange & act
            var actual = Program.Main(args);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}