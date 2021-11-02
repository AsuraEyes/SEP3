using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace SEP3_Blazor.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient Client;
        private readonly string url = "https://localhost:5003/HelloWorld";

        public UserService()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            Client = new HttpClient(clienthandler);
        }

        public async Task<string> helloWorld()
        {
            try
            {
                var stringAsync = await Client.GetStringAsync(url);
            //    var answer = JsonSerializer.Deserialize<string>(stringAsync, new JsonSerializerOptions
            //    {
            //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //    });
                return stringAsync;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}