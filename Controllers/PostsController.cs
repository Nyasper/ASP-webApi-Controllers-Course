using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Services;

namespace Proyecto_Backend_Csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titlesServices;
        public PostsController(IPostsService titlesServices)
        {
            _titlesServices = titlesServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() =>
            await _titlesServices.Get();
    }
}
