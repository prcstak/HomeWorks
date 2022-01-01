using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw10.Services
{
    public abstract class ICalculator
    {
        public abstract Task<string> Calculate(Expression node, Visitor visitor);
    }
}