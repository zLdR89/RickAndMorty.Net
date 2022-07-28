using System;
namespace RickAndMorty.Net.ServiceDI.Models.Dto
{
    internal class ResultDto<T>
    {
        public InfoDto Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}

