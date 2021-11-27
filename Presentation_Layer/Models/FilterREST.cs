namespace Presentation_Layer.Models
{
    public class FilterREST
    {
        public bool byDate { get; set; }
        public bool byAvailability { get; set; }
        public int currentPage { get; set; }
        public int categoryId { get; set; }
        public int resultsPerPage { get; set; }
    }
}