using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using WebApplication.Tree;
using static WebApplication.Tree.ExpressionTreeBuilder;

namespace WebApplication.Services
{
    public class Calculator : ExpressionVisitor, ICalculator
    {
        public Dictionary<Expression, Expression[]> Expressions = new();
        private ICalculator _calculatorImplementation;
        private Dictionary<Expression, decimal> Cache { get; } = new();
        

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Expressions[node] = new[] {node.Left, node.Right};
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Expressions[node] = Array.Empty<Expression>();
            return node;
        }

        private Expression[] GetDependencies(Expression expression)
        {
            return Expressions.TryGetValue(expression, out var dependencies)
                ? dependencies
                : Array.Empty<Expression>();
        }
        
        private async Task<decimal> CalculateAsync(Expression node)
        {
            await Task.WhenAll(GetDependencies(node).Select(CalculateAsync));
            await GetValueAsync(node);

            return Cache[node];
        }

        async Task GetValueAsync(Expression node)
        {
            if (node.NodeType == ExpressionType.Constant)
            {
                Cache[node] = (decimal) ((ConstantExpression) node).Value;
            }

            else
            {
                var binaryNode = (BinaryExpression) node;
                var left = Cache[binaryNode.Left];
                var right = Cache[binaryNode.Right];
                await Task.Delay(1000);
                Cache[node] = binaryNode.NodeType switch
                {
                    ExpressionType.Add      => left + right,
                    ExpressionType.Subtract => left - right,
                    ExpressionType.Multiply => left * right,
                    ExpressionType.Divide   => left / right,
                    _                       => Cache[node]
                };
            }
        }

        public async Task<decimal> Calculate(Expression node)
        {
            Visit(node);
            var result = await CalculateAsync(node);

            return result;
        }

        public string Calculate(string expression)
        {
            var tree = ExpressionTreeBuilder.MakeTree(expression);
            return Calculate(tree).Result.ToString();
        }
    }
}