using System;
using Xunit;
using IL;

namespace hw.tests
{
    public static class CalculatorTests
    {
        [Theory]
        [InlineData("-", 2, 2, 0)]
        [InlineData("+", 1, 2, 3)]
        [InlineData("/", 4, 2, 2)]
        [InlineData("*", 3, 2, 6)]

        static void CalculateTest(string op, int arg1, int arg2, int expect)
        {
            var act = Calculator.Calculate(op, arg1, arg2);

            Assert.Equal(expect, act);
        }
    }
}