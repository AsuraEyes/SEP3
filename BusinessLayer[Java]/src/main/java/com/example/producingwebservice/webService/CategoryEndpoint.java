package com.example.producingwebservice.webService;

import com.example.producingwebservice.categories.Categories;
import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.SOAPCategoryRequest;
import io.spring.guides.gs_producing_web_service.SOAPCategoryResponse;
import io.spring.guides.gs_producing_web_service.SOAPGameRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class CategoryEndpoint
{
  private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

  private Categories categoryDAO;

  @Autowired
  public CategoryEndpoint(Categories dao) {
    this.categoryDAO = dao;
  }

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPCategoryRequest")
  @ResponsePayload
  public SOAPCategoryResponse categoryResponse(@RequestPayload SOAPCategoryRequest request) {
    SOAPCategoryResponse response = new SOAPCategoryResponse();
    switch (request.getOperation()){
//      case GET :
//      case POST:
//      case PATCH:
//      case DELETE:
      case GETALL:
          response.setCategoryList(categoryDAO.getCategories());
        break;
    }
    return response;
  }
}
