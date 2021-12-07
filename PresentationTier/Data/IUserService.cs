﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
        Task<string> CreateAccountAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task RequestPromotionToOrganizerAsync(string username);
        Task AcceptPromotionAsync(User user);
        Task DeclinePromotionAsync(User user);
        Task DeleteAccountAsync(string username);
        Task<IList<User>> GetUsersAsync();
        Task EditAccountAsync(User user);
    }
}