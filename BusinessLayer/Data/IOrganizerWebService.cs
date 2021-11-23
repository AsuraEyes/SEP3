using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Data
{
    public interface IOrganizerWebService
    {
        Task<IList<string>> GetOrganizersAsync(int eventId);
    }
}