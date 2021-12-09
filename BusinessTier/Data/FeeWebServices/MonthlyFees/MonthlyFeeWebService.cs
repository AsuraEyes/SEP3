using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.FeeWebServices.MonthlyFees
{
    public class MonthlyFeeWebService: IMonthlyFeeWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPMonthlyFeeResponse1 response;

        public MonthlyFeeWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPMonthlyFeeResponse1> GetMonthlyFeeResponseAsync(Operation name, string username, MonthlyFee monthlyFee )
        {
            SOAPMonthlyFeeRequest soapMonthlyFeeRequest = new SOAPMonthlyFeeRequest
            {
                Operation = name,
                username = username,
                MonthlyFee = monthlyFee
            };
            SOAPMonthlyFeeRequest1 soapRequest1 = new SOAPMonthlyFeeRequest1(soapMonthlyFeeRequest);
            SOAPMonthlyFeeResponse1 soapResponse1 = new SOAPMonthlyFeeResponse1();
            soapResponse1 = await port.SOAPMonthlyFeeAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task CreateMonthlyFeeAsync(MonthlyFee monthlyFee)
        {
            response = await GetMonthlyFeeResponseAsync(Operation.CREATE, "", monthlyFee);
        }

        public async Task<MonthlyFee> GetMonthlyFeeAsync(string username)
        {
            response = await GetMonthlyFeeResponseAsync(Operation.GET, username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFee;
        }

        public async Task UpdateMonthlyFeeAsync(MonthlyFee monthlyFee)
        {
            response = await GetMonthlyFeeResponseAsync(Operation.UPDATE, "", monthlyFee);
        }
        
        public async Task<IList<MonthlyFee>> GetMonthlyFeeListAsync(string username)
        {
            response = await GetMonthlyFeeResponseAsync(Operation.GETALL,username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFeeList;
        }
    }
}