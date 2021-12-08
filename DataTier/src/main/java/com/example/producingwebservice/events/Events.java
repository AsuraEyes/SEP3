package com.example.producingwebservice.events;

import io.spring.guides.gs_producing_web_service.Event;
import io.spring.guides.gs_producing_web_service.EventList;
import io.spring.guides.gs_producing_web_service.Filter;

public interface Events {
    EventList searchAndFilter(Filter filter);
    Event create(Event event);
    Event get(int id);
    void cancel(int id);
    void edit(Event event);
    EventList getOrganizersEvents(String username);
    EventList getCoOrganizersEvents(String username);
    EventList getParticipantsEvents(String username);
}
