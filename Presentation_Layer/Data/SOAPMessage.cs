using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public class SOAPMessage : ISOAPMessage
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public SOAPMessage()
        {
            client = new HttpClient();
        }
        
        public async Task<message> GetMessageAsync(int id)
        {
            var stringAsync = client.GetStringAsync(uri + $"/Message/{id}");
            var messagea = await stringAsync;
            var message = JsonSerializer.Deserialize<message>(messagea, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return message;
        }

        public async Task AddMessageAsync(message message)
        {
            string messageAsJson = JsonSerializer.Serialize(message);
            HttpContent content = new StringContent(messageAsJson,
                Encoding.UTF8,
                "application/json");
             await client.PostAsync(uri+"/Message", content);
        }

        public async Task<IList<message>> GetMessagesAsync()
        {
            var stringAsync = client.GetStringAsync(uri + "/messages");
            var message = await stringAsync;
            var messages = JsonSerializer.Deserialize<List<message>>(message, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return messages;
        }

        public async Task UpdateMessageAsync(message message)
        {
            string messageAsJson = JsonSerializer.Serialize(message);
            HttpContent content = new StringContent(messageAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/Message/", content);
        }

        public async Task RemoveMessageAsync(message message)
        {
            await client.DeleteAsync($"{uri}/Message/{message.id}");
        }
        
    }
}