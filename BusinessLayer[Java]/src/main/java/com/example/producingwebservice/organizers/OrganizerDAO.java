package com.example.producingwebservice.organizers;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;
import io.spring.guides.gs_producing_web_service.User;
import io.spring.guides.gs_producing_web_service.UserList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class OrganizerDAO implements Organizers
{
  private DatabaseHelper<String> helper;
  private final ArrayList<String> organizerList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public OrganizerDAO() {
    organizerList = new ArrayList<>();
  }

  private static String createOrganizer(String username) {
    return username;
  }

  private DatabaseHelper<String> helper() {
    if (helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  private static class OrganizerMapper implements DataMapper<String>
  {
    public String create(ResultSet rs) throws SQLException
    {
      String username = rs.getString("user_username");
      return createOrganizer(username);
    }
  }

  public void organize (int eventId, String username){
    helper().executeUpdate("INSERT INTO organizers(event_id, user_username) VALUES (?, ?)", eventId, username);
  }

  public void withdraw (int eventId, String username){
    helper().executeUpdate("DELETE FROM organizers WHERE event_id = ? AND user_username = ?", eventId, username);
  }

  public ArrayList<String> getOrganizerList(int eventId){
    organizerList.clear();
    organizerList.addAll(helper().map(new OrganizerMapper(), "SELECT user_username FROM organizers WHERE event_id = ?", eventId));
    return organizerList;
  }
}
