using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MessageServerReference;

namespace BusinessLayer.Data
{
    public interface ISOAPWebService
    {
        Task<message> GetMessageAsync(int id);
        Task AddMessageAsync(message message);
        Task<IList<message>> GetMessagesAsync();
        Task RemoveMessageAsync(int id);
        Task EditMessageAsync(message message);
    }
}