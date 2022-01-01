using System;
using System.Collections.Generic;
using System.Text;

namespace hw1
{
    public static class Calculator
    {
        public static int Calculate(string op, int arg1, int arg2)
        {
            var result = op switch
            {
                "+" => arg1 + arg2,
                "-" => arg1 - arg2,
                "*" => arg1 * arg2,
                "/" => arg1 / arg2,
                _ => 0,
            };
            return result;
        }
    }
}
