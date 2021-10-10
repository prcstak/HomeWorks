using System;
using Calc;

namespace Calclator
{
    class Program
    {
        static int Main(string[] args)
        {
            var parseResult = Parser.TryParseValues(args, out var val1, out var val2, out var operation);
            
            if (parseResult != 0)
            {
                return parseResult;
            }

            var result = Calculator.Calculate(val1, val2, operation);
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} = {result}");
            return 0;
        }
    } 
}