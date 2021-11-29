using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Services;
using WebApplication.Tree;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        
        [HttpGet]
        public IActionResult Calc()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Calc([FromServices] ICalculator calc, string expression)
        {
            ViewBag.Result = calc.Calculate(expression);
            return View();
        }
        
        
    }

    
}