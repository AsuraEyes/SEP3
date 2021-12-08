package dk.bookAndPlay.games;

import dk.bookandplay.web_service.Filter;
import dk.bookandplay.web_service.Game;
import dk.bookandplay.web_service.GameList;

public interface Games {
    Game create(Game game);

    GameList getSuggestedGames();
    GameList getGGL(Filter filter);

    void delete(int id);

    Game get(int id);

    void patch(Game game);
}
