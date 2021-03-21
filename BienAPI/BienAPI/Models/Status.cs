using System;
using System.Collections.Generic;

#nullable disable

namespace BienAPI.Models
{
    public partial class Status
    {
        public Status()
        {
            Results = new HashSet<Result>();
        }

        public int StatusId { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
