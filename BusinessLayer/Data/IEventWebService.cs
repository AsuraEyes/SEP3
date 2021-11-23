using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IEventWebService
    {
        Task CreateEventAsync(Event Event);
        Task<IList<Event>> GetEventsAsync();
        Task<EventList> GetFilteredEventsAsync(string filter, int category, int currentPage, int resultsPerPage);
        //Task<int> GetNumberOfPages(string filter, int category, int currentPage, int resultsPerPage);
    }
}