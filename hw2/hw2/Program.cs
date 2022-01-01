using System;
using System.Collections.Generic;
using IL;

namespace hw2
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 3) 
            {
                Console.WriteLine("Only two values");
                return 4;
            }
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