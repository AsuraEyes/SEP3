package com.example.producingwebservice.EventGameList;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import com.example.producingwebservice.games.GameDAO;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

public class EventGameListDAO implements EventGameLists
{

  private DatabaseHelper<Game> helper;
  private final GameList gameList;
  //private EventGameList eventGameList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public EventGameListDAO() {
    gameList = new GameList();
    //eventGameList = new EventGameList();
  }

  private static Game createGame(int id, String name, int complexity, int timeEstimation,
      int minNumberOfPlayers, int maxNumberOfPlayers, String shortDescription, String neededEquipment,
      int minAge, int maxAge, String tutorial, boolean approved) {
    Game newGame = new Game();
    newGame.setId(id);
    newGame.setName(name);
    newGame.setComplexity(complexity);
    newGame.setTimeEstimation(timeEstimation);
    newGame.setMinNumberOfPlayers(minNumberOfPlayers);
    newGame.setMaxNumberOfPlayers(maxNumberOfPlayers);
    newGame.setShortDescription(shortDescription);
    newGame.setNeededEquipment(neededEquipment);
    newGame.setMinAge(minAge);
    newGame.setMaxAge(maxAge);
    newGame.setTutorial(tutorial);
    newGame.setApproved(approved);
    return newGame;
  }

  private DatabaseHelper<Game> helper() {
    if (helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  public Game create(Game game) {
    helper().executeUpdate(
        "INSERT INTO game(name, complexity, time_estimation, min_number_of_players, max_number_of_players, short_description, needed_equipment, min_age, max_age, tutorial, approved) "
            + "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", game.getName(), game.getComplexity(),
        game.getTimeEstimation(), game.getMinNumberOfPlayers(), game.getMaxNumberOfPlayers(), game.getShortDescription(),
        game.getNeededEquipment(), game.getMinAge(), game.getMaxAge(), game.getTutorial(), game.isApproved());
    return game;
  }

  public GameList readAllEventGameList(int eventId) {
    gameList.getGameList().clear();
    gameList.getGameList().addAll(helper().map(new GameMapper(), "SELECT * FROM event_game_list l, game g WHERE l.game_id = g.id AND event_id = ?", eventId));

    return gameList;
  }

  public void removeGameFromEventGameList(int gameId, int eventId, String username){
    helper.executeUpdate("DELETE FROM event_game_list WHERE user_username = ? AND game_id = ? AND event_id = ?;", username, gameId, eventId);
  }

  public void addGameToEventGameList(int gameId, int eventId, String username){
    helper.executeUpdate("INSERT INTO event_game_list VALUES (?, ?, ?);", gameId, username, eventId);
  }

  private static class GameMapper implements DataMapper<Game>
  {
    public Game create(ResultSet rs) throws SQLException
    {
      int id = rs.getInt("id");
      String name = rs.getString("name");
      int complexity = rs.getInt("complexity");
      int timeEstimation = rs.getInt("time_estimation");
      int minNumberOfPlayers = rs.getInt("min_number_of_players");
      int maxNumberOfPlayers = rs.getInt("max_number_of_players");
      String shortDescription = rs.getString("short_description");
      String neededEquipment = rs.getString("needed_equipment");
      int minAge = rs.getInt("min_age");
      int maxAge = rs.getInt("max_age");
      String tutorial = rs.getString("tutorial");
      boolean approved = rs.getBoolean("approved");

      return createGame(id, name, complexity, timeEstimation, minNumberOfPlayers, maxNumberOfPlayers, shortDescription,
          neededEquipment, minAge, maxAge, tutorial, approved);
    }
  }
}
