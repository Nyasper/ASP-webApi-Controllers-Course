namespace Proyecto_Backend_Csharp.DTOs
{
    public record class PostDto
    {
        public int id { get; set; }
        public int userId { get; set; } 
        public string? Title { get; set; }
        public string? Body { get; set; } 
    }
}
