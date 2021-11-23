using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation_Layer.Data
{
    public interface IOrganizerService
    {
        Task<IList<string>> GetOrganizersAsync(int id);
    }
}