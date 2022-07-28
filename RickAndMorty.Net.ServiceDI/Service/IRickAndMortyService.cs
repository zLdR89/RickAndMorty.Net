using RickAndMorty.Net.ServiceDI.Models.Domain;

namespace RickAndMorty.Net.ServiceDI.Service
{
    public interface IRickAndMortyService
    {
        Task<Character> GetCharacter(int id);

        Result<Character> GetAllCharactersCached();

        Task<Result<Character>> GetAllCharacters();

        Task<Result<Character>> FilterCharacters(string name = "");
    }
}

