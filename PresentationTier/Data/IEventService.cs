using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IEventService
    {
        Task<IList<Event>> GetEventsAsync();

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