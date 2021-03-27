using System;
namespace BienAPI.Models
{
    public class Pagination
    {
        const int MaxPageSize = 50;
        public int Page { get; set; } = 1;
        public string Search { get; set; } = "";
        public string Country { get; set; } = "";
        public string Circuit { get; set; } = "";
        public string Nationality { get; set; } = "";
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public string Year { get; set; }
        public Pagination()
        {
        }
    }
}
