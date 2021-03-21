using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Race
    {
        public Race()
        {
            ConstructorResults = new HashSet<ConstructorResult>();
            ConstructorStandings = new HashSet<ConstructorStanding>();
            DriverStandings = new HashSet<DriverStanding>();
            Qualifyings = new HashSet<Qualifying>();
            Results = new HashSet<Result>();
        }

        public int RaceId { get; set; }
        public int Year { get; set; }
        public int Round { get; set; }
        public int CircuitId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Url { get; set; }

        public virtual Circuit Circuit { get; set; }
        public virtual ICollection<ConstructorResult> ConstructorResults { get; set; }
        public virtual ICollection<ConstructorStanding> ConstructorStandings { get; set; }
        public virtual ICollection<DriverStanding> DriverStandings { get; set; }
        public virtual ICollection<Qualifying> Qualifyings { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
