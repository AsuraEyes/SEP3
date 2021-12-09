using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.Organizers
{
    public interface IOrganizerService
    {
        Task<IList<string>> GetOrganizersAsync(int id);
        Task CoOrganizeEventAsync(int id, string username);
        Task WithdrawEventAsync(int id, string username);
        Task<EventList> GetCoOrganizerEventsAsync(string username);
    }
}