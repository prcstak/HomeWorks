using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hw10.hw10.Services
{
    public class CalculatorDecorator: ICalculator
    {
        protected ICalculator Calculator;
        
        public CalculatorDecorator(ICalculator calculator)
        {
            Calculator = calculator;
        }
        public override Task<string> Calculate(Expression node, Visitor visitor)
        {
            return Calculator.Calculate(node, visitor);
        }
    }
}