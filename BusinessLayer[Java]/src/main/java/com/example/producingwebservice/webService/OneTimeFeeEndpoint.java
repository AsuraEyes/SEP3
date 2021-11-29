package com.example.producingwebservice.webService;

import com.example.producingwebservice.OneTimeFee.OneTimeFees;
import com.example.producingwebservice.monthlyFee.MonthlyFees;
import io.spring.guides.gs_producing_web_service.SOAPCategoryRequest;
import io.spring.guides.gs_producing_web_service.SOAPCategoryResponse;
import io.spring.guides.gs_producing_web_service.SOAPOneTimeFeeRequest;
import io.spring.guides.gs_producing_web_service.SOAPOneTimeFeeResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class OneTimeFeeEndpoint
{
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

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
        case UPDATE:

          break;
        case GETALL:
          break;
        case REMOVE:
          break;
      }
      return response;
    }
}
