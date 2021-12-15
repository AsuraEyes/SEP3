using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.EventOrganizers
{
    public class EventOrganizerWebService : IEventOrganizerWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPEventOrganizerResponse1 response;

        public EventOrganizerWebService()
        {
            port = new BookAndPlayPortClient();
        }
        
        private async Task<SOAPEventOrganizerResponse1> GetEventOrganizerResponseAsync(Operation name, String username)
        {
            var soapEventOrganizerRequest = new SOAPEventOrganizerRequest
            {
                Operation = name,
                username = username
            };
            var soapEventOrganizerRequest1 = new SOAPEventOrganizerRequest1(soapEventOrganizerRequest);
            var soapEventOrganizerResponse1 = await port.SOAPEventOrganizerAsync(soapEventOrganizerRequest1);
            return soapEventOrganizerResponse1;
        }
        
        public async Task<EventList> GetOrganizerEventsAsync(string username)
        {
            response = await GetEventOrganizerResponseAsync(Operation.GETALL, username);
            return response.SOAPEventOrganizerResponse.eventList;
        }
    }
}