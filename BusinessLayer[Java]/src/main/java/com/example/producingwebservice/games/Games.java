package com.example.producingwebservice.games;

import io.spring.guides.gs_producing_web_service.Filter;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;

public interface Games {
    Game create(Game game);

    GameList readAllGGL(boolean approved);
    GameList searchLimitGGL(boolean approved, Filter filter);

    void delete(int id);

    Game get(int id);

    void patch(Game game);
}
