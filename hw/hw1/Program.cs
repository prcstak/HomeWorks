using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        static int Main(string[] args)
        {

            if (!int.TryParse(args[0], out int arg1))
            {
                Console.WriteLine(args[0] + args[1] + args[2] + " Incorrect arguments ");
                return 1;
            }
            if (!int.TryParse(args[2], out int arg2))
            {
                Console.WriteLine(args[0] + args[1] + args[2] + " Incorrect arguments ");
                return 1;
            }
            var availableOperation = new List<string> { "+", "-", "*", "/", };
            if (!availableOperation.Contains(args[1]))
            {
                Console.WriteLine(args[0] + args[1] + args[2] + " Incorrect operation ");
                return 2;
            }


            var result = args[1] switch
            {
                "+" => arg1 + arg2,
                "-" => arg1 - arg2,
                "*" => arg1 * arg2,
                "/" => arg1 / arg2,
                _ => 0,
            };


            Console.Write(args[0] + args[1] + args[2] + $"={result}");
            return 0;
        }
    }
}