using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Circuit
    {
        public Circuit()
        {
            Races = new HashSet<Race>();
        }

        public int CircuitId { get; set; }
        public string CircuitRef { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
