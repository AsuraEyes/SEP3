package com.example.producingwebservice.users;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import com.example.producingwebservice.games.GameDAO;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.User;
import io.spring.guides.gs_producing_web_service.UserList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

public class UserDAO implements Users
{
    private DatabaseHelper<User> helper;
    private UserList userList;

    @Resource(name="jdbcUrl")
    private String jdbcUrl;

    @Resource(name="username")
    private String username;

    @Resource(name="password")
    private String password;

  public UserDAO(){
    userList = new UserList();
  }

    private DatabaseHelper<User> helper(){
    if(helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  private static User createUser(String username, String password, String firstName, String lastName, int roleId,
      String phoneCountryCode, String phoneNumber, String emailAddress, boolean requestedPromotion){
    User user = new User();
    user.setUsername(username);
    user.setPassword(password);
    user.setFirstName(firstName);
    user.setLastName(lastName);
    user.setRole(roleId);
    user.setPhoneCountryCode(phoneCountryCode);
    user.setPhoneNumber(phoneNumber);
    user.setEmailAddress(emailAddress);
    user.setRequestedPromotion(requestedPromotion);

    return user;
  }

  public User create(User user){
    helper().executeUpdate(
        "INSERT INTO \"user\" VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)", user.getUsername(), user.getPassword(),
        user.getFirstName(), user.getLastName(), user.getRole(), user.getPhoneCountryCode(), user.getPhoneNumber(),
        user.getEmailAddress(), user.isRequestedPromotion());
    return user;
  }

  public User get(String username)
  {
    User user = helper().mapSingle(new UserMapper(),"SELECT * FROM \"user\" WHERE username = ?", username);
    System.out.println(user.getUsername());
    System.out.println(user.getRole());
    return user;
  }


  private static class UserMapper implements DataMapper<User>
  {
    public User create(ResultSet rs) throws SQLException
    {
      String username = rs.getString("username");
      String password = rs.getString("password");
      String firstName = rs.getString("first_name");
      String lastName = rs.getString("last_name");
      int roleId = rs.getInt("role_id");
      String phoneCountryCode = rs.getString("phone_country_code");
      String phoneNumber = rs.getString("phone_number");
      String emailAddress = rs.getString("email_address");
      boolean requestedPromotion = rs.getBoolean("requested_promotion");

      return createUser(username, password, firstName, lastName, roleId,  phoneCountryCode, phoneNumber, emailAddress, requestedPromotion);
    }
  }
}
