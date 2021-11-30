package com.example.producingwebservice.webService;

import com.example.producingwebservice.EventGameList.EventGameListDAO;
import com.example.producingwebservice.EventGameList.EventGameLists;
import com.example.producingwebservice.categories.Categories;
import com.example.producingwebservice.categories.CategoryDAO;
import com.example.producingwebservice.events.EventDAO;
import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.gameList.GameListDAO;
import com.example.producingwebservice.gameList.GameLists;
import com.example.producingwebservice.games.GameDAO;
import com.example.producingwebservice.games.Games;
import com.example.producingwebservice.organizers.OrganizerDAO;
import com.example.producingwebservice.organizers.Organizers;
import com.example.producingwebservice.participants.ParticipantDAO;
import com.example.producingwebservice.participants.Participants;
import com.example.producingwebservice.users.UserDAO;
import com.example.producingwebservice.users.Users;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;

@Configuration
public class DAOConfig {
    @Bean
    @Scope("singleton")
    public Games GameDAO() {
        return new GameDAO();
    }

    @Bean
    @Scope("singleton")
    public Events EventDAO() {
        return new EventDAO();
    }

    @Bean
    @Scope("singleton")
    public Users UserDAO() {
        return new UserDAO();
    }

    @Bean
    @Scope("singleton")
    public Categories CategoryDAO() {
        return new CategoryDAO();
    }

    @Bean
    @Scope("singleton")
    public Participants ParticipantDAO() {
        return new ParticipantDAO();
    }

    @Bean
    @Scope("singleton")
    public Organizers OrganizerDAO() {
        return new OrganizerDAO();
    }

    @Bean
    @Scope("singleton")
    public EventGameLists EventGameListDAO() {
        return new EventGameListDAO();
    }

    @Bean
    @Scope("singleton")
    public GameLists gameLists(){return new GameListDAO();}

    @Bean(name = "jdbcUrl")
    public String jdbcUrl() {
        return "jdbc:postgresql://localhost:5432/postgres?currentSchema=book_and_play";
    }

    @Bean(name = "username")
    public String username() {
        return "postgres";
    }

    @Bean(name = "password")
    public String password() {
        return "CoDex21";
    }
}
