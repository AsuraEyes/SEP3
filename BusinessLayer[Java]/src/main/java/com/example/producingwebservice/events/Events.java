package com.example.producingwebservice.events;

import io.spring.guides.gs_producing_web_service.Event;
import io.spring.guides.gs_producing_web_service.EventList;

public interface Events {
    EventList searchAndFilter(String search, int category, int currentPage, int resultsPerPage);
    int getNumberOfPages(int resultsPerPage);

    Event create(Event event);
}
