package com.example.producingwebservice.games;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Filter;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

public class GameDAO implements Games {
    private DatabaseHelper<Game> helper;
    private final GameList gameList;

    @Resource(name = "jdbcUrl")
    private String jdbcUrl;

    @Resource(name = "username")
    private String username;

    @Resource(name = "password")
    private String password;

    public GameDAO() {
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

    public GameList readAllGGL(boolean approved) {
        gameList.getGameList().clear();
        gameList.getGameList().addAll(helper().map(new GameMapper(), "SELECT * FROM game WHERE approved = ?", approved));
        return gameList;
    }

    public GameList searchLimitGGL(boolean approved, Filter filter) {
        String search = "%"+filter.getFilter()+"%";
        gameList.getGameList().clear();
        gameList.getGameList().addAll(helper().map(new GameMapper(), "SELECT * FROM game WHERE approved = ? AND name ILIKE ? LIMIT ? OFFSET ?;", approved, search, filter.getLimit(), filter.getOffset()));
        return gameList;
    }

//    public GameList readAllUserGameList(String username) {
//        gameList.getGameList().clear();
//        gameList.getGameList().addAll(helper().map(new GameMapper(), "SELECT * FROM game_list l, game g WHERE l.game_id = g.id AND user_username = ?", username));
//        return gameList;
//    }

    public void delete(int id) {
        helper().executeUpdate("DELETE FROM game WHERE id = ?", id);
    }

    public Game get(int id) {
        return helper().mapSingle(new GameMapper(), "SELECT * FROM game WHERE id = ?", id);
    }

    public void patch(Game game) {
        helper().executeUpdate("UPDATE game SET name = ?, complexity = ?, time_estimation = ?, min_number_of_players = ?, max_number_of_players = ?, short_description = ?, "
                        + "needed_equipment = ?, min_age = ?, max_age = ?, tutorial = ?, approved = ? WHERE id = ?", game.getName(), game.getComplexity(),
                game.getTimeEstimation(), game.getMinNumberOfPlayers(), game.getMaxNumberOfPlayers(), game.getShortDescription(),
                game.getNeededEquipment(), game.getMinAge(), game.getMaxAge(), game.getTutorial(), game.isApproved(), game.getId());
    }

    private static class GameMapper implements DataMapper<Game> {
        public Game create(ResultSet rs) throws SQLException {
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

