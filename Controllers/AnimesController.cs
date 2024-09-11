using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Services;

namespace MyApp.Namespace;

[Route("api/[controller]")]
[ApiController]
public class AnimesController(ICommonService<AnimeDTO, AnimeInsertDTO, AnimeUpdateDTO> animeService, IConfiguration config) : ControllerBase
{
  private readonly ICommonService<AnimeDTO, AnimeInsertDTO, AnimeUpdateDTO> _animeService = animeService;
  private readonly IConfiguration _config = config;
  // [Authorize]
  [HttpGet("")]
  public async Task<IEnumerable<AnimeDTO>> Get() => await _animeService.Get();

  [HttpGet("generate")]
  public ActionResult<string> Generate()
  {
    var token = GenerateToken();
    Console.WriteLine($"El token generado: {token}");
    return Ok(new { Token = token });
  } 

  public string GenerateToken()
  {
    // Creates a new symmetric security key from the JWT key specified in the app configuration.
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? ""));

    // Sets up the signing credentials using the above security key and specifying the HMAC SHA256 algorithm.
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    // Defines a set of claims to be included in the token.
    var claims = new[]
    {
      new Claim(ClaimTypes.Name, "AllAnimes"),
    };

      // Creates a new JWT token with specified parameters including issuer, audience, claims, expiration time, and signing credentials.
    var token = new JwtSecurityToken
    (
      issuer: _config["Jwt:Issuer"],
      audience: _config["Jwt:Audience"],
      claims: claims,
      expires: DateTime.Now.AddHours(1), // Token expiration set to 1 hour from the current time.
      signingCredentials: credentials
    );

    // Serializes the JWT token to a string and returns it.
    return new JwtSecurityTokenHandler().WriteToken(token);
  }


}

