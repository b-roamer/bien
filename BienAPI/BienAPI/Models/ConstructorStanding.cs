using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class ConstructorStanding
    {
        public int ConstructorStandingsId { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public decimal Points { get; set; }
        public int Position { get; set; }
        public int PositionText { get; set; }
        public int Wins { get; set; }

        public virtual Constructor Constructor { get; set; }
        public virtual Race Race { get; set; }
    }
}
