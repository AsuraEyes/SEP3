using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Participants
{
    public class ParticipantWebService: IParticipantWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPParticipantResponse1 response;

        public ParticipantWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPParticipantResponse1> GetParticipantResponse(Operation name, int eventId, string username)
        {
            SOAPParticipantRequest soapParticipantRequest = new SOAPParticipantRequest
            {
                Operation = name,
                username = username,
                eventId = eventId
            };
            SOAPParticipantRequest1 soapRequest1 = new SOAPParticipantRequest1(soapParticipantRequest);
            SOAPParticipantResponse1 soapResponse1 = new SOAPParticipantResponse1();
            soapResponse1 = await port.SOAPParticipantAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task<IList<string>> GetParticipantsAsync(int eventId)
        {
            response = await GetParticipantResponse(Operation.GETALL, eventId, "");
            return response.SOAPParticipantResponse.participantList;
        }
        
        public async Task JoinEventAsync(int id, string username)
        {
            response = await GetParticipantResponse(Operation.CREATE, id, username);
        }
        
        public async Task WithdrawEventAsync(int id, string username)
        {
            response = await GetParticipantResponse(Operation.UPDATE, id, username);
        }

        public async Task<EventList> GetParticipantEventsAsync(string username)
        {
            response = await GetParticipantResponse(Operation.GET, 0, username);
            return response.SOAPParticipantResponse.eventList;
        } 
    }
}