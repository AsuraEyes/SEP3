package com.example.producingwebservice.events;

import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Event;
import io.spring.guides.gs_producing_web_service.EventList;

import javax.annotation.Resource;

public class EventDAO implements Events{
    private DatabaseHelper<Event> helper;
    private EventList eventList;

    @Resource(name="jdbcUrl")
    private String jdbcUrl;

    @Resource(name="username")
    private String username;

    @Resource(name="password")
    private String password;

    public EventDAO() {
        eventList = new EventList();
    }

    @Override
    public EventList readByDate() {
        eventList.getEventList().clear();
        return eventList;
    }

    @Override
    public EventList readByCategory() {
        eventList.getEventList().clear();
        return eventList;
    }
}
