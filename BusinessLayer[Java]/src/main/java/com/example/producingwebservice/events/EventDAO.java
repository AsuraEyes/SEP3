package com.example.producingwebservice.events;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import com.example.producingwebservice.games.GameDAO;
import io.spring.guides.gs_producing_web_service.*;

import javax.annotation.Resource;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.time.Instant;
import java.util.Date;
import java.util.GregorianCalendar;

public class EventDAO implements Events {
  private DatabaseHelper<Event> eventHelper;
  private DatabaseHelper<Integer> integerHelper;
  private final EventList eventList;
  private int eventListLength;
  private GameDAO gameDAO;

  @Resource(name = "jdbcUrl")
  private String jdbcUrl;

  @Resource(name = "username")
  private String username;

  @Resource(name = "password")
  private String password;

  public EventDAO() {
    eventList = new EventList();
  }
  private DatabaseHelper<Event> eventHelper(){
    if(eventHelper == null)
      eventHelper = new DatabaseHelper<>(jdbcUrl, username, password);
    return eventHelper;
  }
  private DatabaseHelper<Integer> integerHelper(){
    if(integerHelper == null)
      integerHelper = new DatabaseHelper<>(jdbcUrl, username, password);
    return integerHelper;
  }

  private static Event createEvent(int id, String name, Date startTimeStamp, Date endTimeStamp,String addressStreetName,
      String addressStreetNumber, String addressApartmentNumber, int maxNumberOfParticipants,
      int numberOfParticipants, int eventCategory, String organizer, UserList participants,
      UserList organizers, EventGameList gameList)


  {
    Event event = new Event();

    //Date to XMLGregorianCalendar conversion
    GregorianCalendar c = new GregorianCalendar();

    try{
      c.setTime(startTimeStamp);
      XMLGregorianCalendar start = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
      event.setStartTime(start);

      if(endTimeStamp != null)
      {
        c.clear();
        c.setTime(endTimeStamp);
        XMLGregorianCalendar end = DatatypeFactory.newInstance().newXMLGregorianCalendar(c);
        event.setEndTime(end); // set the event end time
      }
    }
    catch (DatatypeConfigurationException e){}

    event.setId(id);
    event.setName(name);
    event.setAddressStreetName(addressStreetName);
    event.setAddressStreetNumber(addressStreetNumber);
    event.setAddressApartmentNumber(addressApartmentNumber);
    event.setMaxNumberOfParticipants(maxNumberOfParticipants);
    event.setNumberOfParticipants(numberOfParticipants);
    event.setEventCategory(eventCategory);
    event.setOrganizer(organizer);
    event.setParticipants(participants);
    event.setOrganizers(organizers);
    event.setGameList(gameList);
    return event;
  }

  public Event create(Event event){
    Timestamp startTime = new Timestamp(event.getStartTime().toGregorianCalendar().getTimeInMillis());
    Timestamp endTime = new Timestamp(event.getEndTime().toGregorianCalendar().getTimeInMillis());

    eventHelper().executeUpdate(
        "INSERT INTO event(name, start_time, end_time, address_street_name, address_street_number, address_apartment_number, max_number_of_participants, event_category_id, organizer) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)",
        event.getName(), startTime, endTime, event.getAddressStreetName(), event.getAddressStreetNumber(),
        event.getAddressApartmentNumber(), event.getMaxNumberOfParticipants(), event.getEventCategory(),
        event.getOrganizer());
    return event;
  }

  public EventList searchAndFilter(String filter, int category, int currentPage, int resultsPerPage){
    eventList.getEventList().clear();
    EventList pagedEventList = new EventList();
    String statement = "SELECT COUNT(*) FROM event";

    String appendToStatement = "";
    if(!filter.equals("all")){
      appendToStatement += " WHERE ";
      if(filter.contains("byDate"))
      {
        appendToStatement +="start_time > now() AND";
      }
      if(filter.contains("byCategory"))
      {
        appendToStatement +=" event_category_id = " + category+ " AND";
      }
      if(filter.contains("byAvailability"))
      {
        appendToStatement +=" number_of_participants < max_number_of_participants AND";
      }
      if(appendToStatement.endsWith("AND"))
      {
        appendToStatement = statement.substring(0, statement.length() - 4);
        //appendToStatement +=" GROUP BY id ORDER BY id;";
        appendToStatement +=";";
      }
    }
    else{
      // appendToStatement +=" GROUP BY id ORDER BY id;";
      appendToStatement +=";";
    }

    System.out.println(statement+appendToStatement);

    //eventList.getEventList().addAll(helper().map(new EventMapper(), statement+appendToStatement));
    eventListLength = (integerHelper().mapSingle(new IntegerMapper(), statement+appendToStatement));
    System.out.println(eventListLength);

    //cut out the ; in the end, change count to select
    statement = "SELECT * FROM event"+appendToStatement.substring(0, appendToStatement.length()-1);
    //add pagination
    statement += " LIMIT "+resultsPerPage+" OFFSET "+(currentPage-1)*resultsPerPage+";";
    System.out.println(statement);
    pagedEventList.getEventList().addAll(eventHelper().map(new EventMapper(), statement));

    System.out.println(statement);

    return pagedEventList;
  }

  public int getNumberOfPages(int resultsPerPage){
    //return (int) Math.ceil(eventList.getEventList().size() / (float)resultsPerPage);
    return (int) Math.ceil(eventListLength/ (float)resultsPerPage);
  }

  private static class IntegerMapper implements DataMapper<Integer> {
    public Integer create(ResultSet rs)
        throws SQLException {
      return rs.getInt("count");
    }
  }

  private static class EventMapper implements DataMapper<Event> {
    public Event create(ResultSet rs)
        throws SQLException
    {
      int id = rs.getInt("id");
      String name = rs.getString("name");
      Date startTime = rs.getTimestamp("start_time");
      Date endTime = rs.getTimestamp("end_time");
      String addressStreetName = rs.getString("address_street_name");
      String addressStreetNumber = rs.getString("address_street_number");
      String addressApartmentNumber = rs.getString("address_apartment_number");
      int maxNumberOfParticipants = rs.getInt("max_number_of_participants");
      int numberOfParticipants = rs.getInt("number_of_participants");
      int eventCategory = rs.getInt("event_category_id");
      String organizer =  rs.getString("organizer");
      //User organizer;
      UserList participants;
      UserList organizers;
      EventGameList gameList;

      return createEvent(id, name, startTime,endTime,addressStreetName,
          addressStreetNumber, addressApartmentNumber,maxNumberOfParticipants,
          numberOfParticipants,eventCategory, null,null,
          null, null);
    }
  }
}