using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IEventGameListWebService
    {
        Task<IList<Game>> GetAllEventGameListAsync(int eventId);
    }
}