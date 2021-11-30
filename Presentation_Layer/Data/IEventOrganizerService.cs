using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IEventOrganizerService
    {
        Task<EventList> GetOrganizerEventsAsync(string username);
    }
}