package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.games.Games;
import dk.bookandplay.web_service.SOAPGGLRequest;
import dk.bookandplay.web_service.SOAPGGLResponse;
import dk.bookandplay.web_service.SOAPGameRequest;
import dk.bookandplay.web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class GamesEndpoint {
    private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

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
                response.setGameList(gamesDAO.getSuggestedGames());
                break;
            case REMOVE:
                gamesDAO.delete(request.getId());
        }
        return response;
    }

    @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPGGLRequest")
    @ResponsePayload
    public SOAPGGLResponse gglResponse(@RequestPayload SOAPGGLRequest request) {
        SOAPGGLResponse response = new SOAPGGLResponse();
        switch (request.getOperation()) {
            case GETALL:
                response.setGameList(gamesDAO.getGGL(request.getFilter()));
        }
        return response;
    }
}
