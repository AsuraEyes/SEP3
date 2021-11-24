package com.example.producingwebservice.webService;

import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.SOAPEventRequest;
import io.spring.guides.gs_producing_web_service.SOAPEventResponse;
import io.spring.guides.gs_producing_web_service.SOAPGameRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class EventsEndpoint
{
  private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

  private Events eventsDAO;

  @Autowired
  public EventsEndpoint(Events dao) {
    this.eventsDAO = dao;
  }

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPEventRequest")
  @ResponsePayload
  public SOAPEventResponse eventResponse(@RequestPayload SOAPEventRequest request) {
    SOAPEventResponse response = new SOAPEventResponse();
    switch (request.getOperation()){
      case GET:
        response.setEvent(eventsDAO.get(request.getId()));
        break;
      case POST:
        eventsDAO.create(request.getEvent());
        break;
      case PATCH:
        //eventsDAO.patch(request.getEvent());
        break;
      case GETALL:
          response.setEventList(eventsDAO.searchAndFilter(request.getFilter(),
              request.getId(), request.getCurrentPage(), request.getResultsPerPage()));
          //response.setNumberOfPages(eventsDAO.getNumberOfPages(request.getResultsPerPage()));
        break;
      case DELETE:
       // eventsDAO.delete(request.getId());
    }
    return response;
  }
}
