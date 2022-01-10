using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BL.Controllers
{
    [ApiController]
    public class BusinessLogicController : Controller
    {
        [HttpGet]
        [Route("GetData")]
        public string GetData(string jsonMonsters, string jsonHero)
        {
            Creature monster = JsonSerializer.Deserialize<Creature>(jsonMonsters);
            Hero hero = JsonSerializer.Deserialize<Hero>(jsonHero);
            var log = new Battle.Battle(monster, hero).Fighting();
            
            return JsonSerializer.Serialize(log);
        }
    }
}