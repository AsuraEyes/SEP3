using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface ISOAPMessage
    {
        Task<message> GetMessageAsync(int id);
        Task AddMessageAsync(message message);
        Task<IList<message>> GetMessagesAsync();
        Task RemoveMessageAsync(message message);
        Task UpdateMessageAsync(message message);
    }
}