using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class ParticipantWebService: IParticipantWebService
    {
        private BookAndPlayPort port;
        private SOAPParticipantResponse1 response;

        public ParticipantWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPParticipantResponse1> GetParticipantResponse(Operation name, int eventId, string username)
        {
            SOAPParticipantRequest soapParticipantRequest = new SOAPParticipantRequest();
            soapParticipantRequest.Operation = name;
            soapParticipantRequest.username = username;
            soapParticipantRequest.eventId = eventId;
            SOAPParticipantRequest1 soapRequest1 = new SOAPParticipantRequest1(soapParticipantRequest);
            SOAPParticipantResponse1 soapResponse1 = new SOAPParticipantResponse1();
            soapResponse1 = port.SOAPParticipantAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<string>> GetParticipantsAsync(int eventId)
        {
            response = await GetParticipantResponse(Operation.GETALL, eventId, "");
            return response.SOAPParticipantResponse.participantList;
        }
        
        public async Task JoinEventAsync(int id, string username)
        {
            response = await GetParticipantResponse(Operation.POST, id, username);
        }
        
        public async Task WithdrawEventAsync(int id, string username)
        {
            response = await GetParticipantResponse(Operation.PATCH, id, username);
        }
    }
}