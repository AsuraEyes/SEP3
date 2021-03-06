package dk.bookAndPlay.DAO.oneTimeFees;

import dk.bookAndPlay.db.DataMapper;
import dk.bookAndPlay.db.DatabaseHelper;
import dk.bookandplay.web_service.OneTimeFee;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class OneTimeFeeDAO implements OneTimeFees
{
  private DatabaseHelper<OneTimeFee> helper;
  private final List<OneTimeFee> oneTimeFeeList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public OneTimeFeeDAO() {
      oneTimeFeeList = new ArrayList<>();
  }

  private static OneTimeFee createOneTimeFee(int id, int amount, int eventId, String username) {

    OneTimeFee oneTimeFee = new OneTimeFee();

    oneTimeFee.setId(id);
    oneTimeFee.setAmount(amount);
    oneTimeFee.setEventId(eventId);
    oneTimeFee.setUserUsername(username);

    return oneTimeFee;
  }

  private DatabaseHelper<OneTimeFee> helper() {
    if (helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  public OneTimeFee create(OneTimeFee oneTimeFee) {
    helper().executeUpdate("INSERT INTO one_time_fee(amount, event_id, user_username) VALUES (?,?,?)", oneTimeFee.getAmount(),
       oneTimeFee.getEventId(), oneTimeFee.getUserUsername());
    return oneTimeFee;
  }

  public OneTimeFee getOneTimeFee(String username, int eventId){
    return helper().mapSingle(new OneTimeFeeMapper(),"SELECT * FROM one_time_fee WHERE user_username = ? AND event_id = ?", username, eventId);
  }

  public List<OneTimeFee> getOneTimeFeeList(String username){
    oneTimeFeeList.clear();
    oneTimeFeeList.addAll(helper().map(new OneTimeFeeMapper(),"SELECT * FROM one_time_fee WHERE user_username = ?", username));
    return oneTimeFeeList;
  }

  private static class OneTimeFeeMapper implements DataMapper<OneTimeFee>
  {
    public OneTimeFee create(ResultSet rs) throws SQLException
    {
      int id = rs.getInt("id");
      int amount = rs.getInt("amount");
      int eventId = rs.getInt("event_id");
      String username = rs.getString("user_username");

      return createOneTimeFee(id, amount, eventId, username);
    }
  }
}
