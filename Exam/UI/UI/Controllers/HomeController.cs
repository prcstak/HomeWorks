using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;
using System.Text.Json;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        static readonly HttpClient _client = new HttpClient();
        
        [HttpGet]
        public IActionResult UserInput()
        {
            return View(new UserInput());
        }
        
        [HttpPost]
        public async Task<IActionResult> UserInput([FromForm] UserInput input)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage dbResponse = await _client.GetAsync("https://localhost:5002/Creatures");
                var monster = await dbResponse.Content.ReadAsStringAsync(); //json-monster
                var hero = JsonSerializer.Serialize(input); //json-hero
                HttpResponseMessage businessRespones = 
                    await _client.GetAsync($"https://localhost:5003/GetData?jsonMonsters={monster}&jsonHero={hero}");
                var result = businessRespones.Content.ReadAsStringAsync().Result;
                var log = JsonSerializer.Deserialize<Log>(result);
                ViewData.Add("Log", log);
                return View(input);
            }
            else
            {
                return View(input);
            }
        }
    }
}