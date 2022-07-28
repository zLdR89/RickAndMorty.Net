using System;

namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    public class CharacterLocation
    {

        public CharacterLocation(string name = "", string url = "")
        {
            Name = name;
            Url = url;
        }

        public string Name { get; }

        public string Url { get; }
    }
}
