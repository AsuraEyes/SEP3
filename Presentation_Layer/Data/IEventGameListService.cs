using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IEventGameListService
    {
        Task<IList<Game>> GetAllEventGameListAsync(int id);
    }
}