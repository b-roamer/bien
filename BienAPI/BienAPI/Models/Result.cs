using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int? Number { get; set; }
        public int? Grid { get; set; }
        public int? Position { get; set; }
        public string PositionText { get; set; }
        public int? PositionOrder { get; set; }
        public decimal? Points { get; set; }
        public int? Laps { get; set; }
        public string Time { get; set; }
        public int? Milliseconds { get; set; }
        public int? FastestLap { get; set; }
        public int? Ranks { get; set; }
        public string FastestLapTime { get; set; }
        public decimal? FastestLapSpeed { get; set; }
        public int StatusId { get; set; }

        public virtual Constructor Constructor { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
        public virtual Status Status { get; set; }
    }
}
