using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PresentationTier.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PresentationTier.Data.UserServices
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
                var userValidationResponseMessage = await client.PostAsync(uri + "/User/Login", content);
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
           var message = await client.PostAsync(uri+"/User", content);
           return message.IsSuccessStatusCode ? "success" : "Username has already been taken.";
        }
        
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var stringAsync = client.GetStringAsync(uri + $"/User?username={username}");
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
            
            await client.PostAsync(uri+"/User/Promotion", content);
        }

        public async Task AcceptPromotionAsync(string username)
        {
            var userAsJson = JsonSerializer.Serialize(username);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync(uri+"/User/Promotion", content);
        }
        
        public async Task DeclinePromotionAsync(string username)
        {

            await client.DeleteAsync(uri+$"/User/Promotion/?username={username}");
        }
        
        public async Task DeleteAccountAsync(string username)
        {
            await client.DeleteAsync($"{uri}/User?username={username}");
        }

        public async Task<IList<User>> GetUsersAsync(FilterREST filterRest)
        {
            var filter = $"?Search={filterRest.Search}&CurrentPage={filterRest.CurrentPage}";
            var usersAsJson = client.GetStringAsync(uri + "/User/All" + filter);
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
            await client.PatchAsync(uri+"/User", content);
        }
    }
}