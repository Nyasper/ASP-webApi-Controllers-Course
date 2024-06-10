using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        public IActionResult Get() => Ok("Animes controllers aqui");
    }
}
