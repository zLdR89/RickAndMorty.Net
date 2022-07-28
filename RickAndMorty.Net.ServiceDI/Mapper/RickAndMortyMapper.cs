using System;
using System.Linq;
using AutoMapper;
using RickAndMorty.Net.ServiceDI.Models.Domain;
using RickAndMorty.Net.ServiceDI.Models.Dto;

namespace RickAndMorty.Net.ServiceDI.Mapper
{
    internal class RickAndMortyMapper
    {

        internal static IRickAndMortyMapper Resolve()
        {

            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<ResultDto<CharacterDto>, Result<Character>>().ConstructUsing(cls => new Result<Character>(
                    new Info(cls.Info.Count, cls.Info.Pages, cls.Info.Next, cls.Info.Prev), cls.Results.Select(x => new Character(x.Id, x.Name, x.Status,
                            x.Species, x.Type, x.Gender,
                            new CharacterLocation(x.Location.Name, x.Location.Url),
                            new CharacterOrigin(x.Origin.Name, x.Origin.Url),
                            x.Url, x.Episode.ToList(),
                            x.Url, String.IsNullOrWhiteSpace(x.Created) ? DateTime.MinValue : DateTime.Parse(x.Created)))
                )); 


                cfg.AllowNullCollections = true;
            });

            return new RickAndMorty.Net.ServiceDI.Models.Domain.RickAndMortyMapper { Mapper = config.CreateMapper() };
        }
    }
}
