using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public interface IUserWebService
    {
        Task<User> GetUserAsync(string username);
        Task CreateAccountAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteAccountAsync(string username);
        Task<IList<User>> GetUsersAsync(Filter filter);
    }
}