using System;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new []{"2", "plus", "2"}, "4")]
        [InlineData(new []{"b", "plus", "2"}, "Incorrect argument")]
        [InlineData(new []{"2", "+", "2"}, "OperationNotSupported")]
        [InlineData(new []{"2", "divide", "0"}, "DividingByZero")]
        public void Errors(string[] args, string expected)
        {
            var res = Calculator.Calculate.go(args);
            
            Assert.Equal(expected, res);
        }
    }
}