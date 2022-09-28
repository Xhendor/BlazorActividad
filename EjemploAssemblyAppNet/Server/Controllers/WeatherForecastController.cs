using EjemploAssemblyAppNet.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploAssemblyAppNet.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("/kelvin")]
        public IEnumerable<WeatherForecast> Kelvin()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55)+273,
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/kelvin/{numero}/{coco}")]
        public string Kelvin(long numero,string coco)
        {
            return "Tu numero de la suerte es:" + numero +", buen dia "+coco;
        }
        [HttpGet("/op/{numeroA}/{numeroB}/{ope}")]
        public Operacion operaciones(int numeroA,int numeroB, string ope)
        {
            float resultado=0;
            switch (ope) {
                case "+":
                    resultado = numeroA + numeroB;
                    break;
                case "-":
                    resultado = numeroA - numeroB;

                    break;
                case "*":
                    resultado = numeroA * numeroB;

                    break;
                case "/":
                    resultado = numeroA / numeroB;
                    break;

            }

            return new Operacion(numeroA, numeroB, resultado);
        }

        [HttpPost("/op")]
        public Operacion operacionesPost(Operacion operacionToDo)
        {
            switch (operacionToDo.OperacionAritmetica)
            {
                case "+":
                    operacionToDo.Resultado = operacionToDo.NumeroA + operacionToDo.NumeroB;
                    break;
                case "-":
                    operacionToDo.Resultado = operacionToDo.NumeroA - operacionToDo.NumeroB;

                    break;
                case "*":
                    operacionToDo.Resultado = operacionToDo.NumeroA * operacionToDo.NumeroB;

                    break;
                case "/":
                    operacionToDo.Resultado = operacionToDo.NumeroA / operacionToDo.NumeroB;
                    break;

            }

            return operacionToDo;
        }
    }
}
