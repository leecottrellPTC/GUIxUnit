using System;
using System.Collections.Generic;

namespace HenryTest.Models
{
    public partial class Bookandcost
    {
        public string Bookcode { get; set; } = null!;
        public string? Title { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
    }
}
