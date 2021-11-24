using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation_Layer.Data
{
    public interface IParticipantService
    {
        Task<IList<string>> GetParticipantsAsync(int id);
        Task JoinEvent(int id, string username);
        Task WithdrawEvent(int id, string username);
    }
}