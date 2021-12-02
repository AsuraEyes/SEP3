using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class PaymentService: IPaymentService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public PaymentService()
        {
            client = new HttpClient();
        }
        
        public async Task<string> OneTimePaymentAsync(UserCardInfo userCard)
        {
            var userCardJson = JsonSerializer.Serialize(userCard);
            HttpContent content = new StringContent(userCardJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PostAsync(uri+"/Fee/OneTime", content);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<bool> CheckSubscription(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/Validate"+query);
            var theString = await stringAsync;
            var message = JsonSerializer.Deserialize<bool>(theString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return message;
        }
        
        public async Task<MonthlyFee> GetSubscription(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/Subscription"+query);
            var theString = await stringAsync;
            if (theString != null && theString != "")
            {
                            var message = JsonSerializer.Deserialize<MonthlyFee>(theString, new JsonSerializerOptions
                            {
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                            });
                            return message;
            }

            return null;

        }
        
        public async Task<OneTimeFee> GetEventFee(string username, int eventId)
        {
            var query = $"?username={username}&eventId={eventId}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/OneTime"+query);
            var theString = await stringAsync;
            if (theString != null && theString != "")
            {
                var message = JsonSerializer.Deserialize<OneTimeFee>(theString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return message;
            }

            return null;
        }
        
        public async Task<IList<MonthlyFee>> GetSubscriptionList(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/MonthlyHistory"+query);
            var theString = await stringAsync;
            var message = JsonSerializer.Deserialize<IList<MonthlyFee>>(theString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return message;
        }
        
        public async Task<IList<OneTimeFee>> GetOneTimePaymentList(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/OneTimeHistory"+query);
            var theString = await stringAsync;
            var message = JsonSerializer.Deserialize<IList<OneTimeFee>>(theString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return message;
        }
        
        public async Task<string> MonthlyPaymentAsync(UserCardInfo userCard)
        {
            var userCardJson = JsonSerializer.Serialize(userCard);
            HttpContent content = new StringContent(userCardJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PostAsync(uri+"/Fee/Subscription", content);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }
    }
}