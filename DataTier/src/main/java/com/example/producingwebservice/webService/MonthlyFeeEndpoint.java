package com.example.producingwebservice.webService;

import com.example.producingwebservice.monthlyFee.MonthlyFees;
import io.spring.guides.gs_producing_web_service.SOAPCategoryRequest;
import io.spring.guides.gs_producing_web_service.SOAPCategoryResponse;
import io.spring.guides.gs_producing_web_service.SOAPMonthlyFeeRequest;
import io.spring.guides.gs_producing_web_service.SOAPMonthlyFeeResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

import java.text.ParseException;

@Endpoint
public class MonthlyFeeEndpoint
{
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private final MonthlyFees monthlyFeeDAO;

    @Autowired
    public MonthlyFeeEndpoint(MonthlyFees dao) {
      this.monthlyFeeDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPMonthlyFeeRequest")
    @ResponsePayload
    public SOAPMonthlyFeeResponse monthlyFeeResponse(@RequestPayload SOAPMonthlyFeeRequest request)
        throws ParseException
    {
      SOAPMonthlyFeeResponse response = new SOAPMonthlyFeeResponse();
      switch (request.getOperation()) {
        case GET:
          response.setMonthlyFee(monthlyFeeDAO.getMonthlyFee(
              request.getUsername()));
          break;
        case CREATE:
          monthlyFeeDAO.create(request.getMonthlyFee());
          break;
        case UPDATE:
          monthlyFeeDAO.updateMonthlyFee(request.getMonthlyFee());
          break;
        case GETALL:
          response.getMonthlyFeeList().addAll(monthlyFeeDAO.getMonthlyFeeList(
              request.getUsername()));
          break;
        case REMOVE:
          break;
      }
      return response;
    }
}
