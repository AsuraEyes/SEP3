SET SCHEMA 'book_and_play';

INSERT INTO event_category(name)
VALUES ('Children'),
       ('Adults'),
       ('Family');

INSERT INTO role(name)
VALUES ('Administrator'),
       ('Player'),
       ('Organizer');

INSERT INTO "user" (username, password, first_name, last_name, role_id, phone_country_code, phone_number, email_address, requested_promotion)
VALUES ('boardgameGeek', '123', null, null, 3, '+45', '12 34 56 78', 'geek@email.com', false),
       ('cookie', 'chocolateChip', null, null, 2, null, null, null, false),
       ('carrot', 'healthy', null, null, 2, null, null, null, true),
       ('bobo', 'strong', 'Bob', 'Bobson', 3, '+01', '87 65 20 98', null, false),
       ('troll', 'no_need', 'Troels', 'Andersen', 2, '+420', '368_286_976', 'cool.address@gmail.com', false),
       ('tinky_winky_69', 'teletubbies', 'Tinky', 'Winky', 2, null, null, null, true),
       ('dipsy_85', 'teletubbies', null, null, 2, null, null, null, false),
       ('LaLa', 'teletubbies', null, null, 2, null, '98 76 43 87', null, true),
       ('Poh_sweet', 'teletubbies', null, null, 2, null, '87 88 65 32', null, false),
       ('Dipsy', 'bla', 'Daisy', 'Blue', 3, null, '76 54 55 90', null, false),
       ('admin', '1', null, null, 1, null, null, null, false),
       ('almighty', 'admin', null, null, 1, null, null, null, false);

INSERT INTO monthly_fee(amount, start_date, end_date, user_username)
VALUES (120, '2020-10-14', '2020-11-14', 'boardgameGeek'),
       (120, '2020-04-03', '2020-05-03', 'boardgameGeek'),
       (120, '2020-05-20', '2020-06-21', 'boardgameGeek'),
       (130, '2021-11-15', '2021-12-16', 'boardgameGeek'),
       (130, '2022-01-03', '2022-02-03', 'boardgameGeek'),
       (120, '2020-10-14', '2020-11-14', 'cookie'),
       (120, '2020-09-14', '2020-10-15', 'carrot'),
       (130, '2021-11-10', '2021-12-11', 'Poh_sweet'),
       (130, '2021-10-24', '2021-11-24', 'Dipsy');

INSERT INTO event (name, start_time, end_time, address_street_name, address_street_number, address_apartment_number, max_number_of_participants, event_category_id, organizer)
VALUES ('Friday boardgames', '2021-10-31 18:00:00', null, 'Amaliengade', '16C', '2th', 5, 2, 'boardgameGeek'),
       ('Beer and games', '2021-12-12 20:00:00', null, 'Sundvej', '1', null, 25, 2, 'bobo'),
       ('Christmas special', '2021-12-24 11:00:00', '2021-12-24 19:00:00', 'Sundvej', '4B', null, 5, 2, 'boardgameGeek'),
       ('Happy New Year with boardgames', '2022-01-01 18:00:00', null, 'Langvej', '4C', null, 12, 3, 'bobo'),
       ('Romantic board games', '2022-02-14 11:00:00', '2022-02-24 23:00:00', 'Sundvej', '1', null, 8, 2, 'bobo'),
       ('Cozy afternoon', '2022-02-12 14:00:00', '2022-02-12 18:00:00', 'Nyvej', '8A', '1 tv', 6, 1, 'bobo'),
       ('Chill evening', '2022-01-22 20:00:00', null, 'Emil Mollers Gade', '4', null, 8, 1, 'Dipsy'),
       ('Space mission', '2022-02-28 18:00:00', null, 'Favregade', '6', '1 th', 22, 2, 'Dipsy'),
       ('Card games evening', '2022-01-15 15:30:00', '2022-01-15 20:00:00', 'Skolegade', '16', '2 tv', 10, 3, 'boardgameGeek'),
       ('Cookie day', '2022-01-14 17:15:00', null, 'Hulvej', '13', null, 12, 2, 'boardgameGeek');

INSERT INTO one_time_fee(amount, event_id, user_username)
VALUES (50, 2, 'tinky_winky_69'),
       (50, 2, 'LaLa'),
       (50, 2, 'dipsy_85'),
       (50, 2, 'Poh_sweet'),
       (50, 3, 'LaLa'),
       (50, 4, 'bobo'),
       (50, 4, 'troll'),
       (50, 6, 'carrot');

INSERT INTO organizers(event_id, user_username)
VALUES (2, 'boardgameGeek'),
       (8, 'bobo'),
       (10, 'bobo');

INSERT INTO participants(event_id, user_username)
VALUES (2, 'boardgameGeek'),
       (8, 'bobo'),
       (10, 'bobo'),
       (1, 'Poh_sweet'),
       (4, 'boardgameGeek'),
       (5, 'boardgameGeek'),
       (6, 'boardgameGeek'),
       (7, 'boardgameGeek'),
       (8, 'boardgameGeek'),
       (2, 'cookie'),
       (3, 'cookie'),
       (4, 'cookie'),
       (5, 'cookie'),
       (6, 'cookie'),
       (7, 'cookie'),
       (6, 'troll'),
       (6, 'carrot'),
       (6, 'tinky_winky_69');

INSERT INTO game (name, complexity, time_estimation, min_number_of_players, max_number_of_players, short_description, needed_equipment, min_age, max_age, tutorial, approved)
VALUES ('Terraforming Mars', 3, 3, 1, 5, 'Compete with rival CEOs to make Mars habitable and build your corporate empire.', null, 12, null, 'https://www.youtube.com/watch?v=n3yVpsiVwL8', true),
       ('UNO', 1, 1, 2, 10, 'Get rid of your cards first, but don''t forget to say "UNO"!', null, 6, null, 'https://www.youtube.com/watch?v=sWoSZmHsCls', true),
       ('Mysterium', 1, 2, 2, 7, 'Become a psychic and divine spectral vision to solve the murder of a restless ghost. ', null, 10, null, 'https://www.youtube.com/watch?v=mhCv0CZW2UM', true),
       ('Exploding kittens', 1, 1, 2, 5, 'Ask for favors, attack friends, see the future-whatever it takes to avoid exploding!', null, 7, null, 'https://www.youtube.com/watch?v=kAkRKuv5Rts', true),
       ('Monopoly', 1, 3, 2, 8, 'In this competitive real estate market, there''s only one possible outcome: Monopoly!', null, 8, null, null, true),
       ('Bears vs Babies', 1, 1, 2, 5, 'Humorous game of patchwork bears vs. vicious babies', null, 7, null, null, true),
       ('Trial by Trolley', 1, 2, 3, 13, 'Whose life (or death) do you value more? A game of difficult moral decisions', null, 14, null, null, true),
       ('Unstable Unicorns', 1, 2, 2, 8, 'We know unicorns are cute and cuddly...but who knew they could be so mean?!', null, 14, null, null, true),
       ('BANG!', 1, 1, 4, 7, 'Be at least one standing in this wild west shootout game with hidden roles', null, 10, null, null, true),
       ('Saboteur', 1, 1, 3, 10, 'You are dwarves laying tunnel cards to get gold: but which one of you is the traitor?', null, 8, null, null, true),
       ('Dixit', 1, 1, 3, 6, 'Give the perfect clue so most (not all) player guess the right surreal image card.', null, 8, null, null, true),
       ('Dixit: Odyssey', 1, 1, 3, 12, 'Don''t be too vague or on the nose when describing beautiful art cards.', null, 8, null, null, false),
       ('Dixit: Quest', 1, 1, 3, 6, 'A new set of image cards for Dixit', null, 8, null, null, true),
       ('Dixit: Journey', 1, 1, 3, 6, 'Give a perfect clue to cause some, but not all, to guess your dreamlike card. ', null, 8, null, null, true),
       ('Twister', 1, 1, 2, 4, 'Left foor Red! The classic physical movement party game that ties you up in knots. ', null, 6, null, null, true),
       ('Codenames', 1, 1, 2, 8, 'Give you team clever one-word clues to help them spot their agents in the field', null, 14, null, null, true),
       ('Pandemic', 2, 2, 2, 4, 'Your team of experts must prevent the world from succumbing to a viral pandemic.', null, 8, null, null, true),
       ('Carcassonne', 1, 1, 2, 5, 'Shape the medieval landscape of France, claiming cities, monasteries and farms. ', null, 7, null, null, true),
       ('Battlestar Galactica: The Board Game', 3, 3, 3, 6, 'How can the human race survive when you don''t know who is actually human?', null, 14, null, null, true),
       ('Galaxy Trucker', 2, 2, 2, 4, 'Prepare for unknown dangers by building the best spaceship possible.', null, 10, null, null, true),
       ('Dead of Winter: A Crossroads Game', 3, 2, 2, 5, 'As you struggle to keep survivors alive, how will you value group vs. personal needs?', null, 13, null, null, true),
       ('Munchkin', 1, 2, 3, 6, 'Attack and loot in this humorous, card-based dungeon crawler', null, 10, null, null, false),
       ('Captain Sonar', 2, 2, 2, 8, 'Torpedoes away! Hunt for your opponents sub in this exciting, real-time team game.', null, 14, null, null, true),
       ('Connect Four', 1, 1, 2, 2, 'Take turns dropping pieces to be the first player to connect four in a row!', null, 6, null, null, true),
       ('Chess3', 3, 2, 2, 2, 'Chess with a twist. ', null, null, null, null, true);

INSERT INTO event_game_list (game_id, user_username, event_id)
VALUES (1, 'boardgameGeek', 2),
       (4, 'boardgameGeek', 2),
       (10, 'boardgameGeek', 10),
       (11, 'boardgameGeek', 10),
       (10, 'boardgameGeek', 3),
       (11, 'boardgameGeek', 3),
       (10, 'boardgameGeek', 9),
       (15, 'boardgameGeek', 9),
       (21, 'bobo', 2),
       (20, 'bobo', 2),
       (18, 'bobo', 2),
       (18, 'bobo', 10),
       (18, 'bobo', 4),
       (15, 'bobo', 10),
       (15, 'bobo', 5),
       (11, 'bobo', 6),
       (11, 'bobo', 4),
       (3, 'Dipsy', 8),
       (3, 'Dipsy', 7),
       (6, 'Dipsy', 8),
       (4, 'Dipsy', 8),
       (4, 'Dipsy', 7),
       (16, 'Dipsy', 8),
       (16, 'Dipsy', 7),
       (17, 'Dipsy', 7);


INSERT INTO game_list (game_id, user_username)
VALUES (1, 'boardgameGeek'),
       (3, 'boardgameGeek'),
       (4, 'boardgameGeek'),
       (7, 'boardgameGeek'),
       (8, 'boardgameGeek'),
       (10, 'boardgameGeek'),
       (11, 'boardgameGeek'),
       (15, 'boardgameGeek'),
       (20, 'boardgameGeek'),
       (21, 'bobo'),
       (20, 'bobo'),
       (18, 'bobo'),
       (15, 'bobo'),
       (11, 'bobo'),
       (3, 'Dipsy'),
       (6, 'Dipsy'),
       (4, 'Dipsy'),
       (16, 'Dipsy'),
       (17, 'Dipsy');