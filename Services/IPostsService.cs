using Proyecto_Backend_Csharp.DTOs;

namespace Proyecto_Backend_Csharp.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get(); //IEnumerable es como una lista pero con mas rendimieto y es solo lectura
    }
}
