using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IOrganizerService
    {
        Task<IList<string>> GetOrganizersAsync(int id);
        Task CoOrganizeEvent(int id, string username);
        Task WithdrawEvent(int id, string username);
        Task<EventList> GetCoOrganizerEventsAsync(string username);
    }
}