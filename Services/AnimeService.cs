using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Backend_Csharp.DTOs;
using Proyecto_Backend_Csharp.Models;
using Proyecto_Backend_Csharp.Repository;

namespace Proyecto_Backend_Csharp.Services;

public class AnimeService(AniContext context, IMapper mapper) : ICommonService<AnimeDTO, AnimeInsertDTO, AnimeUpdateDTO>
{
private readonly DbSet<Anime> _animeContext = context.Animes;
  private readonly IMapper _mapper = mapper;

  public List<string> Errors => throw new NotImplementedException();

  public Task<AnimeDTO> Add(AnimeInsertDTO ItemToInsertDTO)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<AnimeDTO>> Get()
  {
    var Animes = await _animeContext.ToListAsync();
    return Animes.Select(mapper.Map<AnimeDTO>);
  }

  public Task<AnimeDTO?> DeleteById(int Id)
  {
      throw new NotImplementedException();
  }



  public Task<AnimeDTO?> GetById(int Id)
  {
      throw new NotImplementedException();
  }

  public Task<AnimeDTO?> Update(int Id, AnimeUpdateDTO ItemToUpdate)
  {
      throw new NotImplementedException();
  }

  public bool Validate(AnimeInsertDTO InsertDto)
  {
      throw new NotImplementedException();
  }

  public bool Validate(AnimeUpdateDTO UpdateDto)
  {
      throw new NotImplementedException();
  }

  public string GenerateToken()
  {
    try
    {
       List<Claim> claims = 
    [
      new Claim(JwtRegisteredClaimNames.Sub, "AllAnimes"),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new Claim(JwtRegisteredClaimNames.Name, "Gon")
    ];
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("una_clave_secreta_super_segura_y_larga"));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken
    (
      issuer: "tu_issuer",
      audience: "tu_audience",
      claims: claims,
      expires: DateTime.Now.AddMinutes(30),
      signingCredentials: creds
    );

   var GeneratedToken = new JwtSecurityTokenHandler().WriteToken(token);
   Console.WriteLine($"El token generado: {GeneratedToken}");
  return GeneratedToken;
    }
    catch (System.Exception)
    {
      
      Console.WriteLine("ERROR al general el token");
    }
   return "";
  }
}
