package dk.bookAndPlay.DAO.gameLists;

import dk.bookAndPlay.db.DataMapper;
import dk.bookAndPlay.db.DatabaseHelper;
import dk.bookandplay.web_service.Game;
import dk.bookandplay.web_service.GameList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

public class GameListDAO implements GameLists
{
  private DatabaseHelper<Game> gameHelper;
  private DatabaseHelper<Integer> integerHelper;
  private final GameList gameList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public GameListDAO() {
    gameList = new GameList();
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

  private DatabaseHelper<Game> gameHelper() {
    if (gameHelper == null)
      gameHelper = new DatabaseHelper<>(jdbcUrl, username, password);
    return gameHelper;
  }

  public Game create(Game game) {
    gameHelper().executeUpdate(
        "INSERT INTO game(name, complexity, time_estimation, min_number_of_players, max_number_of_players, short_description, needed_equipment, min_age, max_age, tutorial, approved) "
            + "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", game.getName(), game.getComplexity(),
        game.getTimeEstimation(), game.getMinNumberOfPlayers(), game.getMaxNumberOfPlayers(), game.getShortDescription(),
        game.getNeededEquipment(), game.getMinAge(), game.getMaxAge(), game.getTutorial(), game.isApproved());
    return game;
  }

  public GameList readAllUserGameList(String username) {
    gameList.getGameList().clear();
    gameList.getGameList().addAll(gameHelper().map(new GameMapper(), "SELECT * FROM game_list l, game g WHERE l.game_id = g.id AND user_username = ?", username));
    return gameList;
  }

  public void addGameToUserGameList(String username, int id){
    gameHelper.executeUpdate("INSERT INTO game_list VALUES (?, ?);", id, username);
  }

  public void removeGameFromUserGameList(String username, int id){
    gameHelper.executeUpdate("DELETE FROM game_list WHERE user_username = ? AND game_id = ?;", username, id);
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
