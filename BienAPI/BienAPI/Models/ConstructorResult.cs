using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class ConstructorResult
    {
        public int ConstructorResultsId { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public decimal Points { get; set; }
        public string Status { get; set; }

        public virtual Constructor Constructor { get; set; }
        public virtual Race Race { get; set; }
    }
}
