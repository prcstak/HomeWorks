using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using hw10.Tree;
using static hw10.Tree.ExpressionTreeBuilder;

namespace hw10.Services
{
    public class Calculator: ICalculator
    {
        private Dictionary<Expression, Expression[]> Expressions { get; set; } = new();
        public Dictionary<Expression, decimal> Cache { get; } = new();
        
        public override async Task<string> Calculate(Expression node, Visitor visitor)
        {
            visitor.Visit(node);
            Expressions = visitor.Nodes;
            var result = await CalculateAsync(node);

            return result.ToString();
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
    }
}