using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class CalculatorDecorator: ICalculator
    {
        protected ICalculator Calculator;
        
        public CalculatorDecorator(ICalculator calculator)
        {
            Calculator = calculator;
        }
        public override Task<string> Calculate(Expression node, MyExpressionVisitor visitor)
        {
            return Calculator.Calculate(node, visitor);
        }
    }
}