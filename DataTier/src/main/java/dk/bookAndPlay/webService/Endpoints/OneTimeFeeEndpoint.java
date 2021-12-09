package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.oneTimeFees.OneTimeFees;
import dk.bookandplay.web_service.SOAPOneTimeFeeRequest;
import dk.bookandplay.web_service.SOAPOneTimeFeeResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class OneTimeFeeEndpoint
{
    private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

    private final OneTimeFees oneTimeFeeDAO;

    @Autowired
    public OneTimeFeeEndpoint(OneTimeFees dao) {
      this.oneTimeFeeDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPOneTimeFeeRequest")
    @ResponsePayload
    public SOAPOneTimeFeeResponse oneTimeFeeResponse(@RequestPayload SOAPOneTimeFeeRequest request) {
      SOAPOneTimeFeeResponse response = new SOAPOneTimeFeeResponse();
      switch (request.getOperation()) {
        case GET:
          response.setOneTimeFee(oneTimeFeeDAO.getOneTimeFee(
              request.getUsername(), request.getEventId()));
          break;
        case CREATE:
         oneTimeFeeDAO.create(request.getOneTimeFee());
          break;
        case GETALL:
          response.getOneTimeFeeList().addAll(oneTimeFeeDAO.getOneTimeFeeList(request.getUsername()));
          break;
      }
      return response;
    }
}
