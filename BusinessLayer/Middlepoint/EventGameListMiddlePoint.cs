using System;
using System.Threading.Tasks;
using BusinessLayer.Data;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public class EventGameListMiddlePoint : IEventGameListMiddlePoint
    {
        private readonly IEventGameListWebService eventGameListWebService;
        
        public EventGameListMiddlePoint(IEventGameListWebService eventGameListWebService)
        {
            this.eventGameListWebService = eventGameListWebService;
        }
        
        
        public async Task EventGameListUpdateAsync(EventGameListUpdate eventGameListUpdate)
        {
            if (eventGameListUpdate.InList)
            {
                //add to list
                try
                {
                    await eventGameListWebService.AddGameToEventGameListAsync(eventGameListUpdate.Username, eventGameListUpdate.GameId, eventGameListUpdate.EventId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                //remove from list
                try
                {
                    await eventGameListWebService.RemoveGameFromEventGameListAsync(eventGameListUpdate.Username, eventGameListUpdate.GameId, eventGameListUpdate.EventId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}