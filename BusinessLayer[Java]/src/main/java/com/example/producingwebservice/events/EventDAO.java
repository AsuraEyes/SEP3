package com.example.producingwebservice.events;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.*;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;

public class EventDAO implements Events {
    private DatabaseHelper<Event> helper;
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

    private static Event createEvent(int id, String name, String addressStreetName,
                                     String addressStreetNumber, String addressApartmentNumber, int maxNumberOfParticipants,
                                     int numberOfParticipants, String eventCategory, User organizer, UserList participants,
                                     UserList organizers, EventGameList gameList) {
        Event event = new Event();
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

    public EventList readByDate() {
        eventList.getEventList().clear();
        eventList.getEventList().addAll(helper.map(new EventMapper(), ""));
        return eventList;
    }

    public EventList readByCategory() {
        eventList.getEventList().clear();
        eventList.getEventList().addAll(helper.map(new EventMapper(), ""));
        return eventList;
    }

    private static class EventMapper implements DataMapper<Event> {
        public Event create(ResultSet rs) throws SQLException {
            return null;
        }
    }
}
