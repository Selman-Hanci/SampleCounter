using System;
using System.Xml.Linq;

namespace SampleDomain.Models
{
    //[BindProperties]
    public class Client
    {
        public int Counter { get; set; }
        public double Weight { get; set; }
        public decimal Height { get; set; }
        public string? Description { get; set; }

    }
}

