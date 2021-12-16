using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Data.EventWebServices.Events;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.EventMiddlePoints.Events
{
    public class EventMiddlePoint : IEventMiddlePoint
    {
        private readonly IEventWebService eventWebService;
        private EventList filteredEvents;
        
        public EventMiddlePoint(IEventWebService eventWebService)
        {
            this.eventWebService = eventWebService;
            filteredEvents = new EventList();
        }
        public async Task<EventList> EventFilterAsync(FilterRest filterRest)
        {
            var filter = "all";
            var filterObject = new Filter();
            
            try
            {
                if (filterRest.ByDate)
                    filter += "byDate";
                
                if (filterRest.ByAvailability)
                    filter += "byAvailability";

                if (filterRest.CategoryId != 0)
                    filter += "byCategory";

                filterObject.filter = filter;
                filterObject.limit = filterRest.ResultsPerPage;
                filterObject.offset = (filterRest.CurrentPage - 1) * filterRest.ResultsPerPage;
                filterObject.categoryId = filterRest.CategoryId;
                
                filteredEvents = await eventWebService.GetFilteredEventsAsync(filterObject);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return filteredEvents;
        }
    }
}