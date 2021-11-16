package com.example.producingwebservice.games;

import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;
import io.spring.guides.gs_producing_web_service.User;

public interface Games
{
  Game create(Game game);
  GameList readAllGGL();
  GameList readAllUserGameList(String username);
  void delete(int id);
  Game get(int id);
  void patch(Game game);
}
