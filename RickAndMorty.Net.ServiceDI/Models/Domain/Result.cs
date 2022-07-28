using System;
namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    public class Result<T>
    {
        public Result(Info info, IEnumerable<T> results)
        {
            Info = info;
            Results = results;
        }
        public Info Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}

