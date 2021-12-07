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
        private readonly HttpClient client;
        private const string uri = "https://localhost:5003";

        public UserService()
        {
            client = new HttpClient();
        }
        
        public async Task<User> ValidateUserAsync(string userName, string password)
        {
            try
            {
                string userAsJson = JsonSerializer.Serialize(new User {Username = userName, Password = password});
                HttpContent content = new StringContent(userAsJson,
                    Encoding.UTF8,
                    "application/json");
                var userValidationResponseMessage = await client.PostAsync(uri + "/User", content);
                if (userValidationResponseMessage.IsSuccessStatusCode)
                {
                    string responseContent = userValidationResponseMessage.Content.ReadAsStringAsync().Result;
                    User validatedUser = JsonConvert.DeserializeObject<User>(responseContent);
                    if (validatedUser == null)
                    {
                        throw new Exception("Username or password incorrect.");
                    }
                    return validatedUser;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
        
        public async Task<string> CreateAccountAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
           var message = await client.PostAsync(uri+"/User/CreateAccount", content);
           return message.IsSuccessStatusCode ? "success" : "Username has already been taken.";
        }
        
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var stringAsync = client.GetStringAsync(uri + $"/User/{username}");
            var userAsync = await stringAsync;
            var user = JsonSerializer.Deserialize<User>(userAsync, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return user;
        }

        public async Task RequestPromotionToOrganizerAsync(string username)
        {
            var usernameAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(usernameAsJson,
                Encoding.UTF8,
                "application/json");
            
            await client.PostAsync(uri+"/User/RequestPromotion", content);
        }

        public async Task AcceptPromotionAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/User/AcceptPromotion", content);
        }
        
        public async Task DeclinePromotionAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/User/DeclinePromotion", content);
        }
        
        public async Task DeleteAccountAsync(string username)
        {
            await client.DeleteAsync($"{uri}/User?username={username}");
        }

        public async Task<IList<User>> GetUsersAsync(FilterREST filterRest)
        {
            var filter = $"?Search={filterRest.Search}&CurrentPage={filterRest.CurrentPage}";
            var usersAsJson = client.GetStringAsync(uri + "/Users" + filter);
            var user = await usersAsJson;
            var users = JsonSerializer.Deserialize<IList<User>>(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return users;
        }

        public async Task EditAccountAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync(uri+"/User/EditAccount", content);
        }
    }
}