package com.example.producingwebservice.demo_toBeRemovedLater;

import io.spring.guides.gs_producing_web_service.Message;
import io.spring.guides.gs_producing_web_service.MessagesList;

public interface Messages
{
  Message create(Message message);
  MessagesList readAll();
  void delete(int id);
  Message get(int id);
  void patch(Message message);

}
