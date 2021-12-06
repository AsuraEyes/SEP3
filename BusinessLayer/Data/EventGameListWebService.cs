using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class EventGameListWebService : IEventGameListWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventGameListResponse1 response;

        public EventGameListWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventGameListResponse1> getEventGameListResponseAsync(int eventId, Operation name, String username, int gameId)
        {
            SOAPEventGameListRequest soapEventGameListRequest = new SOAPEventGameListRequest();
            soapEventGameListRequest.eventId = eventId;
            soapEventGameListRequest.Operation = name;
            soapEventGameListRequest.username = username;
            soapEventGameListRequest.gameId = gameId;
            SOAPEventGameListRequest1 soapRequest1 = new SOAPEventGameListRequest1(soapEventGameListRequest);
            SOAPEventGameListResponse1 soapResponse1 = new SOAPEventGameListResponse1();
            soapResponse1 = port.SOAPEventGameListAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<Game>> GetAllEventGameListAsync(int eventId)
        {
            response = await getEventGameListResponseAsync(eventId, Operation.GETALL, "", 0);
            return response.SOAPEventGameListResponse.gameList;
        }
        
        public async Task AddGameToEventGameListAsync(string username, int gameId, int eventId)
        {
            await getEventGameListResponseAsync(eventId, Operation.CREATE, username, gameId);
        }
        
        public async Task RemoveGameFromEventGameListAsync(string username, int gameId, int eventId)
        {
            await getEventGameListResponseAsync(eventId, Operation.REMOVE, username, gameId);
        }
    }
}