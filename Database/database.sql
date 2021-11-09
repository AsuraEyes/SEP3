DROP SCHEMA IF EXISTS  book_and_play CASCADE ;
CREATE SCHEMA book_and_play;
SET SCHEMA 'book_and_play';

DROP DOMAIN IF EXISTS one_two_three_type CASCADE;
CREATE DOMAIN one_two_three_type INTEGER NOT NULL CHECK (value IN (1, 2, 3));

DROP TABLE IF EXISTS role;
CREATE TABLE role(
    id SERIAL PRIMARY KEY,
    name VARCHAR (100) NOT NULL
);

DROP TABLE IF EXISTS phone;
CREATE TABLE phone(
    country_code VARCHAR(10),
    number VARCHAR (20),
    PRIMARY KEY (country_code, number)
);

DROP TABLE IF EXISTS "user";
CREATE TABLE "user"(
    username VARCHAR (255) PRIMARY KEY,
    password VARCHAR (255) NOT NULL,
    first_name VARCHAR (255),
    last_name VARCHAR (255),
    role_id INTEGER NOT NULL,
    phone_country_code VARCHAR (10),
    phone_number VARCHAR (20),
    email_address VARCHAR (255),
    FOREIGN KEY (role_id) REFERENCES role (id) ON UPDATE CASCADE,
    FOREIGN KEY (phone_country_code, phone_number) REFERENCES phone (country_code, number)  ON UPDATE CASCADE
);

DROP TABLE IF EXISTS event_category;
CREATE TABLE event_category(
    id SERIAL PRIMARY KEY,
    name VARCHAR (100)
);

DROP TABLE IF EXISTS event;
CREATE TABLE event(
    id SERIAL PRIMARY KEY,
    name VARCHAR (255) NOT NULL,
    start_time DATE NOT NULL,
    end_time DATE,
    address_street_name VARCHAR (255) NOT NULL,
    address_street_number VARCHAR (20) NOT NULL,
    address_apartment_number VARCHAR (20),
    max_number_of_participants INTEGER NOT NULL,
    event_category_id INTEGER NOT NULL,
    organizer VARCHAR (255) NOT NULL,
    FOREIGN KEY (event_category_id) REFERENCES event_category(id),
    FOREIGN KEY (organizer) REFERENCES "user"(username) ON DELETE CASCADE
);

DROP TABLE IF EXISTS monthly_fee;
CREATE TABLE monthly_fee(
    id SERIAL PRIMARY KEY,
    amount INTEGER NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE
);

DROP TABLE IF EXISTS one_time_fee;
CREATE TABLE one_time_fee(
    id SERIAL PRIMARY KEY,
    amount INTEGER NOT NULL,
    event_id INTEGER NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES event (id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS organizers;
CREATE TABLE organizers(
    event_id INTEGER NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    PRIMARY KEY (event_id, user_username),
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES event (id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS participants;
CREATE TABLE participants(
    event_id INTEGER NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    PRIMARY KEY (event_id, user_username),
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES event (id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS game;
CREATE TABLE game(
    id SERIAL PRIMARY KEY,
    name VARCHAR (255) NOT NULL,
    complexity one_two_three_type,
    time_estimation one_two_three_type,
    min_number_of_players INTEGER NOT NULL,
    max_number_of_players INTEGER NOT NULL,
    short_description VARCHAR (10000),
    needed_equipment VARCHAR (10000),
    min_age INTEGER,
    max_age INTEGER,
    tutorial VARCHAR (10000),
    approved BOOLEAN DEFAULT FALSE NOT NULL
);

DROP TABLE IF EXISTS game_list;
CREATE TABLE game_list(
    game_id INTEGER NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    PRIMARY KEY (game_id, user_username),
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE,
    FOREIGN KEY (game_id) REFERENCES game (id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS event_game_list;
CREATE TABLE event_game_list(
    game_id INTEGER NOT NULL,
    user_username VARCHAR (255) NOT NULL,
    event_id INTEGER NOT NULL,
    PRIMARY KEY (game_id, user_username, event_id),
    FOREIGN KEY (user_username) REFERENCES "user"(username) ON DELETE CASCADE,
    FOREIGN KEY (game_id) REFERENCES game (id) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES event (id) ON DELETE CASCADE
);