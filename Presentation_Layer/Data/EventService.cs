using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;
using Presentation_Layer.Pages;

namespace Presentation_Layer.Data
{
    public class EventService : IEventService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient Client;

        public EventService()
        {
            Client = new HttpClient();
        }

        public async Task<IList<Event>> GetEventsAsync()
        {
            var stringAsync = Client.GetStringAsync(uri + "/Events");
            var Event = await stringAsync;
            var Events = JsonSerializer.Deserialize<List<Event>>(Event, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Events;
        }

        public async Task<EventList> GetFilteredEventsAsync(Boolean byDate, Boolean byAvailability, int currentPage, int categoryId)
        {
            var stringAsync = Client.GetStringAsync(uri + $"/FilteredEvents/{byDate}/{byAvailability}/{currentPage}/{categoryId}");
            var EventList = await stringAsync;
            EventList Events = JsonSerializer.Deserialize<EventList>(EventList, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Events;
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

        public async Task CreateEvent(Event Event)
        {
            var diff = Event.EndTime.Subtract(Event.StartTime).TotalMinutes;
            if (diff < 0)
            {
                Event.EndTime = Event.StartTime;
            }
            string EventAsJson = JsonSerializer.Serialize(Event);
            HttpContent content = new StringContent(EventAsJson, Encoding.UTF8, "application/json");
            await Client.PostAsync(uri+"/Event", content);
        }
        
    }
}