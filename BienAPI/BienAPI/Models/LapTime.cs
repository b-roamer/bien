using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class LapTime
    {
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int Lap { get; set; }
        public int? Position { get; set; }
        public string Time { get; set; }
        public int? Milliseconds { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
    }
}
