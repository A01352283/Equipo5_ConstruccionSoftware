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
    cor_answer varchar(50) not null,
    answer_2 varchar(50) not null,
    answer_3 varchar(50) not null,
    answer_4 varchar(50) not null,
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

INSERT INTO `questions` VALUES (1,'How old are you?','22','65','94','17'),(2,'Favorite movie?','Star Wars','Matrix','Pulp Fiction','Black Panther'),(3,'Favorite Color?','pink','blue','red','yellow'),(4,'Best instrument?','Bass','Drum','Bell Drum','Banana Shaker'),(5,'Best City?','Nyc','Mexico City','Monterrey','Montreal'),(6,'Best drink?','coffee','beer','milk','water'),(7,'Christmas Day?','December 25','January 1','October 3','November 28'),(8,'Best day of the week?','Friday','Monday','Tuesday','Thursday'),(9,'Best University?','Tec','UNAM','Anahuac','UP'),(10,'Which instrument is not percussive?','Guitar','Bongo','Bell Drum','Banana Shaker'),(11,'Which year is it?','2022','2001','2020','1999'),(12,'Best Country?','Mexico','USA','Spain','Japan'),(13,'Best videogame?','Percussion Island','Hollow Knight','Space Invaders','Pokemon'),(14,'What does PAS mean?','Percussion Arts Society','Peace American Society','Poland Association Strike','Poll American Society'),(15,'Best soccer team?','Barca','Madrid','America','Milan'),(16,'Best coding language?','Python','C++','JS','HTML'),(17,'Best Tec Campus?','Santa Fe','Cuernavaca','Monterrey','Guadalajara'),(18,'0+1?','1','-1','10','23'),(19,'What does int mean?','integer','interest','invisible','incorrect'),(20,'Best Restaurant?','Chilis','Sushiroll','BurgerKing','KFC');

INSERT INTO `game_user_key_inventory` VALUES (1,'bongo'),(1,'drum'),(2,'drum'),(2,'castanets'),(3,'drum'),(4,'bongo'),(4,'castanets'),(5,'drum'),(5,'bongo'),(10,'castanets'),(20,'drum'),(20,'bongo'),(17,'drum'),(17,'bongo'),(13,'castanets'),(19,'castanets'),(12,'drum'),(7,'bongos'),(7,'castanets'),(7,'drum'),(15,'drum'),(15,'bongos');

INSERT INTO `game_user_scores` VALUES (1,0,27,'00:01:00',0,39,'00:12:00',0,40,'00:16:00',0,66,'00:02:00'),(2,0,572,'00:05:52',0,780,'00:04:25',0,530,'00:03:50',0,666,'00:05:45'),(3,0,515,'00:06:52',0,461,'00:05:35',0,790,'00:02:42',0,683,'00:01:45'),(4,0,679,'00:10:42',0,614,'00:10:50',0,462,'00:42:12',0,842,'00:06:55'),(5,0,145,'00:03:53',0,672,'00:20:50',0,783,'00:39:25',0,342,'00:56:55'),(6,0,360,'00:27:23',0,513,'00:07:35',0,230,'00:09:25',0,273,'00:03:52'),(7,0,913,'00:15:11',0,861,'00:17:35',0,616,'00:05:22',0,478,'00:13:59'),(8,0,452,'00:01:11',0,257,'00:03:38',0,472,'00:16:12',0,250,'00:30:49'),(9,0,876,'10:01:11',0,691,'00:33:34',0,316,'01:06:35',0,368,'00:20:35'),(10,0,455,'00:05:52',0,780,'00:12:00',0,530,'02:16:00',0,90,'00:30:12'),(11,0,794,'02:45:52',0,1030,'05:20:10',0,693,'01:09:10',0,394,'00:53:12'),(12,0,526,'01:56:23',0,724,'00:36:24',0,572,'01:19:21',0,327,'00:03:12'),(13,0,671,'00:47:11',0,146,'01:22:25',0,831,'00:31:13',0,968,'00:23:17'),(14,0,246,'00:18:24',0,624,'01:13:35',0,1090,'00:39:52',0,865,'01:13:13'),(15,0,624,'00:31:00',0,724,'00:36:25',0,782,'00:19:22',0,646,'00:36:47'),(16,0,167,'00:05:24',0,467,'01:03:26',0,780,'00:24:32',0,500,'00:11:43'),(17,0,421,'01:53:16',0,613,'00:43:12',0,300,'00:32:11',0,780,'00:17:43'),(18,0,494,'00:01:30',0,742,'01:51:00',0,678,'01:33:13',0,210,'00:14:23'),(19,0,713,'00:17:44',0,624,'00:04:25',0,136,'00:12:00',0,427,'00:05:45'),(20,0,472,'01:18:34',0,967,'00:46:15',0,546,'00:24:10',0,732,'01:23:35'),(21,0,629,'02:38:14',0,1010,'00:31:35',0,367,'01:24:30',0,100,'01:37:45'),(22,0,721,'00:58:24',0,743,'01:10:06',0,670,'01:05:10',0,693,'02:17:35');

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
select sec_to_time(SUM(memory_play_time)) as 
total_memory_play_time, 
sec_to_time(SUM(trivia_play_time)) as 
total_trivia_play_time, 
sec_to_time(SUM(memorysounds_play_time)) as 
total_memorysounds_play_time, 
sec_to_time(SUM(rhythm_play_time)) as 
total_rhythm_play_time from game_user_scores;

