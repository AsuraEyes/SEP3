using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public class MonthlyFeeWebService: IMonthlyFeeWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPMonthlyFeeResponse1 response;

        public MonthlyFeeWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPMonthlyFeeResponse1> getMonthlyFeeResponseAsync(Operation name, string username, MonthlyFee monthlyFee )
        {
            SOAPMonthlyFeeRequest soapMonthlyFeeRequest = new SOAPMonthlyFeeRequest();
            soapMonthlyFeeRequest.Operation = name;
            soapMonthlyFeeRequest.username = username;
            soapMonthlyFeeRequest.MonthlyFee = monthlyFee;
            SOAPMonthlyFeeRequest1 soapRequest1 = new SOAPMonthlyFeeRequest1(soapMonthlyFeeRequest);
            SOAPMonthlyFeeResponse1 soapResponse1 = new SOAPMonthlyFeeResponse1();
            soapResponse1 = port.SOAPMonthlyFeeAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task CreateMonthlyFeeAsync(MonthlyFee monthlyFee)
        {
            response = await getMonthlyFeeResponseAsync(Operation.CREATE, "", monthlyFee);
        }

        public async Task<MonthlyFee> GetMonthlyFeeAsync(string username)
        {
            response = await getMonthlyFeeResponseAsync(Operation.GET, username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFee;
        }

        public async Task UpdateMonthlyFeeAsync(MonthlyFee monthlyFee)
        {
            response = await getMonthlyFeeResponseAsync(Operation.UPDATE, "", monthlyFee);
        }
        
        public async Task<IList<MonthlyFee>> GetMonthlyFeeListAsync(string username)
        {
            response = await getMonthlyFeeResponseAsync(Operation.GETALL,username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFeeList;
        }
    }
}