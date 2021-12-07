using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface IParticipantService
    {
        Task<IList<string>> GetParticipantsAsync(int id);
        Task JoinEventAsync(int id, string username);
        Task WithdrawEventAsync(int id, string username);
        Task<EventList> GetParticipantEventsAsync(string username);
    }
}