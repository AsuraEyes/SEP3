package com.example.producingwebservice;

import io.spring.guides.gs_producing_web_service.Country;
import io.spring.guides.gs_producing_web_service.Message;
import io.spring.guides.gs_producing_web_service.MessagesList;
import org.springframework.http.server.DelegatingServerHttpResponse;
import org.springframework.stereotype.Component;

import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Component
public class MessageRepository
{
  private String title;
  private String body;
  private  MessagesList messagesList = new MessagesList();
  private List<Message> list;

  @PostConstruct
  public void initData()
  {
    list = messagesList.getMessages();
    Message helloWorld = new Message();
    helloWorld.setId(0);
    helloWorld.setName("Hello");
    helloWorld.setBody("World!");
    list.add(helloWorld);


    Message message = new Message();
    message.setBody("hey");
    message.setName("there");
    message.setId(1);
    list.add(message);

    Message message1 = new Message();
    message1.setBody("Waassuuuupp!!!!");
    message1.setName("");
    message1.setId(2);
    list.add(message1);
  }

  public MessagesList getMessages(){
    return messagesList;
  }

  public String delete(int id){
    Message toRemove = new Message();
    for (Message message: list)
    {
      if(message.getId() == id ){
        toRemove = message;
      }
    }
    list.remove(toRemove);
    return "Removed successfully";
  }

  public String update(Message message){
    Message toRemove = new Message();
    for (Message message0: list)
    {
      if(message0.getId() == message.getId() ){
        toRemove = message;
      }
    }
    list.remove(toRemove);
    list.add(message);
    return "Updated successfully";
  }

  public String add(Message message){
    Message id = new Message();
    if(!list.isEmpty())
    {
       id = list.get(list.size() - 1);
      message.setId(id.getId()+1);
    }
    else
    {
      message.setId(0);
    }

    list.add(message);
    return "Added successfully";
  }

  public Message getMessage(int id)
  {
    return list.get(id);
  }
}
