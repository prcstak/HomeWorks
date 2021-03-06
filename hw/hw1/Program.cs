using hw1;
using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        static int Main(string[] args)
        {
            var parserResult = Parser.TryParseValues(args, out var arg1, out var arg2, out var op);

            if (parserResult != 0)
            {
                return parserResult;
            }

            var result = Calculator.Calculate(args[1], arg1, arg2);

            Console.Write($"{arg1} {op} {arg2} = {result}");

            return 0;
            
        }
    }
}