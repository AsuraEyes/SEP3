using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
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

        public async Task<bool> CheckSubscriptionAsync(string username)
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
        
        public async Task<MonthlyFee> GetSubscriptionAsync(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/Subscription"+query);
            var theString = await stringAsync;
            var message = new MonthlyFee();
            try
            {
                if (theString != "")
                {
                    message = JsonSerializer.Deserialize<MonthlyFee>(theString, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return message;
        }
        
        public async Task<OneTimeFee> GetEventFeeAsync(string username, int eventId)
        {
            var query = $"?username={username}&eventId={eventId}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/OneTime"+query);
            var theString = await stringAsync;
            if (theString == "") return null;
            var message = JsonSerializer.Deserialize<OneTimeFee>(theString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return message;
        }
        
        public async Task<IList<MonthlyFee>> GetSubscriptionListAsync(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/MonthlyHistory"+query);
            var theString = await stringAsync;
            IList<MonthlyFee> message = new List<MonthlyFee>();
            try
            {
                message = JsonSerializer.Deserialize<IList<MonthlyFee>>(theString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return message;
        }
        
        public async Task<IList<OneTimeFee>> GetOneTimePaymentListAsync(string username)
        {
            var query = $"?username={username}";
            var stringAsync = client.GetStringAsync(uri + $"/Fee/OneTimeHistory"+query);
            var theString = await stringAsync;
            IList<OneTimeFee> message = new List<OneTimeFee>();
            try
            {
                message = JsonSerializer.Deserialize<IList<OneTimeFee>>(theString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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