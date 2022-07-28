using System;

namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    public class CharacterOrigin
    {

        public CharacterOrigin(string name = "", string url = "")
        {
            Name = name;
            Url = url;
        }

        public string Name { get; }

        public string Url { get; }
    }
}
