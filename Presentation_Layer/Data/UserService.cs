using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;
using Presentation_Layer.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
                    string ResponseContent = UserValidationResponseMessage.Content.ReadAsStringAsync().Result;
                    User validatedUser = JsonConvert.DeserializeObject<User>(ResponseContent);
                    if (validatedUser == null)
                    {
                        throw new Exception("Username or password incorrect.");
                    }
                    return validatedUser;
                }

                // if (UserValidationResponseMessage.IsSuccessStatusCode)
                // {
                //     Console.WriteLine("we go here!");
                //     var stringAsync = Client.GetStringAsync(uri + "/User/Validate");
                //     var UserSerialized = await stringAsync;
                //     var User = JsonSerializer.Deserialize<User>(UserSerialized, new JsonSerializerOptions
                //     {
                //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                //     });
                //     Console.WriteLine("user service: "+User.Role);
                //     if (User == null)
                //     {
                //         throw new Exception("Username or password incorrect.");
                //     }
                //
                //     Console.WriteLine(User.Role);
                //     
                //     return User;
                // }
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
        
        public async Task<string> CreateAccountAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
           var message = await Client.PostAsync(uri+"/User/CreateAccount", content);
           return message.IsSuccessStatusCode ? "success" : "Username has already been taken.";
        }
        
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var stringAsync = Client.GetStringAsync(uri + $"/User/{username}");
            var userAsync = await stringAsync;
            var user = JsonSerializer.Deserialize<User>(userAsync, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return user;
        }

        public async Task RequestPromotionToOrganizer()
        {
            // var usernameAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent("",
                Encoding.UTF8,
                "application/json");
            
            var message = await Client.PostAsync(uri+"/User/RequestPromotion", content);
        }

        public async Task AcceptPromotion(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            var message = await Client.PostAsync(uri+"/User/AcceptPromotion", content);
        }
        
        public async Task DeclinePromotion(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            var message = await Client.PostAsync(uri+"/User/DeclinePromotion", content);
        }
        
        public async Task DeleteAccountAsync(string username)
        {
            await Client.DeleteAsync($"{uri}/User?username={username}");
        }
    
    }
}