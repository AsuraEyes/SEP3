package com.example.producingwebservice;

import io.spring.guides.gs_producing_web_service.Country;
import io.spring.guides.gs_producing_web_service.Message;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;

@Component
public class MessageRepository
{
  private String title;
  private String body;
  private Message message;

  @PostConstruct
  public void initData()
  {
    message = new Message();
    message.setName("Hello");
    message.setBody("World!");
  }

  public Message get()
  {
    return message;
  }
}
