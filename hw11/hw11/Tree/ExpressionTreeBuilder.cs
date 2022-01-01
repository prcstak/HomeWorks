using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApplication.Tree
{
    public static class ExpressionTreeBuilder
    {
        public static Expression MakeTree(string input)
        {
            var postfixform = ToPostfix.ConvertToPostFix(input);
            var l = postfixform.Length - 1;
            var posfix = postfixform.Substring(0, l);
            var variableStack = new Stack<Expression>();

            foreach (var v in posfix.Split(' '))
            {
                if (decimal.TryParse(v, out decimal variable))
                    variableStack.Push(Expression.Constant(variable));
                else
                {
                    var right = variableStack.Pop();
                    var left = variableStack.Pop();
                    var node = v switch
                    {
                        "+" => Expression.Add(left, right),
                        "-" => Expression.Subtract(left, right),
                        "*" => Expression.Multiply(left, right),
                        "/" => Expression.Divide(left, right)
                    };
                    variableStack.Push(node);
                }
            }
            return variableStack.Pop();
        }
    }
}