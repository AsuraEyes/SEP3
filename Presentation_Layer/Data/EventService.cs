using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<EventList> GetFilteredEventsAsync(FilterREST filterRest)
        {
            var filters =
                $"?byDate={filterRest.byDate}&byAvailability={filterRest.byAvailability}&currentPage={filterRest.currentPage}&categoryId={filterRest.categoryId}&resultsPerPage={filterRest.resultsPerPage}";
            var stringAsync = Client.GetStringAsync(uri + $"/FilteredEvents"+filters);
            var EventList = await stringAsync;
            EventList Events = JsonSerializer.Deserialize<EventList>(EventList, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Events;
        }
        
        public async Task<Event> GetEventAsync(int id)
        {
            var stringAsync = Client.GetStringAsync(uri + $"/Event/{id}");
            var eventString = await stringAsync;
            var Event = JsonSerializer.Deserialize<Event>(eventString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return Event;
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
            var EventAsJson = JsonSerializer.Serialize(Event);
            HttpContent content = new StringContent(EventAsJson, Encoding.UTF8, "application/json");
            await Client.PostAsync($"{uri}/Event", content);
        }
        
        public async Task CancelEvent(Event Event)
        {
            await Client.DeleteAsync($"{uri}/Events/{Event.Id}");
        }

        public async Task EditEvent(Event Event)
        {
            var EventAsJson = JsonSerializer.Serialize(Event);
            HttpContent content = new StringContent(EventAsJson, Encoding.UTF8, "application/json");
            await Client.PatchAsync($"{uri}/Event", content);
        }
    }
}