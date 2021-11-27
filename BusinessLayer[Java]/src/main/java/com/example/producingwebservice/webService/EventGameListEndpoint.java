package com.example.producingwebservice.webService;

import com.example.producingwebservice.EventGameList.EventGameLists;
import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.SOAPEventGameListRequest;
import io.spring.guides.gs_producing_web_service.SOAPEventGameListResponse;
import io.spring.guides.gs_producing_web_service.SOAPGameRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class EventGameListEndpoint
{
  private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

  private final EventGameLists eventGameListDAO;

  @Autowired
  public EventGameListEndpoint(EventGameLists dao) {
    this.eventGameListDAO = dao;
  }
  //working stuff

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPEventGameListRequest")
  @ResponsePayload
  public SOAPEventGameListResponse gameResponse(@RequestPayload SOAPEventGameListRequest request) {
    SOAPEventGameListResponse response = new SOAPEventGameListResponse();
    switch (request.getOperation()) {
      case GET:

        break;
      case CREATE:

        break;
      case UPDATE:

        break;
      case GETALL:
      response.setGameList(eventGameListDAO.readAllEventGameList(request.getEventId()));
        break;
      case REMOVE:
        break;
    }
    return response;
  }
}
