using System;

namespace BienAPI.Controllers
{
    public class FormattedRace
    {
        public int RaceId { get; set; }
        public string Circuit { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}