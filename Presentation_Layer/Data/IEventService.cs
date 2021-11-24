using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IEventService
    {
        Task<IList<Event>> GetEventsAsync();

        Task<EventList> GetFilteredEventsAsync(Boolean byDate, Boolean byAvailability, int currentPage,
            int categoryId);
        // int GetNumberOfPages(IList<Event> allEvents);
        //
        // IList<Event> GetEventsPagination(IList<Event> allEvents, int currentPage);
        
        Task CreateEvent(Event Event);
        Task<Event> GetEventAsync(int id);
    }
}