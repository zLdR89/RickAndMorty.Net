using System;
namespace RickAndMorty.Net.ServiceDI.Models.Domain
{
    public class Info
    {
        public Info(int count = 0, int pages = 0, string next = "", string prev = "")
        {
            Count = count;
            Pages = pages;
            Next = next;
            Prev = prev;
        }
        public int Count { get; }
        public int Pages { get;  }
        public string Next { get; }
        public string Prev { get; }
    }
}

