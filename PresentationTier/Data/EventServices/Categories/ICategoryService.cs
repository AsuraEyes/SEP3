using System.Collections.Generic;
using System.Threading.Tasks;
using PresentationTier.Models;

namespace PresentationTier.Data.EventServices.Categories
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetCategoriesAsync();
    }
}