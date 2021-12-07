using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation_Layer.Models;

namespace Presentation_Layer.Data
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}