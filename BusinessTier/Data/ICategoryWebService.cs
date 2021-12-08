using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public interface ICategoryWebService
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}