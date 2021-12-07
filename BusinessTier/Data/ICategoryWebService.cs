using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public interface ICategoryWebService
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}