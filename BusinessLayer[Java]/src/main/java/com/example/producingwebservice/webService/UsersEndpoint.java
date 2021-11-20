package com.example.producingwebservice.webService;
import com.example.producingwebservice.users.Users;
import io.spring.guides.gs_producing_web_service.SOAPUserRequest;
import io.spring.guides.gs_producing_web_service.SOAPUserResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class UsersEndpoint
{
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private Users usersDAO;

    @Autowired
    public UsersEndpoint(Users dao) {
      this.usersDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPUserRequest")
    @ResponsePayload
    public SOAPUserResponse userResponse(@RequestPayload SOAPUserRequest request) {
      SOAPUserResponse response = new SOAPUserResponse();
      switch (request.getOperation()){
        case GET:
          response.setUser(usersDAO.get(request.getUsername()));
          break;
        case POST:
          usersDAO.create(request.getUser());
          break;
        case PATCH:
          //eventsDAO.patch(request.getEvent());
          break;
        case GETALL:
          //response.setEventList(eventsDAO.searchAndFilter(request.getFilter(),
          //    request.getId()));
          break;
        case DELETE:
          // eventsDAO.delete(request.getId());
      }
      return response;
    }
}
