package com.example.producingwebservice.events;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Event;
import io.spring.guides.gs_producing_web_service.EventList;
import io.spring.guides.gs_producing_web_service.Filter;

import javax.annotation.Resource;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.Date;
import java.util.GregorianCalendar;

public class EventDAO implements Events {
    private DatabaseHelper<Event> eventHelper;
    private DatabaseHelper<Integer> integerHelper;
    private final EventList eventList;

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
                                     int numberOfParticipants, int eventCategory, String organizer)


    {
        Event event = new Event();

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
            event.setEndTime(end);
          }
        }
        catch (DatatypeConfigurationException ignored){}

        event.setId(id);
        event.setName(name);
        event.setAddressStreetName(addressStreetName);
        event.setAddressStreetNumber(addressStreetNumber);
        event.setAddressApartmentNumber(addressApartmentNumber);
        event.setMaxNumberOfParticipants(maxNumberOfParticipants);
        event.setNumberOfParticipants(numberOfParticipants);
        event.setEventCategory(eventCategory);
        event.setOrganizer(organizer);
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

  public Event get(int id) {
    return eventHelper().mapSingle(new EventMapper(), "SELECT * FROM event WHERE id = ?", id);
  }

  public EventList getOrganizersEvents(String username) {
      eventList.getEventList().clear();
      eventList.getEventList().addAll(eventHelper().map(new EventMapper(), "SELECT * FROM event WHERE organizer = ?", username));
      return eventList;
    }

    public EventList getCoOrganizersEvents(String username) {
        eventList.getEventList().clear();
        eventList.getEventList().addAll(eventHelper().map(new EventMapper(),
                "SELECT e.* FROM event e, organizers o WHERE o.user_username != e.organizer AND e.id = o.event_id AND o.user_username = ?",
                username));
        return eventList;
    }

  public EventList getParticipantsEvents(String username) {
      eventList.getEventList().clear();
      eventList.getEventList().addAll(eventHelper().map(new EventMapper(),
              "SELECT * FROM event WHERE event.id IN (SELECT event_id FROM participants WHERE user_username = ?) AND event.id NOT IN (SELECT event_id FROM organizers WHERE user_username = ?)",
              username, username));
      return eventList;
  }

  public EventList searchAndFilter(Filter filter){
        eventList.getEventList().clear();
        EventList pagedEventList = new EventList();
        int eventListLength;

        String statement = "SELECT COUNT(*) FROM event ";
        String appendToStatement = "";
        if(!filter.getFilter().equals("all")){
            appendToStatement += " WHERE ";
          if(filter.getFilter().contains("byDate"))
          {
              appendToStatement +="start_time > now() AND";
          }
          if(filter.getFilter().contains("byCategory"))
          {
              appendToStatement +=" event_category_id = " + filter.getCategoryId()+ " AND";
          }
          if(filter.getFilter().contains("byAvailability"))
          {
              appendToStatement +=" number_of_participants < max_number_of_participants AND";
          }
          if(appendToStatement.endsWith("AND"))
          {
              appendToStatement = appendToStatement.substring(0, appendToStatement.length() - 4);
              appendToStatement +=";";
          }
        }
        else{
            appendToStatement +=";";
        }

        System.out.println(statement+appendToStatement);

        eventListLength = (integerHelper().mapSingle(new IntegerMapper(), statement+appendToStatement));

        statement = "SELECT * FROM event "+appendToStatement.substring(0, appendToStatement.length()-1);

        statement += " ORDER by id LIMIT "+filter.getLimit()+" OFFSET "+filter.getOffset()+";";

        pagedEventList.getEventList().addAll(eventHelper().map(new EventMapper(), statement));
        pagedEventList.setCount((int)Math.ceil(eventListLength/ (float)filter.getLimit()));

        System.out.println(statement);

        return pagedEventList;
    }

    private static class IntegerMapper implements DataMapper<Integer> {
        public Integer create(ResultSet rs)
                throws SQLException {
            return rs.getInt("count");
        }
    }

    public void cancel(int id) {
        eventHelper().executeUpdate("DELETE FROM event WHERE id = ?", id);
    }

    public void edit(Event event) {
        Timestamp startTime = new Timestamp(event.getStartTime().toGregorianCalendar().getTimeInMillis());
        Timestamp endTime = new Timestamp(event.getEndTime().toGregorianCalendar().getTimeInMillis());

        eventHelper().executeUpdate(
                "UPDATE event SET name = ?, start_time = ?, end_time = ?, address_street_name = ?, address_street_number = ?, address_apartment_number = ? WHERE id = ?",
                event.getName(), startTime, endTime, event.getAddressStreetName(), event.getAddressStreetNumber(),
                event.getAddressApartmentNumber(), event.getId());
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


            return createEvent(id, name, startTime,endTime,addressStreetName,
               addressStreetNumber, addressApartmentNumber,maxNumberOfParticipants,
          numberOfParticipants,eventCategory, organizer);
        }
    }
}
