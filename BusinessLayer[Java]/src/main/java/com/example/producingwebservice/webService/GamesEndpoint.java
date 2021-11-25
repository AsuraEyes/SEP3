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
            case POST:
                gamesDAO.create(request.getGame());
                break;
            case PATCH:
                gamesDAO.patch(request.getGame());
                break;
            case GETALL:
                if (request.getUserName().equals("")) {
                    response.setGameList(gamesDAO.readAllGGL());
                }
                else{
                    response.setGameList(gamesDAO.readAllUserGameList(request.getUserName()));
                }
//                    response.setGameList(gamesDAO.readAllEventGameList(
//                        request.getId()));
                break;
            case DELETE:
                gamesDAO.delete(request.getId());
        }
        return response;
    }
}
