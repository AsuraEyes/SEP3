package dk.bookAndPlay.webService;

import dk.bookAndPlay.OneTimeFee.OneTimeFeeDAO;
import dk.bookAndPlay.OneTimeFee.OneTimeFees;
import dk.bookAndPlay.organizers.OrganizerDAO;
import dk.bookAndPlay.organizers.Organizers;
import dk.bookAndPlay.EventGameList.EventGameListDAO;
import dk.bookAndPlay.EventGameList.EventGameLists;
import dk.bookAndPlay.categories.Categories;
import dk.bookAndPlay.categories.CategoryDAO;
import dk.bookAndPlay.events.EventDAO;
import dk.bookAndPlay.events.Events;
import dk.bookAndPlay.monthlyFee.MonthlyFeeDAO;
import dk.bookAndPlay.monthlyFee.MonthlyFees;
import dk.bookAndPlay.gameList.GameListDAO;
import dk.bookAndPlay.gameList.GameLists;
import dk.bookAndPlay.games.GameDAO;
import dk.bookAndPlay.games.Games;
import dk.bookAndPlay.participants.ParticipantDAO;
import dk.bookAndPlay.participants.Participants;
import dk.bookAndPlay.users.UserDAO;
import dk.bookAndPlay.users.Users;
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
