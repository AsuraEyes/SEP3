package com.example.producingwebservice.webService;

import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.participants.ParticipantDAO;
import com.example.producingwebservice.participants.Participants;
import com.example.producingwebservice.users.Users;
import io.spring.guides.gs_producing_web_service.SOAPParticipantRequest;
import io.spring.guides.gs_producing_web_service.SOAPParticipantResponse;
import io.spring.guides.gs_producing_web_service.SOAPUserRequest;
import io.spring.guides.gs_producing_web_service.SOAPUserResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class ParticipantEndpoint
{
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private final Participants participantsDAO;
    private final Events eventsDAO;

    @Autowired
    public ParticipantEndpoint(Participants dao, Events eventsDAO) {
      this.participantsDAO = dao;
      this.eventsDAO = eventsDAO;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPParticipantRequest")
    @ResponsePayload
    public SOAPParticipantResponse participantResponse(@RequestPayload SOAPParticipantRequest request) {
      SOAPParticipantResponse response = new SOAPParticipantResponse();
      switch (request.getOperation()) {
        case GET:
          response.setEventList(eventsDAO.getParticipantsEvents(request.getUsername()));
          break;
        case CREATE:
          participantsDAO.join(request.getEventId(), request.getUsername());
          break;
        case UPDATE:
            participantsDAO.withdraw(request.getEventId(), request.getUsername());
          break;
        case GETALL:
        response.getParticipantList().addAll(participantsDAO.getParticipantList(request.getEventId()));
          break;
        case REMOVE:
          // usersDAO.delete(request.getId());
      }
      return response;
    }
}
