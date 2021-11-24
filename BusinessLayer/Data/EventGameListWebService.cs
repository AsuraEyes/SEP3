using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class EventGameListWebService : IEventGameListWebService
    {
        private BookAndPlayPort port;
        private SOAPEventGameListResponse1 response;

        public EventGameListWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPEventGameListResponse1> GetEventGameListResponse(int eventId, Operation name, String username)
        {
            SOAPEventGameListRequest soapEventGameListRequest = new SOAPEventGameListRequest();
            soapEventGameListRequest.eventId = eventId;
            soapEventGameListRequest.Operation = name;
            soapEventGameListRequest.username = username;
            SOAPEventGameListRequest1 soapRequest1 = new SOAPEventGameListRequest1(soapEventGameListRequest);
            SOAPEventGameListResponse1 soapResponse1 = new SOAPEventGameListResponse1();
            soapResponse1 = port.SOAPEventGameListAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<Game>> GetAllEventGameListAsync(int eventId)
        {
            response = await GetEventGameListResponse(eventId, Operation.GETALL, "");
            return response.SOAPEventGameListResponse.gameList;
        }
    }
}