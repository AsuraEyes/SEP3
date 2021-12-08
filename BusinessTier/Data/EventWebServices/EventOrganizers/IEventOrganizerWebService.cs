using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.EventOrganizers
{
    public interface IEventOrganizerWebService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}