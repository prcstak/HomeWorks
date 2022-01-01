using System;
using System.Linq.Expressions;

namespace WebApplication.Services
{
    public interface ICalculator
    {
        public string Calculate(string expression);
    }
}