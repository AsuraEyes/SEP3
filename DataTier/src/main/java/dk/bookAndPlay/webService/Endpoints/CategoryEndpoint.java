package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.category.Categories;
import dk.bookandplay.web_service.SOAPCategoryRequest;
import dk.bookandplay.web_service.SOAPCategoryResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class CategoryEndpoint {
    private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

    private final Categories categoryDAO;

    @Autowired
    public CategoryEndpoint(Categories dao) {
        this.categoryDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPCategoryRequest")
    @ResponsePayload
    public SOAPCategoryResponse categoryResponse(@RequestPayload SOAPCategoryRequest request) {
        SOAPCategoryResponse response = new SOAPCategoryResponse();
        switch (request.getOperation()) {
            case GETALL:
                response.setCategoryList(categoryDAO.getCategories());
                break;
        }
        return response;
    }
}
