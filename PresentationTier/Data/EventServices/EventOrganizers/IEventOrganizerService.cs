using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.EventOrganizers
{
    public interface IEventOrganizerService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}