using System;
using Microsoft.Extensions.Caching.Memory;
using RickAndMorty.Net.ServiceDI.Mapper;
using RickAndMorty.Net.ServiceDI.Service;

namespace RickAndMorty.Net.ServiceDI.Factory
{
    public abstract class RickAndMortyFactory
    {
        public static IRickAndMortyService Create()
        {
            var mapper = RickAndMortyMapper.Resolve();

            var service = new RickAndMortyService(mapper);

            return service;
        }

        public static IRickAndMortyService Create(IMemoryCache memoryCache)
        {

            var mapper = RickAndMortyMapper.Resolve();

            var service = new RickAndMortyService(mapper, memoryCache);

            return service;
        }
        public static IRickAndMortyService Create(IMemoryCache memoryCache, string url )
        {

            var mapper = RickAndMortyMapper.Resolve();

            var service = new RickAndMortyService(mapper, memoryCache, url );

            return service;
        }
    }
}

