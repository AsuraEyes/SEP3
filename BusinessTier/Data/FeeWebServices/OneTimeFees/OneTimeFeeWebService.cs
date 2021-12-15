using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.FeeWebServices.OneTimeFees
{
    public class OneTimeFeeWebService : IOneTimeFeeWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPOneTimeFeeResponse1 response;

        public OneTimeFeeWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPOneTimeFeeResponse1> getOneTimeFeeResponseAsync(Operation name, int eventId,string username, OneTimeFee oneTimeFee )
        {
            var soapOneTimeFeeRequest = new SOAPOneTimeFeeRequest
            {
                Operation = name,
                username = username,
                OneTimeFee = oneTimeFee,
                eventId = eventId
            };
            var soapRequest1 = new SOAPOneTimeFeeRequest1(soapOneTimeFeeRequest);
            var soapResponse1 = await port.SOAPOneTimeFeeAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task CreateOneTimeFeeAsync(OneTimeFee oneTimeFee)
        {
            response = await getOneTimeFeeResponseAsync(Operation.CREATE,0, "", oneTimeFee);
        }

        public async Task<OneTimeFee> GetOneTimeFeeAsync(string username, int eventId)
        {
            response = await getOneTimeFeeResponseAsync(Operation.GET, eventId,username, null);
            return response.SOAPOneTimeFeeResponse.OneTimeFee;
        }

        public async Task<IList<OneTimeFee>> GetOneTimeFeeListAsync(string username)
        {
            response = await getOneTimeFeeResponseAsync(Operation.GETALL, 0,username, null);
            return response.SOAPOneTimeFeeResponse.OneTimeFeeList;
        }
    }
}