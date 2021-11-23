using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Services;

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
        public IActionResult Calc([FromServices] Calculator calc, string expression)
        {
            ViewBag.Result = calc.Calculate(expression);
            return View();
        }
        
        
    }

    
}