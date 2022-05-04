DROP SCHEMA IF EXISTS percussion_island3;
CREATE SCHEMA percussion_island3;
USE percussion_island3;

CREATE TABLE game_user (
  user_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  user_name VARCHAR(45) NOT NULL,
  pwd VARCHAR(45) NOT NULL,
  date_joined date not null default (current_date),
  PRIMARY KEY  (user_id),
  KEY idx_user_name (user_name),
  UNIQUE KEY `user_name_UNIQUE` (user_name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table questions (
	question_id smallint unsigned not null auto_increment,
    question varchar(100) not null,
    cor_answer varchar(100) not null,
    answer_2 varchar(100) not null,
    answer_3 varchar(100) not null,
    answer_4 varchar(100) not null,
    primary key (question_id)
)   ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table game_user_scores(
	user_id smallint unsigned not null,
	rhythm_best_score smallint unsigned not null default 0,
    rhythm_last_score smallint unsigned not null default 0,
    rhythm_play_time time not null default ("00:00:00"),
    trivia_best_score smallint unsigned not null default 0,
    trivia_last_score smallint unsigned not null default 0,
    trivia_play_time time not null default ("00:00:00"),
    memory_best_score smallint unsigned not null default 0,
    memory_last_score smallint unsigned not null default 0,
    memory_play_time time not null default ("00:00:00"),
    memorysounds_best_score smallint unsigned not null default 0,
    memorysounds_last_score smallint unsigned not null default 0,
    memorysounds_play_time time not null default ("00:00:00"),
    primary key (user_id),
    CONSTRAINT `fk_user_scores` FOREIGN KEY (user_id) REFERENCES game_user (user_id) ON DELETE CASCADE ON UPDATE CASCADE

)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table game_user_key_inventory(
	user_id smallint unsigned not null,
    key_item_name varchar(50) not null,
    CONSTRAINT `fk_user_inventory` FOREIGN KEY (user_id) REFERENCES game_user (user_id) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


create table game_user_save_file(
	user_id smallint unsigned not null,
    key_instruments_unlocked tinyint unsigned not null default 0,
    player_position_x float not null default 0.0,
    player_position_y float not null default 0.0,
    primary key(user_id),
    CONSTRAINT `fk_user_savefile` FOREIGN KEY (user_id) REFERENCES game_user (user_id) ON DELETE CASCADE ON UPDATE CASCADE
)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `game_user` VALUES (1,'Chava_27','dfafakfdja','2022-04-22'),(2,'Ivan_34','vuehvabv','2022-04-22'),(3,'Andres_22','cacajbvja','2022-04-22'),(4,'GreyMaster_44','vuecueuc','2022-04-22'),(5,'Tony_Font23','vdv7adva','2022-04-22'),(6,'RoyDancer99','3dd3dh3','2022-04-22'),(7,'LuisJa','c73f7f3','2022-04-22'),(8,'Dany_U','3f3f93f','2022-04-22'),(9,'Yun_73','8C73C3','2022-04-22'),(10,'Frida_26','cuece8c','2022-04-22'),(11,'Koala332',']ce48g','2022-04-22'),(12,'Mister_S','EF84FH4','2022-04-22'),(13,'Hope_393','V7V3ICS','2022-04-22'),(14,'Marie66','dcudvev23','2022-04-22'),(15,'Connie_B','v3339v3','2022-04-22'),(16,'Marc_F32','v448f48f','2022-04-22'),(17,'Puig_55','barca11','2022-04-22'),(18,'Mauster15','jcbjdcbaic','2022-04-22'),(19,'Pocoyo_52','c3c93c','2022-04-22'),(20,'Dennis_62','v38v38','2022-04-22'),(21,'Mgd11','dvaege21','2022-04-22'),(22,'Mikey','dfhqdd2','2022-04-22');

INSERT INTO `questions` VALUES (1,'What is a typical shell depth for a concert snare drum? ','5-6 inches deep','3-4 inches deep','7-8 inches deep','1-2 inches deep'),(2,'What are good maintenance routines that should be performed on a concert snare?','Change the heads regularly and check the snares','Change the shell regularly','Change the tension regularly','Change the counter hoop'),(3,'Which is the recommended beating area on a snare drum?','Just off the center of the drum','At the exact center of the drum','Closest to the edge of the drum','In the snare head'),(4,'What is the best place on the bar to play most keyboard percussion instruments? ','In the center of the bar or on the edge.','Directly above the string','On the nodal spot','On the outside edge of the bar'),(5,'What can you do to keep your keyboard instruments in their best shape?','Putting a cover, cleaning dust and checking the strings','Never putting a cover on the instruments because of moisture','Putting books on top of the keyboard to keep it "balanced"','Using floor wax to clean the keyboard, once a month'),(6,'What do you use to play the keyboard instruments?','Mallets','Drumsticks','Iron ramrod','Hands'),(7,'Which is not one of the pedal systems found in timpani?','Davidson system','Balanced actions pedals','Dresden system','Ball lock system'),(8,'Which are the most common sizes of timpani?','32, 29, 26, 23 inches','30, 27, 24, 21 inches','33, 30, 27, 24 inches','32, 28, 24, 22 inches'),(9,'Which one is not one a common grip for timpani playing?','Italian grip','German grip','American grip','French grip'),(10,'What is a typical size for a good concert bass drum?',' 26 - 36 inches deep shell','32 - 40 inches deep shell','18- 24 inches deep shell','38 - 42 inches deep shell'),(11,'What is the best general beating area on the concert bass drum?','Just off the center of the head','Directly in the center of the head','2 inches off the edge','4 inches off the edge'),(12,'Name the regular maintenance routines that should be performed on a concert bass drum.','Check heads regularly for dents or holes and replace them','Wax the drum weekly','Check for holes and use duct tape to fix them','Do a "sand massage" for the drum on a monthly basis'),(13,'What is the typical size of a concert tambourine?','10 inches',' 8 inches','12 inches','15 inches'),(14,'What does PAS mean?','Percussion Arts Society','Peace American Society','Poland Association Society','Percussion American Service'),(15,'Which of the next materials a tambourine shell can be made of?','Wood','Bronze','Glass','Silver'),(16,'What do you use to play a tambourine?','Your hands','Mallets','Drumsticks','A pedal'),(17,'What is a good general size for crash cymbals?','18 inches','10 inches','26 inches','14 inches'),(18,'What is the best type of strap for a cymbal??',' Leather cymbal straps','Rope cymbal straps','Wooden cymbal holders','Nylon cymbal straps'),(19,'How is the volume of the cymbals controlled?','The volume is determined by how fast the cymbals come together','The volume is determined by how far apart the cymbals are','The volume is determined by the grip','There is no way to control volume'),(20,'What is the typical size for a concert triangle?',' 6 to 9 inches','5 inches','2 to 12 inches','10 to 12 inches'),(21,'When selecting a triangle, which characteristic is most important?','There should be a wide range of overtones and no distinct pitch','There should be a distinct pitch','The silver should be highly polished','The silver should not be polished'),(22,'How many loops are recommended for the string in the clip that holds the triangle?','Two loops','One loop','Six loops','The clip does not require string loops'),(23,'What is the difference between a gong and a tam-tam?','A gong has a definite pitch and a tam-tam does not','A gong is the mini version of a tam-tam','A tam-tam is the mini version of the gong','A tam-tam has a definite pitch and a gong does not'),(24,'When selecting a tam-tam, what should you look for?','A good tam-tam will produce a long, low sustained sound','The size should be 10-12 inches','A good tam-tam will produce a long, high sustained sound','A good tam-tam will produce a short, low sound'),(25,'Which is the best general area to play the tam-tam?','Just off the center','Directly in the center','On the edge','Just off the edge'),(26,'Synthetic or plastic blocks are a great substitute for wood blocks','No','Only when the plastic is polished','Yes','Synthetic blocks are actually better than wooden blocks'),(27,'When playing the woodblock, the slit should be facing…','Towards the audience','Towards the player','Towards the floor','Towards the ceiling'),(28,'What is the best general area to play the wood blocks?','Towards the center','Just off the edge','On the exact edge','There is no sweet spot'),(29,'Why is a timpani mallet not always the best choice for striking a suspended cymbal?','A timpani mallet is not heavy enough to activate the whole cymbal','The core is too soft to produce good sound','The cymbal will cause excessive wear on the soft felt','The mallet is too thin, so it might break'),(30,'What is the best way to muffle a cymbal?','By grabbing it with your hand','Using a towel','Using a clamp','The cymbal should not be muffled'),(31,'What do you use to clean your cymbal?','Cymbal cleaners','A metal sponge','Brass polish','Microfiber cloth');

INSERT INTO `game_user_key_inventory` VALUES (1,'bongo'),(1,'drum'),(2,'drum'),(2,'castanets'),(3,'drum'),(4,'bongo'),(4,'castanets'),(5,'drum'),(5,'bongo'),(10,'castanets'),(20,'drum'),(20,'bongo'),(17,'drum'),(17,'bongo'),(13,'castanets'),(19,'castanets'),(12,'drum'),(7,'bongos'),(7,'castanets'),(7,'drum'),(15,'drum'),(15,'bongos');

INSERT INTO `game_user_scores` VALUES (1,250,136,'00:12:41',190,129,'00:08:24',221,192,'00:06:09',120,106,'00:03:00'),(2,230,172,'00:21:32',110,93,'00:03:25',270,130,'00:18:26',234,156,'00:11:42'),(3,120,80,'00:03:22',220,164,'00:19:15',205,190,'00:12:32',190,133,'00:08:24'),(4,176,109,'00:07:12',260,194,'00:16:46',173,102,'00:08:52',110,90,'00:02:51'),(5,260,125,'00:17:26',229,204,'00:20:56',197,103,'00:09:45',252,142,'00:16:36'),(6,220,160,'00:17:43',261,113,'00:19:25',200,130,'00:07:25',252,230,'00:13:32'),(7,291,113,'00:22:41',190,161,'00:11:36',232,198,'00:14:12',170,108,'00:08:59'),(8,135,102,'00:07:41',210,157,'00:13:48',256,232,'00:19:12',262,250,'00:30:49'),(9,175,106,'00:07:15',210,151,'00:13:44',164,89,'00:05:33',264,208,'00:21:35'),(10,161,125,'00:07:52',251,175,'00:12:36',215,130,'00:13:47',256,197,'00:26:37'),(11,230,184,'00:21:17',179,82,'00:08:40',290,258,'00:29:52',216,146,'00:18:42'),(12,252,126,'00:16:03',190,124,'00:11:27',240,172,'00:29:11',183,127,'00:17:41'),(13,163,71,'00:05:15',252,176,'00:19:45',197,101,'00:17:13',210,188,'00:18:47'),(14,216,176,'00:14:24',251,164,'00:21:05',192,106,'00:13:52',251,175,'00:20:53'),(15,247,171,'00:19:16',210,121,'00:16:45',216,182,'00:17:28',241,128,'00:18:27'),(16,262,157,'00:25:52',152,67,'00:08:56',201,162,'00:11:32',197,102,'00:12:43'),(17,185,161,'00:08:36',230,113,'00:13:02',257,181,'00:25:13',109,40,'00:05:23'),(18,251,194,'00:27:17',124,72,'00:07:38',152,108,'00:10:16',189,106,'00:14:25'),(19,109,83,'00:07:44',252,124,'00:18:15',180,136,'00:11:57',263,127,'00:28:15'),(20,150,122,'00:09:34',216,127,'00:16:15',152,101,'00:07:26',95,32,'00:05:15'),(21,251,129,'00:18:14',195,157,'00:09:15',254,167,'00:14:15',151,106,'00:07:45'),(22,161,116,'00:06:14',238,143,'00:16:16',151,117,'00:08:12',215,193,'00:14:25');

INSERT INTO `game_user_save_file` VALUES (1,3,282,-234),(2,4,113,35),(3,0,433,-11),(4,2,494,943),(5,4,-515,100),(6,2,54,-800),(7,3,191,-111),(8,2,383,-10),(9,4,-621,931),(10,1,933,-351),(11,3,750,-221),(12,1,422,691),(13,2,102,-351),(14,4,692,-613),(15,0,72,-98),(16,2,-611,89),(17,1,951,-151),(18,3,-513,52),(19,2,384,554),(20,3,835,-111),(21,1,516,654),(22,0,341,-15);

create view top_rhythm_scores as
select user_name, rhythm_best_score from game_user_scores as gs
Inner join game_user as gu on gs.user_id = gu.user_id order by rhythm_best_score desc limit 10;

create view top_trivia_scores as
select user_name, trivia_best_score from game_user_scores as gs
Inner join game_user as gu on gs.user_id = gu.user_id order by trivia_best_score desc limit 10;

create view top_memory_scores as
select user_name, memory_best_score from game_user_scores as gs
Inner join game_user as gu on gs.user_id = gu.user_id order by memory_best_score desc limit 10;

create view top_memorysounds_scores as
select user_name, memorysounds_best_score from game_user_scores as gs
Inner join game_user as gu on gs.user_id = gu.user_id order by memorysounds_best_score desc limit 10;

DELIMITER $$
CREATE TRIGGER create_user_tables
AFTER INSERT ON game_user
FOR EACH ROW
BEGIN
	INSERT INTO game_user_scores (user_id) values (NEW.user_id);
    INSERT INTO game_user_save_file (user_id) values (NEW.user_id);
END$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER update_rhythm_best_score
BEFORE UPDATE ON game_user_scores
FOR EACH ROW
BEGIN
	IF NEW.rhythm_last_score > OLD.rhythm_best_score THEN
	SET NEW.rhythm_best_score = NEW.rhythm_last_score;
    END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER update_trivia_best_score
BEFORE UPDATE ON game_user_scores
FOR EACH ROW
BEGIN
	IF NEW.trivia_last_score > OLD.trivia_best_score THEN
	SET NEW.trivia_best_score = NEW.trivia_last_score;
    END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER update_memory_best_score
BEFORE UPDATE ON game_user_scores
FOR EACH ROW
BEGIN
	IF NEW.memory_last_score > OLD.memory_best_score THEN
	SET NEW.memory_best_score = NEW.memory_last_score;
    END IF;
END$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER update_memorysounds_best_score
BEFORE UPDATE ON game_user_scores
FOR EACH ROW
BEGIN
	IF NEW.memorysounds_last_score > OLD.memorysounds_best_score THEN
	SET NEW.memorysounds_best_score = NEW.memorysounds_last_score;
    END IF;
END$$
DELIMITER ;

DELIMITER //
CREATE PROCEDURE get_user_id (in user_n VARCHAR(45))
BEGIN
SELECT user_id 
FROM game_user where user_name = user_n;
END//
DELIMITER ;

DELIMITER $$
CREATE TRIGGER sum_mg_time
BEFORE UPDATE ON game_user_scores
FOR EACH ROW
BEGIN
	SET NEW.trivia_play_time= OLD.trivia_play_time + NEW.trivia_play_time;
    SET NEW.memory_play_time= OLD.memory_play_time + NEW.memory_play_time;
    SET NEW.memorysounds_play_time= OLD.memorysounds_play_time + NEW.memorysounds_play_time;
    SET NEW.rhythm_play_time= OLD.rhythm_play_time + NEW.rhythm_play_time;
END$$
DELIMITER ;

create view total_play_time as
select SUM(time_to_sec(memory_play_time)) as 
total_memory_play_time, 
SUM(time_to_sec(trivia_play_time)) as 
total_trivia_play_time, 
SUM(time_to_sec(memorysounds_play_time)) as 
total_memorysounds_play_time, 
SUM(time_to_sec(rhythm_play_time)) as 
total_rhythm_play_time from game_user_scores;