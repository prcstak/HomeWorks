﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApplication.Services
{
    public class MyExpressionVisitor
    {
        public Dictionary<Expression, Expression[]> Nodes { get; set; } = new();

        public MyExpressionVisitor()
        {
            
        }

        public virtual Expression Visit(Expression node)
        {
            return Visit((dynamic) node);
        }

        protected Expression Visit(BinaryExpression node)
        {
            Nodes[node] = new[] {node.Left, node.Right};
            Visit(node.Left);
            Visit(node.Right);
            return node;
        }

        protected Expression Visit(ConstantExpression node)
        {
            Nodes[node] = Array.Empty<Expression>();
            return node;
        }
    }
}