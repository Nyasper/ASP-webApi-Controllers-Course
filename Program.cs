using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Proyecto_Backend_Csharp;
using Proyecto_Backend_Csharp.Models;
using Proyecto_Backend_Csharp.Repository;
using Proyecto_Backend_Csharp.Services;
using Proyecto_Backend_Csharp.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Dpendency Injection

//services (custom services)
// builder.Services.AddScoped<ICommonService<CharacterDTO, CharacterInsertDTO, CharacterUpdateDTO>, CharacterService>();
builder.Services.AddMyServices();


//comparacion 3 tipos de DI(Singleton, Scoped, Transient)
builder.Services.AddKeyedSingleton<IRandomService, RandomService>("RandomSingleton");
builder.Services.AddKeyedScoped<IRandomService, RandomService>("RandomScoped");
builder.Services.AddKeyedTransient<IRandomService, RandomService>("RandomTransient");

//HTTP client
builder.Services.AddHttpClient<IPostsService, PostsService>(c=>
{
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
});

//Repository
builder.Services.AddScoped<IRepository<Character>, CharacterRepository>();

//Entity Framework DBContext postgresql
//probar despues: builder.Services.AddSqlite<AniContext>(ConnString);
builder.Services.AddDbContext<AniContext>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AniConnection")); 
});

//Validators
builder.Services.AddScoped<IValidator<CharacterInsertDTO>,CharacterInsertValidator>();
builder.Services.AddScoped<IValidator<CharacterUpdateDTO>,CharacterUpdateValidator>();

//AutoMappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Custom Middleware
app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Method} on {context.Request.Path}");
    await next(context);
});

app.Run();
