package dk.bookAndPlay.webService;

import dk.bookAndPlay.DAO.oneTimeFees.OneTimeFeeDAO;
import dk.bookAndPlay.DAO.oneTimeFees.OneTimeFees;
import dk.bookAndPlay.DAO.organizers.OrganizerDAO;
import dk.bookAndPlay.DAO.organizers.Organizers;
import dk.bookAndPlay.DAO.eventGameLists.EventGameListDAO;
import dk.bookAndPlay.DAO.eventGameLists.EventGameLists;
import dk.bookAndPlay.DAO.category.Categories;
import dk.bookAndPlay.DAO.category.CategoryDAO;
import dk.bookAndPlay.DAO.events.EventDAO;
import dk.bookAndPlay.DAO.events.Events;
import dk.bookAndPlay.DAO.monthlyFees.MonthlyFeeDAO;
import dk.bookAndPlay.DAO.monthlyFees.MonthlyFees;
import dk.bookAndPlay.DAO.gameLists.GameListDAO;
import dk.bookAndPlay.DAO.gameLists.GameLists;
import dk.bookAndPlay.DAO.games.GameDAO;
import dk.bookAndPlay.DAO.games.Games;
import dk.bookAndPlay.DAO.participants.ParticipantDAO;
import dk.bookAndPlay.DAO.participants.Participants;
import dk.bookAndPlay.DAO.users.UserDAO;
import dk.bookAndPlay.DAO.users.Users;
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
    public GameLists GameLists(){return new GameListDAO();}

    @Bean
    @Scope("singleton")
    public MonthlyFees MonthlyFeeDAO(){ return new MonthlyFeeDAO();
    }

    @Bean
    @Scope("singleton")
    public OneTimeFees OneTimeFeeDAO(){return new OneTimeFeeDAO();
    }

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
