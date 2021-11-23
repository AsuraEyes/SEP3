using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;

namespace BusinessLayer.Data
{
    public class CategoryWebService : ICategoryWebService
    {
        private BookAndPlayPort port;
        private SOAPCategoryResponse1 response;

        public CategoryWebService()
        {
            port = new BookAndPlayPortClient();
        }

        private async Task<SOAPCategoryResponse1> getCategoryResponse(Operation name)
        {
            SOAPCategoryRequest soapCategoryRequest = new SOAPCategoryRequest();
            soapCategoryRequest.Operation = name;
            SOAPCategoryRequest1 soapRequest1 = new SOAPCategoryRequest1(soapCategoryRequest);
            SOAPCategoryResponse1 soapResponse1 = new SOAPCategoryResponse1();
            soapResponse1 = port.SOAPCategoryAsync(soapRequest1).Result;
            return soapResponse1;
        }

        public async Task<IList<Category>> getCategoriesAsync()
        {
            response = await getCategoryResponse(Operation.GETALL);
            return response.SOAPCategoryResponse.CategoryList;
        }

    }
}