using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class DriverStanding
    {
        public int DriverStandingsId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public decimal Points { get; set; }
        public int Position { get; set; }
        public int PositionText { get; set; }
        public int Wins { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
    }
}
