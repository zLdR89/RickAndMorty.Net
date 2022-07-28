using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RickAndMorty.Net.ServiceDI.Models.Domain;
using RickAndMorty.Net.ServiceDI.Models.Dto;

namespace RickAndMorty.Net.ServiceDI.Service
{
    internal abstract class BaseService
    {
        private HttpClient Client { get; }
        protected IMemoryCache MemoryCache;
        protected IRickAndMortyMapper RickAndMortyMapper { get; }

        protected BaseService(IRickAndMortyMapper rickAndMortyMapper,  IMemoryCache memoryCache, string baseAddress)
        {
            RickAndMortyMapper = rickAndMortyMapper;

            MemoryCache = memoryCache ??  new MemoryCache(new MemoryCacheOptions()); ;
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        protected async Task<T> Get<T>(string path)
        {
            var response = await Client.GetAsync(path);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()) : default(T);
        }

    }
}

