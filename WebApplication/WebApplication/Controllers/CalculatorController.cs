using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.ExceptionHandler;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Tree;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> Logger;
        private readonly CalculatorContext Context;

        public CalculatorController(CalculatorContext context, ILogger<CalculatorController> logger)
        {
            Context = context;
            Logger = logger;
        }

        [HttpGet]
        public IActionResult Calc()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calc(string expression)
        {
            IExceptionHandler handler = new ExceptionHandler.ExceptionHandler(Logger);
            var calc = new CacheCalculator(new Calculator(), Context);
            var visitor = new MyExpressionVisitor();
            try
            {
                var tree = ExpressionTreeBuilder.MakeTree(expression);
                ViewBag.Result = await calc.Calculate(tree, visitor);
                return View();
            }
            catch (Exception e)
            {
                handler.Aggregate(e);
                ViewBag.Result = "Check Log";
            }
            return View();
        }
    }
}