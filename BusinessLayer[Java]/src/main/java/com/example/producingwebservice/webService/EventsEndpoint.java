package com.example.producingwebservice.webService;

import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.*;
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
      case CREATE:
        eventsDAO.create(request.getEvent());
        break;
      case UPDATE:
        //eventsDAO.patch(request.getEvent());
        break;
      case GETALL:
          response.setEventList(eventsDAO.searchAndFilter(request.getFilter()));
          //response.setNumberOfPages(eventsDAO.getNumberOfPages(request.getResultsPerPage()));
        break;
      case REMOVE:
       eventsDAO.cancel(request.getId());
    }
    return response;
  }

  public SOAPEventOrganizerResponse eventOrganizerResponse(@RequestPayload SOAPEventOrganizerRequest request) {
    SOAPEventOrganizerResponse response = new SOAPEventOrganizerResponse();
    switch (request.getOperation()){
      case GET:
        //response.setEvent(eventsDAO.get(request.getId()));
        break;
      case CREATE:
        //eventsDAO.create(request.getEvent());
        break;
      case UPDATE:
        //eventsDAO.patch(request.getEvent());
        break;
      case GETALL:
       // response.setEventList(eventsDAO.searchAndFilter(request.getFilter()));
        //response.setNumberOfPages(eventsDAO.getNumberOfPages(request.getResultsPerPage()));
        break;
      case REMOVE:
       // eventsDAO.cancel(request.getId());
    }
    return response;
  }
}
