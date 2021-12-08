using System;
using System.Threading.Tasks;
using BusinessTier.Data;
using BusinessTier.Models;

namespace BusinessTier.Middlepoint
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