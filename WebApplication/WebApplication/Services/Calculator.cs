using System;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using static WebApplication.Tree.ExpressionTreeBuilder;

namespace WebApplication.Services
{
    public class Calculator
    {
        public string Calculate(string expression)
        {
            var expressionTree = MakeTree(expression);
            return CalclateAsync(expressionTree).Result.ToString();
        }

        public static async Task<decimal> CalclateAsync(Expression node)
        {
            if (node is ConstantExpression constant)
            { 
                return await Task.FromResult((decimal) constant.Value);
            }
            
            var binaryNode = (BinaryExpression) node;
            var left = CalclateAsync(binaryNode.Left);
            var right = CalclateAsync(binaryNode.Right);
            Task.WaitAll(left, right);
            
            return binaryNode.NodeType switch
            {
                ExpressionType.Add => left.Result + right.Result,
                ExpressionType.Subtract => left.Result + right.Result,
                ExpressionType.Multiply => left.Result + right.Result,
                ExpressionType.Divide => left.Result + right.Result,
            };
        }
    }
}