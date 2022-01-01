using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Tree;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {

        private readonly CalculatorContext Context;

        public CalculatorController(CalculatorContext context)
        {
            Context = context;
        }
        
        [HttpGet]
        public IActionResult Calc()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Calc(string expression)
        {
            var calc = new CacheCalculator(new Calculator(), Context);
            var visitor = new Visitor();
            var tree = ExpressionTreeBuilder.MakeTree(expression);
            ViewBag.Result = await calc.Calculate(tree, visitor);
            return View();
        }
    }
}