using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Backend_Csharp.Controllers
{
    [Route("probando")]
    [ApiController]
    public class ProbandoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> UrlParam(string Name, int Age)
        {
            return $"El Nombre del query fue: {Name} y tiene: {Age} años.";
        }

        [HttpGet("{Nombre}")]
        public ActionResult<string> RouteParam(string Nombre)
        {
            return $"El nombre del Param URL es: {Nombre}" ;
        }
        [HttpPost]
        public ActionResult<string> BodyParam(Personaje personaje)
        {
            return $"El personaje a crear tiene nombre: {personaje.Name} y edad: {personaje.Age}";
        }
    }

    public record class Personaje()
    {
        public string? Name { get; set;}
        public int? Age { get; set;}
    }
}
 