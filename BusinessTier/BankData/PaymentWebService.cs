using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Presentation_Layer.Models;

namespace BusinessTier.BankData
{
    public class PaymentWebService : IPaymentWebService
    {
        private string uri = "https://localhost:5005";
        private readonly HttpClient client;

        public PaymentWebService()
        {
            client = new HttpClient();
        }

        public async Task<string> ValidatePaymentAsync(UserCardInfo userCard)
        {
            var userCardJson = JsonSerializer.Serialize(userCard);
            HttpContent content = new StringContent(userCardJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PostAsync(uri+"/PaymentValidation", content);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }
    }
}