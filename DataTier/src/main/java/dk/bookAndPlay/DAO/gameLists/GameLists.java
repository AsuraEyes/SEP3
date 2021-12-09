package dk.bookAndPlay.DAO.gameLists;

import dk.bookandplay.web_service.GameList;

public interface GameLists
{
  GameList readAllUserGameList(String username);
  void addGameToUserGameList(String username, int id);
  void removeGameFromUserGameList(String username, int id);
}
