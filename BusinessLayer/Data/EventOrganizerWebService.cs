using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class EventOrganizerWebService : IEventOrganizerWebService
    {
        private BookAndPlayPort Port;
        private SOAPEventOrganizerResponse1 Response;

        public EventOrganizerWebService()
        {
            Port = new BookAndPlayPortClient();
        }
        
        private async Task<SOAPEventOrganizerResponse1> GetEventOrganizerResponse(Operation name, String username)
        {
            SOAPEventOrganizerRequest soapEventOrganizerRequest = new SOAPEventOrganizerRequest();
            soapEventOrganizerRequest.Operation = name;
            soapEventOrganizerRequest.username = username;
            SOAPEventOrganizerRequest1 soapEventOrganizerRequest1 = new SOAPEventOrganizerRequest1(soapEventOrganizerRequest);
            SOAPEventOrganizerResponse1 soapEventOrganizerResponse1 = Port.SOAPEventOrganizerAsync(soapEventOrganizerRequest1).Result;
            return soapEventOrganizerResponse1;
        }
        
        public async Task<EventList> GetOrganizerEventsAsync(string username)
        {
            Response = await GetEventOrganizerResponse(Operation.GETALL, username);
            return Response.SOAPEventOrganizerResponse.eventList;
        }
    }
}