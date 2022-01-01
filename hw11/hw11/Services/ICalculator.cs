using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public abstract class ICalculator
    {
        public abstract Task<string> Calculate(Expression node, MyExpressionVisitor visitor);
    }
}