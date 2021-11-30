package com.example.producingwebservice.webService;

import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.organizers.Organizers;
import com.example.producingwebservice.users.Users;
import io.spring.guides.gs_producing_web_service.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class OrganizerEndpoint
{

    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private final Organizers organizersDAO;
    private final Events eventsDAO;

    @Autowired
    public OrganizerEndpoint(Organizers dao, Events eventsDAO) {
      this.organizersDAO = dao;
      this.eventsDAO = eventsDAO;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPOrganizerRequest")
    @ResponsePayload
    public SOAPOrganizerResponse organizerResponse(@RequestPayload SOAPOrganizerRequest request) {
      SOAPOrganizerResponse response = new SOAPOrganizerResponse();
      switch (request.getOperation()) {
        case GET:
            response.setEventList(eventsDAO.getCoOrganizersEvents(request.getUsername()));
          break;
        case CREATE:
          organizersDAO.organize(request.getEventId(), request.getUsername());
          break;
        case UPDATE:
          organizersDAO.withdraw(request.getEventId(), request.getUsername());
          break;
        case GETALL:
          response.getOrganizerList().addAll(organizersDAO.getOrganizerList(request.getEventId()));
          //    request.getId()));
          break;
        case REMOVE:
          // usersDAO.delete(request.getId());
      }
      return response;
    }

}
