using System;

namespace BusinessTier.Models
{
    public class FilterREST
    {
        public string Search { get; set; }
        public bool ByDate { get; set; }
        public bool ByAvailability { get; set; }
        public int CurrentPage { get; set; }
        public int CategoryId { get; set; }
        public int ResultsPerPage { get; set; }
    }
}