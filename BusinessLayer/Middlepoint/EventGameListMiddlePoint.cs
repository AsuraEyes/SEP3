using System;
using System.Threading.Tasks;
using BusinessLayer.Data;
using BusinessLayer.Models;

namespace BusinessLayer.Middlepoint
{
    public class EventGameListMiddlePoint : IEventGameListMiddlePoint
    {
        private IEventGameListWebService eventGameListWebService;
        
        public EventGameListMiddlePoint(IEventGameListWebService eventGameListWebService)
        {
            this.eventGameListWebService = eventGameListWebService;
        }
        
        
        public async Task EventGameListUpdate(EventGameListUpdate eventGameListUpdate)
        {
            if (eventGameListUpdate.inList)
            {
                //add to list
                try
                {
                    await eventGameListWebService.AddGameToEventGameListAsync(eventGameListUpdate.username, eventGameListUpdate.gameId, eventGameListUpdate.eventId);
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
                    await eventGameListWebService.RemoveGameFromEventGameListAsync(eventGameListUpdate.username, eventGameListUpdate.gameId, eventGameListUpdate.eventId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}