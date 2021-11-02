using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using SEP3_Blazor.Models;

namespace SEP3_Blazor.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient Client;
        private readonly string url = "https://localhost:6000";
        
        private readonly List<User> users;

        public UserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new User
                {
                    UserName = "Tom",
                    Password = "101010",
                    Role = "ORGANIZER"
                },
                new User
                {
                    UserName = "Anja",
                    Password = "101010",
                    Role = "PLAYER"
                }
            }.ToList();
        }

        public User ValidateUser(string UserName, string Password)
        {
            var temp = users.FirstOrDefault(user => user.UserName.Equals(UserName));
            if (temp == null) throw new Exception("User not found");

            if (!temp.Password.Equals(Password)) throw new Exception("Incorrect password");

            return temp;
        }

        public async Task<string> helloWorld()
        {
            try
            {
                var stringAsync = await Client.GetStringAsync(url);
                var answer = JsonSerializer.Deserialize<string>(stringAsync, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return answer;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }
    }
}