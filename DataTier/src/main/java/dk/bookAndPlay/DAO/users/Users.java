package dk.bookAndPlay.DAO.users;

import dk.bookandplay.web_service.Filter;
import dk.bookandplay.web_service.User;
import dk.bookandplay.web_service.UserList;

public interface Users {
    User create(User user);

    User get(String username);
    void update(User user);
    void delete(String username);

    UserList getUserlist();
    UserList getUserList(Filter filter);
}
