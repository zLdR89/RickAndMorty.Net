﻿using System;
namespace RickAndMorty.Net.ServiceDI.Models.Dto
{
    internal class InfoDto
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}

