using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class CacheCalculator: CalculatorDecorator
    {
        private CalculatorContext Context;
        private Dictionary<Expression, Expression[]> Expressions { get; set; } = new();
        private Dictionary<Expression, decimal> Cache { get; } = new();
        
        public CacheCalculator(ICalculator calculator, CalculatorContext context): base(calculator)
        {
            Context = context;
        }

        public override async Task<string> Calculate(Expression node, Visitor visitor)
        {
            var cache = Context.Cache.Find(node.ToString());
            if (cache != null)
            {
                return cache.Value;
            }
            
            
            var result = await base.Calculator.Calculate(node, visitor);
            Context.Cache.Add(new Cache() {Expression = node.ToString(), Value = result});
            Context.SaveChanges();

            return result;
        }
    }
}