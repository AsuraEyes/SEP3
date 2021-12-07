using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface IEventOrganizerWebService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}