package com.example.producingwebservice.events;

import io.spring.guides.gs_producing_web_service.EventList;

public interface Events {
    EventList readByDate();

    EventList readByCategory();
}
