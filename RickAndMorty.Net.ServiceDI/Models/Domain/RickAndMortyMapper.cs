using AutoMapper;

namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    internal class RickAndMortyMapper : IRickAndMortyMapper
    {
        public IMapper? Mapper { get; set; }
    }
}

