using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class EventOrganizerWebService : IEventOrganizerWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventOrganizerResponse1 response;

        public EventOrganizerWebService()
        {
            port = new BookAndPlayPortClient();
        }
        
        private async Task<SOAPEventOrganizerResponse1> getEventOrganizerResponseAsync(Operation name, String username)
        {
            SOAPEventOrganizerRequest soapEventOrganizerRequest = new SOAPEventOrganizerRequest();
            soapEventOrganizerRequest.Operation = name;
            soapEventOrganizerRequest.username = username;
            SOAPEventOrganizerRequest1 soapEventOrganizerRequest1 = new SOAPEventOrganizerRequest1(soapEventOrganizerRequest);
            SOAPEventOrganizerResponse1 soapEventOrganizerResponse1 = port.SOAPEventOrganizerAsync(soapEventOrganizerRequest1).Result;
            return soapEventOrganizerResponse1;
        }
        
        public async Task<EventList> GetOrganizerEventsAsync(string username)
        {
            response = await getEventOrganizerResponseAsync(Operation.GETALL, username);
            return response.SOAPEventOrganizerResponse.eventList;
        }
    }
}