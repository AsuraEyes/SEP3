using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data.EventWebServices.Categories
{
    public class CategoryWebService : ICategoryWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPCategoryResponse1 response;

        public CategoryWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPCategoryResponse1> GetCategoryResponseAsync(Operation name)
        {
            var soapCategoryRequest = new SOAPCategoryRequest
            {
                Operation = name
            };
            var soapRequest1 = new SOAPCategoryRequest1(soapCategoryRequest);
            var soapResponse1 = await port.SOAPCategoryAsync(soapRequest1);
            return soapResponse1;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            response = await GetCategoryResponseAsync(Operation.GETALL);
            return response.SOAPCategoryResponse.CategoryList;
        }

    }
}