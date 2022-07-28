using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Net.ServiceDI.Service;
using RickAndMorty.Net.ServiceDI.Models.Domain;

namespace RickAndMorty.Net.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{


    private readonly IRickAndMortyService _service;

    public CharacterController(IRickAndMortyService service)
    {
        _service = service;
    }


    [HttpGet(Name = "getCharacters")]
    public async Task<Result<Character>> GetCharacters(string? name)
    {
        return String.IsNullOrWhiteSpace(name) ? await _service.GetAllCharacters() : await _service.FilterCharacters(name);
    }

    [HttpGet("{id}")]
    public async Task<Character> GetCharacter(int id) {

        return await _service.GetCharacter(id);
    }


}
