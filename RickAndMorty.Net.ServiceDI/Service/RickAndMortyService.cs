using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RickAndMorty.Net.ServiceDI.Models.Domain;
using RickAndMorty.Net.ServiceDI.Models.Dto;


namespace RickAndMorty.Net.ServiceDI.Service
{
    internal class RickAndMortyService : BaseService, IRickAndMortyService
    {
        

        public RickAndMortyService( IRickAndMortyMapper rickAndMortyMapper, IMemoryCache memoryCache = null, string baseAddress = "https://rickandmortyapi.com/" ) : base(rickAndMortyMapper, memoryCache , baseAddress )
        {
           
        }

        public async Task<Character> GetCharacter(int id)
        {
            var dto = await Get<Character>($"api/character/{id}");
            return RickAndMortyMapper.Mapper.Map<Character>(dto);
        }


        public Result<Character> GetAllCharactersCached()
        {
            return MemoryCache.Get<Result<Character>>("characters");
        }

        public async Task<Result<Character>> GetAllCharacters()
        {
            //var dto = await GetAll<Character>("api/character/");
            //return RickAndMortyMapper.Mapper.Map<IEnumerable<Character>>(dto);
            if (MemoryCache is not null)
            {
                var charactersCache = GetAllCharactersCached();
                if (charactersCache is not null)
                    return charactersCache;
            }


            var dto = await Get<Result<Character>>("api/character/");
            var characters = RickAndMortyMapper.Mapper.Map<Result<Character>>(dto);

            if (MemoryCache is not null)
                MemoryCache.Set("characters", characters, TimeSpan.FromMinutes(1));

            return characters;

        }

        public async Task<Result<Character>> FilterCharacters(string name = "")
        {
            var dto = await Get<Result<Character>>($"/api/character?name={name}");
            return RickAndMortyMapper.Mapper.Map<Result<Character>>(dto);
        }

    }
}
