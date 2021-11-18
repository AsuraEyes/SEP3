using System;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Data
{
    public interface IUserService
    {
        Task<string> helloWorld();
        User ValidateUser(string userName, string password);
    }
}