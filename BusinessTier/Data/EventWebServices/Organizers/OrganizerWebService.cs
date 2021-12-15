using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Organizers
{
    public class OrganizerWebService : IOrganizerWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPOrganizerResponse1 response;

        public OrganizerWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPOrganizerResponse1> GetOrganizerResponse(Operation name, int eventId, string organizerName)
        {
            var soapOrganizerRequest = new SOAPOrganizerRequest
            {
                Operation = name,
                username = organizerName,
                eventId = eventId
            };
            var soapRequest1 = new SOAPOrganizerRequest1(soapOrganizerRequest);
            var soapResponse1 = await port.SOAPOrganizerAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task<IList<string>> GetOrganizersAsync(int eventId)
        {
            response = await GetOrganizerResponse(Operation.GETALL, eventId, "");
            return response.SOAPOrganizerResponse.organizerList;
        }
        
        public async Task CoOrganizeEventAsync(int id, string username)
        {
            response = await GetOrganizerResponse(Operation.CREATE, id, username);
        }
        
        public async Task WithdrawEventAsync(int id, string username)
        {
            response = await GetOrganizerResponse(Operation.UPDATE, id, username);
        }
        
        public async Task<EventList> GetCoOrganizerEventsAsync(string username)
        {
            response = await GetOrganizerResponse(Operation.GET, 0, username);
            return response.SOAPOrganizerResponse.eventList;
        } 
    }
}