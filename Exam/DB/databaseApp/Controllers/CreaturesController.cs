using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using databaseApp.DataBase;
using databaseApp.Models;
using databaseApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace databaseApp.Controllers
{
    [ApiController]
    public class Creatures : ControllerBase
    {

        [HttpGet]
        [Route("Creatures")]
        public string Get([FromServices] IDataGet ctx)
        {
            return ctx.DataGet();
        }
    }
}