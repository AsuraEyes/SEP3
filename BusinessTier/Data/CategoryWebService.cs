using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessTier.Data
{
    public class CategoryWebService : ICategoryWebService
    {
        private readonly BookAndPlayPort port;
        private SOAPCategoryResponse1 response;

        public CategoryWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPCategoryResponse1> getCategoryResponseAsync(Operation name)
        {
            SOAPCategoryRequest soapCategoryRequest = new SOAPCategoryRequest();
            soapCategoryRequest.Operation = name;
            SOAPCategoryRequest1 soapRequest1 = new SOAPCategoryRequest1(soapCategoryRequest);
            SOAPCategoryResponse1 soapResponse1 = new SOAPCategoryResponse1();
            soapResponse1 = port.SOAPCategoryAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            response = await getCategoryResponseAsync(Operation.GETALL);
            return response.SOAPCategoryResponse.CategoryList;
        }

    }
}