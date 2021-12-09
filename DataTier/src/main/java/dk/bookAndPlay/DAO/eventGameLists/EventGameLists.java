package dk.bookAndPlay.DAO.eventGameLists;

import dk.bookandplay.web_service.GameList;

public interface EventGameLists
{
  GameList getEventGameList(int eventId);
  void removeGameFromEventGameList(int gameId, int eventId, String username);
  void addGameToEventGameList(int gameId, int eventId, String username);
}
