using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class MonthlyFeeWebService: IMonthlyFeeWebService
    {
        private BookAndPlayPort port;
        private SOAPMonthlyFeeResponse1 response;

        public MonthlyFeeWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPMonthlyFeeResponse1> getMonthlyFeeResponse(Operation name, string username, MonthlyFee monthlyFee )
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

        public async Task CreateMonthlyFee(MonthlyFee monthlyFee)
        {
            response = await getMonthlyFeeResponse(Operation.CREATE, "", monthlyFee);
        }

        public async Task<MonthlyFee> GetMonthlyFee(string username)
        {
            response = await getMonthlyFeeResponse(Operation.GET, username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFee;
        }

        public async Task UpdateMonthlyFee(MonthlyFee monthlyFee)
        {
            response = await getMonthlyFeeResponse(Operation.UPDATE, "", null);
        }
        
        public async Task<IList<MonthlyFee>> GetMonthlyFeeList(string username)
        {
            response = await getMonthlyFeeResponse(Operation.GETALL,username, null);
            return response.SOAPMonthlyFeeResponse.MonthlyFeeList;
        }
    }
}