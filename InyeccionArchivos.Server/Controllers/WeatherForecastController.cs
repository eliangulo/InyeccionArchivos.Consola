using Microsoft.AspNetCore.Mvc;
using InyeccionArchivos.Shared.Dto;

namespace InyeccionArchivos.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ServicioTransient transient1;
        private readonly ServicioTransient transient2;
        private readonly ServicioScoped scoped1;
        private readonly ServicioScoped scoped2;
        private readonly ServicioSingleton singleton;

        public WeatherForecastController(ServicioTransient transient1, ServicioTransient transient2,
                                         ServicioScoped scoped1, ServicioScoped scoped2,
                                         ServicioSingleton singleton)
        {
            this.transient1 = transient1;
            this.transient2 = transient2;
            this.scoped1 = scoped1;
            this.scoped2 = scoped2;
            this.singleton = singleton;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            HttpContext.Response.Headers.Add("nuevoClave", "nuevoValor");
            BadRequest();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public ActionResult<int> Post(WeatherForecast DTO)
        {
            return 1;
            //return BadRequest();
        }

        [HttpGet("valores")]
        public ActionResult GetValores()
        {
            return Ok(new
            {
                transients = new { transient1 = transient1.ObtenerGuid, transient2 = transient2.ObtenerGuid },
                scopeds = new { scoped1 = scoped1.ObtenerGuid, scoped2 = scoped2.ObtenerGuid },
                singleton = singleton.ObtenerGuid
            });
        }
    }
}