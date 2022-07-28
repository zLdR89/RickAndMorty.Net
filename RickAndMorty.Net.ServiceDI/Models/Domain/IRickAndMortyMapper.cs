using AutoMapper;

namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    internal interface IRickAndMortyMapper
    {
        IMapper Mapper { get; set; }
    }
}

