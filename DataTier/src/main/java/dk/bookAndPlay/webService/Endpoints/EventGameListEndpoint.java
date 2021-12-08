package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.eventGameLists.EventGameLists;
import dk.bookandplay.web_service.SOAPEventGameListRequest;
import dk.bookandplay.web_service.SOAPEventGameListResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class EventGameListEndpoint
{
  private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

  private final EventGameLists eventGameListDAO;

  @Autowired
  public EventGameListEndpoint(EventGameLists dao) {
    this.eventGameListDAO = dao;
  }

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPEventGameListRequest")
  @ResponsePayload
  public SOAPEventGameListResponse gameResponse(@RequestPayload SOAPEventGameListRequest request) {
    SOAPEventGameListResponse response = new SOAPEventGameListResponse();
    switch (request.getOperation()) {
      case GET:
      case CREATE:
        eventGameListDAO.addGameToEventGameList(request.getGameId(), request.getEventId(), request.getUsername());
        break;
      case UPDATE:
      case GETALL:
      response.setGameList(eventGameListDAO.readAllEventGameList(request.getEventId()));
        break;
      case REMOVE:
        eventGameListDAO.removeGameFromEventGameList(request.getGameId(), request.getEventId(), request.getUsername());
        break;
    }
    return response;
  }
}
