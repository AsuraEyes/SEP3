using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private readonly string uri = "https://localhost:5003";

        public UserService()
        {
            Client = new HttpClient();
            
            users = new[]
            {
                new User
                {
                    Password = "123456",
                    Role = 3,
                    Username = "Maggie"

                },
                new User
                {
                    Password = "admin",
                    Role = 1,
                    Username = "admin"

                },
                new User
                {
                    Password = "123",
                    Role = 3,
                    Username = "Kim"

                },
                new User
                {
                    Password = "123",
                    Role = 2,
                    Username = "someone"

                },
                new User
                {
                    Password = "123",
                    Role = 2,
                    Username = "nobody"
                }
            }.ToList();
        }

        public async Task<string> helloWorld()
        {
            try
            {
                var stringAsync = await Client.GetStringAsync(uri);
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
        
        public async Task<User> ValidateUser(string userName, string password)
        {
            try
            {
                string UserAsJson = JsonSerializer.Serialize(new User {Username = userName, Password = password});
                HttpContent content = new StringContent(UserAsJson,
                    Encoding.UTF8,
                    "application/json");
                var UserValidationResponseMessage = await Client.PostAsync(uri + "/User", content);
                
                
                if (UserValidationResponseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("we go here!");
                    var stringAsync = Client.GetStringAsync(uri + "/User/Validate");
                    var UserSerialized = await stringAsync;
                    var User = JsonSerializer.Deserialize<User>(UserSerialized, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    Console.WriteLine("user service: "+User.Role);
                    if (User == null)
                    {
                        throw new Exception("Username or password incorrect.");
                    }

                    Console.WriteLine(User.Role);
                    
                    return User;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            /*
            User first = users.FirstOrDefault(user => user.Username.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;*/
            return null;
        }
        
        public async Task CreateAccountAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await Client.PostAsync(uri+"/User/CreateAccount", content);
        }
    }
}