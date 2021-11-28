package com.example.producingwebservice.gameList;

import io.spring.guides.gs_producing_web_service.GameList;

public interface GameLists
{
  GameList readAllUserGameList(String username);
}
