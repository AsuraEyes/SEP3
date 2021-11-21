using System;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Data
{
    public interface IUserService
    {
        Task<string> helloWorld();
        Task<User> ValidateUser(string userName, string password);
    }
}