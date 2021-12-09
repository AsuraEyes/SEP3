using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.Events
{
    public interface IEventService
    {
        Task<EventList> GetFilteredEventsAsync(FilterREST filterRest);
        // int GetNumberOfPages(IList<Event> allEvents);
        //
        // IList<Event> GetEventsPagination(IList<Event> allEvents, int currentPage);
        
        Task CreateEventAsync(Event newEvent);
        Task<Event> GetEventAsync(int id);
        Task CancelEventAsync(Event eventToBeCancelled);
        Task EditEventAsync(Event eventToBeEdited);
    }
}