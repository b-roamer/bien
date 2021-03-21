using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Driver
    {
        public Driver()
        {
            DriverStandings = new HashSet<DriverStanding>();
            Qualifyings = new HashSet<Qualifying>();
            Results = new HashSet<Result>();
        }

        public int DriverId { get; set; }
        public string DriverRef { get; set; }
        public int? Number { get; set; }
        public string Code { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }

        public virtual ICollection<DriverStanding> DriverStandings { get; set; }
        public virtual ICollection<Qualifying> Qualifyings { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
