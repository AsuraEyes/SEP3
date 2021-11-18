using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Presentation_Layer.Models;

namespace SEP3_Blazor.Data
{
    public class UserService : IUserService
    {
        private IList<User> users;
        

        private readonly HttpClient Client;
        private readonly string url = "https://localhost:5001";

        public UserService()
        {
            //HttpClientHandler clienthandler = new HttpClientHandler();
           // clienthandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            //Client = new HttpClient(clienthandler);
            Client = new HttpClient();
            
            users = new[]
            {
                new User
                {
                    Password = "123456",
                    RoleId = 3,
                    Username = "Maggie"

                },
                new User
                {
                    Password = "admin",
                    RoleId = 1,
                    Username = "admin"

                },
                new User
                {
                    Password = "123",
                    RoleId = 3,
                    Username = "Kim"

                },
                new User
                {
                    Password = "123",
                    RoleId = 2,
                    Username = "someone"

                },
                new User
                {
                    Password = "123",
                    RoleId = 2,
                    Username = "nobody"
                }
            }.ToList();
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
        
        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}