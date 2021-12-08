using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public interface IEventOrganizerWebService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}