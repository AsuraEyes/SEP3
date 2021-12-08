using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.EventGameLists
{
    public class EventGameListWebService : IEventGameListWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventGameListResponse1 response;

        public EventGameListWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventGameListResponse1> GetEventGameListResponseAsync(int eventId, Operation name, String username, int gameId)
        {
            SOAPEventGameListRequest soapEventGameListRequest = new SOAPEventGameListRequest
            {
                eventId = eventId,
                Operation = name,
                username = username,
                gameId = gameId
            };
            SOAPEventGameListRequest1 soapRequest1 = new SOAPEventGameListRequest1(soapEventGameListRequest);
            SOAPEventGameListResponse1 soapResponse1 = new SOAPEventGameListResponse1();
            soapResponse1 = await port.SOAPEventGameListAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task<IList<Game>> GetAllEventGameListAsync(int eventId)
        {
            response = await GetEventGameListResponseAsync(eventId, Operation.GETALL, "", 0);
            return response.SOAPEventGameListResponse.gameList;
        }
        
        public async Task AddGameToEventGameListAsync(string username, int gameId, int eventId)
        {
            await GetEventGameListResponseAsync(eventId, Operation.CREATE, username, gameId);
        }
        
        public async Task RemoveGameFromEventGameListAsync(string username, int gameId, int eventId)
        {
            await GetEventGameListResponseAsync(eventId, Operation.REMOVE, username, gameId);
        }
    }
}