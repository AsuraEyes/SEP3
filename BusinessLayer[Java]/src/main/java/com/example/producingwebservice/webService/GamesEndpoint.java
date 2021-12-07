package com.example.producingwebservice.webService;

import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.SOAPGameRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class GamesEndpoint {
    private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

    private final Games gamesDAO;

    @Autowired
    public GamesEndpoint(Games dao) {
        this.gamesDAO = dao;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPGameRequest")
    @ResponsePayload
    public SOAPGameResponse gameResponse(@RequestPayload SOAPGameRequest request) {
        SOAPGameResponse response = new SOAPGameResponse();
        switch (request.getOperation()) {
            case GET:
                response.setGame(gamesDAO.get(request.getId()));
                break;
            case CREATE:
                gamesDAO.create(request.getGame());
                break;
            case UPDATE:
                gamesDAO.patch(request.getGame());
                break;
            case GETALL:
                response.setGameList(gamesDAO.searchLimitGGL(request.isApproved(), request.getFilter()));
                //response.setGameList(gamesDAO.readAllGGL(request.isApproved()));
                break;
            case REMOVE:
                gamesDAO.delete(request.getId());
        }
        return response;
    }
}
