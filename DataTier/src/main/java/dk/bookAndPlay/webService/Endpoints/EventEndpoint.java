package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.events.Events;
import dk.bookandplay.web_service.SOAPEventOrganizerRequest;
import dk.bookandplay.web_service.SOAPEventOrganizerResponse;
import dk.bookandplay.web_service.SOAPEventRequest;
import dk.bookandplay.web_service.SOAPEventResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class EventEndpoint
{
  private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

  private final Events eventsDAO;

  @Autowired
  public EventEndpoint(Events dao) {
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
        eventsDAO.edit(request.getEvent());
        break;
      case GETALL:
          response.setEventList(eventsDAO.getFilteredEvents(request.getFilter()));
        break;
      case REMOVE:
       eventsDAO.cancel(request.getId());
    }
    return response;
  }

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPEventOrganizerRequest")
  @ResponsePayload
  public SOAPEventOrganizerResponse eventOrganizerResponse(@RequestPayload SOAPEventOrganizerRequest request) {
    SOAPEventOrganizerResponse response = new SOAPEventOrganizerResponse();
    switch (request.getOperation()){
      case GETALL:
       response.setEventList(eventsDAO.getOrganizersEvents(request.getUsername()));
        break;
    }
    return response;
  }
}
