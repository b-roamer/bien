using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Qualifying
    {
        public int QualifyId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int? Number { get; set; }
        public int? Position { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }

        public virtual Constructor Constructor { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
    }
}
