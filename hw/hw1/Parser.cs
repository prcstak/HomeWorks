using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw1
{
    class Parser
    {
        private static readonly List<string> availableOperation = new List<string>{ "+", "-", "*", "/", };

        public static int TryParseValues(string[] args, out int arg1, out int arg2, out string op)
        {
            var isArg1Int = int.TryParse(args[0], out arg1);
            var isArg2Int = int.TryParse(args[2], out arg2);
            op = args[1];
            if (!isArg1Int || !isArg2Int)
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} Incorrect arguments ");
                return 1;
            }

            if (!availableOperation.Contains(op))
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} Incorrect arguments ");
                return 2;
            }

            return 0;
        }
    }
}
