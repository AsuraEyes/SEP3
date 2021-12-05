using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IOrganizerWebService
    {
        Task<IList<string>> GetOrganizersAsync(int eventId);
        Task CoOrganizeEventAsync(int id, string username);
        Task WithdrawEventAsync(int id, string username);
        Task<EventList> GetCoOrganizerEventsAsync(string username);
    }
}