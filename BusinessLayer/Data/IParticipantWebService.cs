using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface IParticipantWebService
    {
        Task<IList<string>> GetParticipantsAsync(int eventId);
    }
}