package com.example.producingwebservice.users;

import io.spring.guides.gs_producing_web_service.Filter;
import io.spring.guides.gs_producing_web_service.User;
import io.spring.guides.gs_producing_web_service.UserList;

public interface Users {
    User create(User user);

    User get(String username);
    void update(User user);
    void delete(String username);

    UserList getUserlist();
    UserList getUserList(Filter filter);
}
