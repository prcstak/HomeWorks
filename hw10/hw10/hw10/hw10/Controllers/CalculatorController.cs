using System.Threading.Tasks;
using hw10.hw10.Services;
using hw10.Models;
using hw10.Tree;
using Microsoft.AspNetCore.Mvc;

namespace hw10.hw10.Controllers
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