package com.example.producingwebservice.users;

import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.User;

public interface Users
{
  User create(User user);
  User get(String username);

}
