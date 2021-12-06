using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Components;

namespace BusinessLayer.Middlepoint
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
        public async Task<EventList> EventFilterAsync(FilterREST filterRest)
        {
            var filter = "all";
            var filterObject = new Filter();
            
            try
            {
                if (filterRest.ByDate)
                    filter += "byDate";
                else 
                    filter = filter.Replace("byDate", "");
                
                if (filterRest.ByAvailability)
                    filter += "byAvailability";
                else 
                    filter = filter.Replace("byAvailability", "");

                if (filterRest.CategoryId != 0)
                {
                    filter += "byCategory";
                }
     
                else
                    filter = filter.Replace("byCategory", "");

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