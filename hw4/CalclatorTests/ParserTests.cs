using System.Runtime.InteropServices;
using Xunit;
using Calc;

namespace CalclatorTests
{
    public static class ParserTest
    {
        [Theory]
        [InlineData(new[] {"2", "+", "3"}, 0)]
        [InlineData(new[] {"6", "-", "4"}, 0)]
        public static void TryParseTest_result0(string[] args, int expect)
        {
            var act = Parser.TryParseValues(args, out var arg1, out var arg2, out var op);
            Assert.Equal(expect, act);
        }

        [Theory]
        [InlineData(new[]{"a", "+", "a"}, 1)]
        [InlineData(new[]{"", "+", ""}, 1)]
        public static void TryParseTest_result1(string[] args, int expect)
        {
            var act = Parser.TryParseValues(args, out var arg1, out var arg2, out var op); 
            Assert.Equal(expect, act);
        }

        [Theory]
        [InlineData(new[]{"2", "", "2"}, 2)]
        [InlineData(new[]{"2", "a", "2"}, 2)]
        public static void TryParseTest_result2(string[] args, int expect)
        {
            var act = Parser.TryParseValues(args, out var arg1, out var arg2, out var op); 
            Assert.Equal(expect, act);
        }

        [Theory]
        [InlineData("+", true)]
        [InlineData("-", true)]
        [InlineData("/", true)]
        [InlineData("*", true)]
        [InlineData("a", false)]
        public static void isSupportedTests(string op, bool expect)
        {
            var act = Parser.isSupported(op);
            Assert.Equal(expect, act);
        }
    }
}