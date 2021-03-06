using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Participants
{
    public interface IParticipantWebService
    {
        Task<IList<string>> GetParticipantsAsync(int eventId);
        Task JoinEventAsync(int id, string username);
        Task WithdrawEventAsync(int id, string username);
        Task<EventList> GetParticipantEventsAsync(string username);
    }
}