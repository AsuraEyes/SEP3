using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class OrganizerWebService : IOrganizerWebService
    {
        private BookAndPlayPort port;
        private SOAPOrganizerResponse1 response;

        public OrganizerWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPOrganizerResponse1> GetOrganizerResponse(Operation name, int eventId, string organizerName)
        {
            SOAPOrganizerRequest soapOrganizerRequest = new SOAPOrganizerRequest();
            soapOrganizerRequest.Operation = name;
            soapOrganizerRequest.username = organizerName;
            soapOrganizerRequest.eventId = eventId;
            SOAPOrganizerRequest1 soapRequest1 = new SOAPOrganizerRequest1(soapOrganizerRequest);
            SOAPOrganizerResponse1 soapResponse1 = new SOAPOrganizerResponse1();
            soapResponse1 = port.SOAPOrganizerAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<string>> GetOrganizersAsync(int eventId)
        {
            response = await GetOrganizerResponse(Operation.GETALL, eventId, "");
            return response.SOAPOrganizerResponse.organizerList;
        }
        
        public async Task CoOrganizeEvent(int id, string username)
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