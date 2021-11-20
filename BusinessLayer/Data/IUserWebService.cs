using System;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IUserWebService
    {
        Task<User> GetUserAsync(string username);
        Task AddUserAsync(User user);
    }
}