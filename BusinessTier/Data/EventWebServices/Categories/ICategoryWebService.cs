using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Categories
{
    public interface ICategoryWebService
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}