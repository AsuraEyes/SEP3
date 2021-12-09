package dk.bookAndPlay.webService.Endpoints;

import dk.bookAndPlay.DAO.gameLists.GameLists;
import dk.bookandplay.web_service.SOAPGameListRequest;
import dk.bookandplay.web_service.SOAPGameListResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class GameListEndpoint
{
  private static final String NAMESPACE_URI = "http://bookAndPlay.dk/web-service";

  private final GameLists gameListDAO;

  @Autowired
  public GameListEndpoint(GameLists dao) {
    this.gameListDAO = dao;
  }

  @PayloadRoot(namespace = NAMESPACE_URI, localPart = "SOAPGameListRequest")
  @ResponsePayload
  public SOAPGameListResponse gameListResponse(@RequestPayload SOAPGameListRequest request) {
    SOAPGameListResponse response = new SOAPGameListResponse();
    switch (request.getOperation()) {
      case GET:
        response.setGameList(gameListDAO.readAllUserGameList(request.getUserName()));
        break;
      case CREATE:
        gameListDAO.addGameToUserGameList(request.getUserName(), request.getGameId());
        break;
      case REMOVE:
        gameListDAO.removeGameFromUserGameList(request.getUserName(), request.getGameId());
        break;
    }
    return response;
  }
}
