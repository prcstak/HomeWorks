using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface ICalculator 
    {
        public string Calculate(string expression);
    }
}