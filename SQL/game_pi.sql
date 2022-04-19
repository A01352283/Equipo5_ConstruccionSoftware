DROP SCHEMA IF EXISTS percussion_island;
CREATE SCHEMA percussion_island;
USE percussion_island;


create table inventory (
	inventory_id smallint unsigned not null auto_increment,
    collected_instrument smallint not null,
    instruments_hub smallint not null,
    insturments_island1 smallint not null,
    instruments_island2 smallint not null,
    primary key (inventory_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table hub (
	hub_id smallint unsigned not null auto_increment,
    xilophone boolean not null,
    marimba boolean not null,
    bongo boolean not null,
    primary key (hub_id)
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


create table island1(
	island1_id smallint unsigned not null auto_increment,
    snare boolean not null,
    triangle boolean not null,
    gong boolean not null,
    primary key (island1_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table island2(
	island2_id smallint unsigned not null auto_increment,
    maracas boolean not null,
    tamborine boolean not null,
    box boolean not null,
    primary key (island2_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table sections (
	sections_id smallint unsigned not null auto_increment,
    hub_id smallint unsigned not null,
    island1_id smallint unsigned not null,
    island2_id smallint unsigned not null,
    primary key (sections_id),
    CONSTRAINT `fk_sections_hub` FOREIGN KEY (hub_id) REFERENCES hub (hub_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_sections_island1` FOREIGN KEY (island1_id) REFERENCES island1 (island1_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_sections_island2` FOREIGN KEY (island2_id) REFERENCES island2 (island2_id) ON DELETE RESTRICT ON UPDATE CASCADE
)	ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;



create table memory_game (
	memory_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    time_played time not null,
    last_score smallint not null,
    primary key (memory_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table rhythm_game (
	rhythm_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    time_played time not null,
    last_score smallint not null,
    primary key (rhythm_id)
)  ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table memorysounds_game (
	memorysound_id smallint unsigned not null auto_increment,
    best_score smallint not null,
	time_played time,
    last_score smallint,
    primary key (memorysound_id)
)  ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table trivia_game (
	trivia_id smallint unsigned not null auto_increment,
    best_score smallint not null,
	time_played time,
    last_score smallint,
    primary key (trivia_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


create table scores (
	score_id smallint unsigned not null auto_increment,
    memory_id smallint unsigned not null,
    trivia_id smallint unsigned not null,
    rhythm_id smallint unsigned not null,
    memorysound_id smallint unsigned not null,
    primary key (score_id),
    CONSTRAINT `fk_scores_memory` FOREIGN KEY (memory_id) REFERENCES memory_game (memory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_trivia` FOREIGN KEY (trivia_id) REFERENCES trivia_game (trivia_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_rhythm` FOREIGN KEY (rhythm_id) REFERENCES rhythm_game (rhythm_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_memorysounds` FOREIGN KEY (memorysound_id) REFERENCES memorysounds_game (memorysound_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE game_user (
  user_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  user_name VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL,
  date_joined datetime NOT NULL,
  PRIMARY KEY  (user_id),
  KEY idx_user_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table progress (
	user_id smallint unsigned not null auto_increment,
    sections_id smallint unsigned not null,
    inventory_id smallint unsigned not null,
    score_id smallint unsigned not null,
    primary key (user_id),
    CONSTRAINT `fk_progress_user` FOREIGN KEY (user_id) REFERENCES game_user (user_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_progress_sections` FOREIGN KEY (sections_id) REFERENCES sections (sections_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_progress_inventory` FOREIGN KEY (inventory_id) REFERENCES inventory (inventory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_progress_score` FOREIGN KEY (score_id) REFERENCES scores (score_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


