package com.example.producingwebservice;

import io.spring.guides.gs_producing_web_service.Country;
import io.spring.guides.gs_producing_web_service.Message;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.HashMap;
import java.util.Map;

@Component
public class MessageRepository
{
  private String title;
  private String body;
  private static final Map<String, Message> messages = new HashMap<>();

  @PostConstruct
  public void initData()
  {
    Message helloWorld = new Message();
    helloWorld.setName("Hello");
    helloWorld.setBody("World!");
    messages.put("message",helloWorld);

    Message message = new Message();
    message.setBody("hey");
    message.setName("there");
    messages.put("message1",message);

    Message message1 = new Message();
    message1.setBody("Waassuuuupp!!!!");
    message1.setName("");
    messages.put("message2",message1);
  }

  public Message get(String message)
  {
    return messages.get(message);
  }
}
