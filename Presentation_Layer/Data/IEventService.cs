using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IEventService
    {
        Task<IList<Event>> GetEventsAsync();
        Task<IList<Event>> GetFilteredEventsAsync(string filter, int category);
        int GetNumberOfPages(IList<Event> allEvents);

        IList<Event> GetEventsPagination(IList<Event> allEvents, int currentPage);


        
        
        
        IList<Event> GetEvents();
        void CreateEvent(Event event);
    }
}