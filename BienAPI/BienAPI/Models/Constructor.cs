using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Constructor
    {
        public Constructor()
        {
            ConstructorResults = new HashSet<ConstructorResult>();
            ConstructorStandings = new HashSet<ConstructorStanding>();
            Qualifyings = new HashSet<Qualifying>();
            Results = new HashSet<Result>();
        }

        public int ConstructorId { get; set; }
        public string ConstructorRef { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }

        public virtual ICollection<ConstructorResult> ConstructorResults { get; set; }
        public virtual ICollection<ConstructorStanding> ConstructorStandings { get; set; }
        public virtual ICollection<Qualifying> Qualifyings { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
