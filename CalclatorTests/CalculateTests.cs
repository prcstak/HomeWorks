using Calc;
using Xunit;

namespace CalclatorTests
{
    public static class CalculatorTest
    {

        [Xunit.Theory]
        [InlineData("+", 2, 2, 4)]
        [InlineData("-", 2, 2, 0)]
        [InlineData("/", 4, 2, 2)]
        [InlineData("*", 3, 2, 6)]

        static void CalculateTest(string op, int arg1, int arg2, int expect)
        {
            var act = MyFsCalculator.Calculate(arg1, op, arg2);

            Assert.Equal(expect, act);
        }

        [Xunit.Theory]
        [InlineData("b", 2, 2, 0)]
        [InlineData("", 3, 3, 0)]
        public static void CalculateTest_result0(string op, int arg1, int arg2, int expect)
        {
            var act = MyFsCalculator.Calculate(arg1, op, arg2);

            Assert.Equal(expect, act);
        }
    }
}