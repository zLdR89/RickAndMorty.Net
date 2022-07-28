using System;
using System.Collections.Generic;

namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    public class Character
    {

        public Character(int id = 0, string name = "", string status = "",
            string species = "", string type = "", string gender = "",
            CharacterLocation location = null, CharacterOrigin origin = null, string image = "",
            IEnumerable<string> episode = null, string url = "", DateTime? created = null)
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Location = location;
            Origin = origin;
            Image = image;
            Episode = episode;
            Url = url;
            Created = created;
        }

        public int Id { get; }

        public string Name { get; }

        public string Status { get; }

        public string Species { get; }

        public string Type { get; }

        public string Gender { get; }

        public CharacterLocation Location { get; }

        public CharacterOrigin Origin { get; }

        public string Image { get; }

        public IEnumerable<string> Episode { get; }

        public string Url { get; }

        public DateTime? Created { get; }
    }
}
