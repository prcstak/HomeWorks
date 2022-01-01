using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace hw10.Services
{
    public class Visitor: ExpressionVisitor
    {
        public Dictionary<Expression, Expression[]> Nodes { get; set; } = new();

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Nodes[node] = new[] {node.Left, node.Right};
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Nodes[node] = Array.Empty<Expression>();
            return node;
        }
    }
}