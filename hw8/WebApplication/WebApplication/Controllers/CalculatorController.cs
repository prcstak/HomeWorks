using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet("add")]
        public IActionResult Plus([FromServices] Calculator calc, decimal arg1, decimal arg2)
        {
            return Content(calc.Add(arg1, arg2));
        }
        
        [HttpGet("sub")]
        public IActionResult Sub([FromServices] Calculator calc, decimal arg1, decimal arg2)
        {
            return Content(calc.Sub(arg1, arg2));
        }
        
        [HttpGet("mult")]
        public IActionResult Mult([FromServices] Calculator calc, decimal arg1, decimal arg2)
        {
            return Content(calc.Mult(arg1, arg2));
        }
        
        [HttpGet("div")]
        public IActionResult Div([FromServices] Calculator calc, decimal arg1, decimal arg2)
        {
            return Content(calc.Div(arg1, arg2));
        }
        
    }

    
}