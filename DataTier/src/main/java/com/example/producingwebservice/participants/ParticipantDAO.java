package com.example.producingwebservice.participants;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import com.example.producingwebservice.organizers.OrganizerDAO;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class ParticipantDAO implements Participants
{
  private DatabaseHelper<String> helper;
  private final ArrayList<String> participantList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public ParticipantDAO() {
    participantList = new ArrayList<>();
  }

  private static String createParticipant(String username) {
    return username;
  }

  private DatabaseHelper<String> helper() {
    if (helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  private static class ParticipantMapper implements DataMapper<String>
  {
    public String create(ResultSet rs) throws SQLException
    {
      String username = rs.getString("user_username");
      return createParticipant(username);
    }
  }

  public void join (int eventId, String username){
    helper().executeUpdate("INSERT INTO participants(event_id, user_username) VALUES (?, ?)", eventId, username);
  }

  public void withdraw (int eventId, String username){
    helper().executeUpdate("DELETE FROM participants WHERE event_id = ? AND user_username = ?", eventId, username);
    helper().executeUpdate("DELETE FROM organizers WHERE event_id = ? AND user_username = ?", eventId, username);
  }

  public ArrayList<String> getParticipantList(int eventId){
    participantList.clear();
    participantList.addAll(helper().map(new ParticipantMapper(), "SELECT user_username FROM participants WHERE event_id = ?", eventId));
    return participantList;
  }
}
