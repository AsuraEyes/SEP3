package com.example.producingwebservice.webService;

import com.example.producingwebservice.gameList.GameLists;
import com.example.producingwebservice.games.Games;
import io.spring.guides.gs_producing_web_service.SOAPGameListRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameListResponse;
import io.spring.guides.gs_producing_web_service.SOAPGameRequest;
import io.spring.guides.gs_producing_web_service.SOAPGameResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.server.endpoint.annotation.Endpoint;
import org.springframework.ws.server.endpoint.annotation.PayloadRoot;
import org.springframework.ws.server.endpoint.annotation.RequestPayload;
import org.springframework.ws.server.endpoint.annotation.ResponsePayload;

@Endpoint
public class GameListEndpoint
{
  private static final String NAMESPACE_URI = "http://spring.io/guides/gs-producing-web-service";

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
       // response.setGame(gamesDAO.get(request.getId()));
        break;
      case CREATE:
        gameListDAO.addGameToUserGameList(request.getUserName(), request.getGameId());
        break;
      case UPDATE:
        //gamesDAO.patch(request.getGame());
        break;
      case GETALL:
        break;
      case REMOVE:
        gameListDAO.removeGameFromUserGameList(request.getUserName(), request.getGameId());
        break;
    }
    return response;
  }
}
