using Xunit;
using Microsoft.Extensions.Caching.Memory;
using RickAndMorty.Net.ServiceDI.Factory;
using RickAndMorty.Net.ServiceDI.Models.Domain;
using RickAndMorty.Net.ServiceDI.Service;


namespace RickAndMorty.Net.Test;

    public class ServiceTests
    {

    private IRickAndMortyService RickAndMortyService { get; }
    private IMemoryCache memoryCache { get; }

    public ServiceTests()
        {
        memoryCache = new MemoryCache(new MemoryCacheOptions());
        RickAndMortyService = RickAndMortyFactory.Create(memoryCache);
        }


        [Theory]
        [InlineData(12)]
        public async void GetCharacter(int value)
        {
            var result = await RickAndMortyService.GetCharacter(value);

            Assert.NotNull(result);
            Assert.True(result.Id == value);
            Assert.True(!String.IsNullOrWhiteSpace(result.Name));
            Assert.True(!String.IsNullOrWhiteSpace(result.Status));
            Assert.NotNull(result.Location);
        }

    [Fact]
    public async void GetAllCharacters()
    {
        var result = await RickAndMortyService.GetAllCharacters();

        Assert.NotNull(result);

    }


    [Fact]
    public async void GetAllCharactersCache()
    {
        var result = await RickAndMortyService.GetAllCharacters();
        var resultCached = RickAndMortyService.GetAllCharactersCached();

        Assert.NotNull(result);
        Assert.NotNull(resultCached);
    }


    [Theory]
        [InlineData("rick")]
        public async void FilterCharactersbyName(string value)
        {
            var result = await RickAndMortyService.FilterCharacters(name: value);

            Assert.NotNull(result);
            Assert.True(result.Info.Count != 0);
            Assert.True(result.Results.Any());
            Assert.True(!String.IsNullOrEmpty(result.Results.First().Name));
        }
    }

