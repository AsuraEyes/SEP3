package com.example.producingwebservice.gameList;

import io.spring.guides.gs_producing_web_service.GameList;

import java.util.List;

public interface GameLists
{
  GameList readAllUserGameList(String username);
  void addGameToUserGameList(String username, int id);
  void removeGameFromUserGameList(String username, int id);
}
