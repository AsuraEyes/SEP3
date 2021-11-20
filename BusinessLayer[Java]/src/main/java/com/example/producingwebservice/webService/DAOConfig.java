package com.example.producingwebservice.webService;

import com.example.producingwebservice.events.EventDAO;
import com.example.producingwebservice.events.Events;
import com.example.producingwebservice.games.GameDAO;
import com.example.producingwebservice.games.Games;
import com.example.producingwebservice.users.UserDAO;
import com.example.producingwebservice.users.Users;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;

@Configuration
public class DAOConfig
{
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

    @Bean(name="jdbcUrl")
    public String jdbcUrl() {
        return "jdbc:postgresql://localhost:5432/postgres?currentSchema=book_and_play";
    }

    @Bean(name="username")
    public String username() {
        return "postgres";
    }

    @Bean(name="password")
    public String password() {
        return "SQLdatabaze";
    }
}
