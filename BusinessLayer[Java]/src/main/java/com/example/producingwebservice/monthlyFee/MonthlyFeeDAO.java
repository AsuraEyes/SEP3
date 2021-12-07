package com.example.producingwebservice.monthlyFee;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.MonthlyFee;

import javax.annotation.Resource;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

public class MonthlyFeeDAO implements MonthlyFees
{
  private DatabaseHelper<MonthlyFee> helper;
  private final List<MonthlyFee> monthlyFeeList;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public MonthlyFeeDAO() {
    monthlyFeeList = new ArrayList<>();
  }

  private static MonthlyFee createMonthlyFee(int id, int amount, Date startDate, Date endDate, String username) {

    MonthlyFee monthlyFee = new MonthlyFee();

    monthlyFee.setId(id);
    monthlyFee.setAmount(amount);

    GregorianCalendar c = new GregorianCalendar();

    try{
      c.setTime(startDate);
      XMLGregorianCalendar start = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
      monthlyFee.setStartDate(start);

      c.clear();
      c.setTime(endDate);
      XMLGregorianCalendar end = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
      monthlyFee.setEndDate(end);
      }
    catch (DatatypeConfigurationException ignored)
    {}

    monthlyFee.setUserUsername(username);

    return monthlyFee;
  }

  private DatabaseHelper<MonthlyFee> helper() {
    if (helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  public MonthlyFee create(MonthlyFee monthlyFee) throws ParseException
  {

    java.util.Date st = monthlyFee.getStartDate().toGregorianCalendar().getTime();
    java.sql.Date sqlSt = new java.sql.Date(st.getTime());

    java.util.Date et = monthlyFee.getEndDate().toGregorianCalendar().getTime();
    java.sql.Date sqlEt = new java.sql.Date(et.getTime());


    helper().executeUpdate("INSERT INTO monthly_fee(amount, start_date, end_date, user_username) VALUES (?,?,?,?)", monthlyFee.getAmount(),
        sqlSt, sqlEt, monthlyFee.getUserUsername());

    return monthlyFee;
  }

  public MonthlyFee getMonthlyFee(String username){
    return helper().mapSingle(new MonthlyFeeMapper(),"SELECT * FROM monthly_fee WHERE user_username = ? ORDER BY id DESC LIMIT 1", username);
  }

  public List<MonthlyFee> getMonthlyFeeList(String username){
    monthlyFeeList.clear();
    monthlyFeeList.addAll(helper().map(new MonthlyFeeMapper(),"SELECT * FROM monthly_fee WHERE user_username = ?", username));
    return monthlyFeeList;
  }

  public void updateMonthlyFee(MonthlyFee monthlyFee){
    java.util.Date st = monthlyFee.getStartDate().toGregorianCalendar().getTime();
    java.sql.Date sqlSt = new java.sql.Date(st.getTime());

    java.util.Date et = monthlyFee.getEndDate().toGregorianCalendar().getTime();
    java.sql.Date sqlEt = new java.sql.Date(et.getTime());


    helper().executeUpdate("UPDATE monthly_fee SET amount = ?, end_date = ?  WHERE id = ?", monthlyFee.getAmount(),
       sqlEt, monthlyFee.getId());
  }

  private static class MonthlyFeeMapper implements DataMapper<MonthlyFee>
  {
    public MonthlyFee create(ResultSet rs) throws SQLException
    {
      int id = rs.getInt("id");
      int amount = rs.getInt("amount");
      Date startDate = rs.getDate("start_date");
      Date endDate = rs.getDate("end_date");
      String username = rs.getString("user_username");

      return createMonthlyFee(id, amount, startDate, endDate, username);
    }
  }
}
