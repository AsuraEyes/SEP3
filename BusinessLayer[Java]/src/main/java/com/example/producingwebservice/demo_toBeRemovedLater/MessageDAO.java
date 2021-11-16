package com.example.producingwebservice.demo_toBeRemovedLater;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Message;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

import io.spring.guides.gs_producing_web_service.MessagesList;

public class MessageDAO implements Messages
{
    private DatabaseHelper<Message> helper;
    private MessagesList messagesList;

  @Resource(name="jdbcUrl")
  private String jdbcUrl;

  @Resource(name="username")
  private String username;

  @Resource(name="password")
  private String password;

  public MessageDAO(){
    messagesList = new MessagesList();
  }

  private DatabaseHelper<Message> helper(){
    if(helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  private static Message createMessage(String body, String name, int id){
    Message message = new Message();
    message.setId(id);
    message.setBody(body);
    message.setName(name);
    return message;
  }

  public Message create(Message message){
    helper().executeUpdate("INSERT INTO message_table(name, body) VALUES (?, ?)",message.getName(), message.getBody());
    return createMessage(message.getBody(), message.getName(), message.getId());
  }

  private static class MessageMapper implements DataMapper<Message>
  {
    public Message create(ResultSet rs) throws SQLException
    {
      int id = rs.getInt("id");
      String name = rs.getString("name");
      String body = rs.getString("body");

      return createMessage(body, name, id);
    }
  }

    public MessagesList readAll(){
    messagesList.getMessages().clear();
      messagesList.getMessages().addAll( helper().map(new MessageMapper(), "SELECT * FROM message_table"));
    return messagesList;
    }

    public void delete(int id){
      helper().executeUpdate("DELETE FROM message_table WHERE id = ?", id);
    }

    public Message get(int id){
    Message message = helper().mapSingle(new MessageMapper(),"SELECT * FROM message_table WHERE id = ?", id);
         return message;
    }

    public void patch(Message message){
    helper().executeUpdate("UPDATE message_table SET name = ?, body = ? WHERE id = ?", message.getName(), message.getBody(), message.getId());
    }


}
