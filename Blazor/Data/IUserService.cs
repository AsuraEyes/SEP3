using System;
using System.Threading.Tasks;
using SEP3_Blazor.Models;

namespace Data
{
    public interface IUserService
    {
        User ValidateUser(string UserName, string Password);
        Task<String> helloWorld();
    }
}