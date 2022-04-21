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

create table questions