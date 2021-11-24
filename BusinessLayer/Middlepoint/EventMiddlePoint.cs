using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Data;
using Microsoft.AspNetCore.Components;

namespace BusinessLayer.Middlepoint
{
    public class EventMiddlePoint : IEventMiddlePoint
    {
        //private IList<Category> categories;
        private ICategoryWebService categoryWebService;
        private IEventWebService eventWebService;
        private EventList filteredEvents;
        private int resultsPerPage = 3;
       // public int numberOfPages { get; set; }

        public EventMiddlePoint(IEventWebService eventWebService)
        {
            this.eventWebService = eventWebService;
            filteredEvents = new EventList();
            //categories = categoryWebService.getCategoriesAsync().Result;
        }
        public async Task<EventList> eventFilter(bool byDate, bool byAvailability, int currentPage, int categoryId)
        {
            string filter = "all";
            int category = 0;
            
            try
            {
                if (byDate == true)
                    filter += "byDate";
                else 
                    filter = filter.Replace("byDate", "");
                
                if (byAvailability  == true)
                    filter += "byAvailability";
                else 
                    filter = filter.Replace("byAvailability", "");

                if (categoryId != 0)
                {
                    filter += "byCategory";
                    category = categoryId;
                }
     
                else
                    filter = filter.Replace("byCategory", "");
                
                Console.WriteLine(filter);
                filteredEvents = await eventWebService.GetFilteredEventsAsync(filter, category, currentPage, resultsPerPage);
            }
            // {
            //     for (int i = 0; i < filteringOptions.Count; i++)
            //     {
            //         if (args.Value.ToString().Equals(filteringOptions[i]) && i%2 == 0)
            //         {
            //             filter += filteringOptions[i];
            //         }
            //         else if (args.Value.ToString().Equals(filteringOptions[i]) && i%2 ==1)
            //         {
            //             filter = filter.Replace(filteringOptions[i-1], "");
            //         }
            //     }
            //     if (int.Parse(args.Value.ToString()) != 0)
            //     {
            //         filter += filteringOptions[4];
            //         categoryId = int.Parse(args.Value.ToString());
            //     }
            //     else filter = filter.Replace(filteringOptions[4], string.Empty);
            // }
            catch (Exception)
            {
            }
            return filteredEvents;
        }
        
        // public int GetNumberOfPages(IList<Event> allEvents)
        // {
        //     return (int) Math.Ceiling(allEvents.Count / 9.00);
        // }

        // public IList<Event> GetEventsPagination(IList<Event> allEvents, int currentPage)
        // {
        //     //current page starts at 1
        //     IList<Event> pagedList = new List<Event>();
        //     for (int i = 0 + (currentPage - 1) * 9; i < currentPage * 9; i++)
        //     {
        //         if (i < allEvents.Count)
        //         {
        //             pagedList.Add(allEvents[i]);
        //         }
        //     }
        //
        //     return pagedList;
        // }
        
        
    }
}