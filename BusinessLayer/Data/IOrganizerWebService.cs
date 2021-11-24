using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface IOrganizerWebService
    {
        Task<IList<string>> GetOrganizersAsync(int eventId);
        Task CoOrganizeEvent(int id, string username);
        Task WithdrawEventAsync(int id, string username);
    }
}