using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data
{
    public interface IEventOrganizerService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}