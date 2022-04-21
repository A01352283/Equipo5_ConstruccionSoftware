DROP SCHEMA IF EXISTS percussion_island3;
CREATE SCHEMA percussion_island3;
USE percussion_island3;

CREATE TABLE game_user (
  user_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  user_name VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL,
  date_joined datetime NOT NULL,
  PRIMARY KEY  (user_id),
  KEY idx_user_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table hub (
	hub_id smallint unsigned not null auto_increment,
    xilophone boolean not null,
    marimba boolean not null,
    bongo boolean not null,
    primary key (hub_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
	sections_id smallint unsigned not null AUTO_INCREMENT,
    hub_id smallint unsigned not null,
    island1_id smallint unsigned not null,
    island2_id smallint unsigned not null,
    primary key (sections_id),
    CONSTRAINT `fk_hub_sections` FOREIGN KEY (hub_id) REFERENCES hub (hub_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_island1_sections` FOREIGN KEY (island1_id) REFERENCES island1 (island1_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_island2_sections` FOREIGN KEY (island2_id) REFERENCES island2 (island2_id) ON DELETE RESTRICT ON UPDATE CASCADE
)	ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


create table inventory (
	inventory_id smallint unsigned not null auto_increment,
    instruments_hub smallint not null,
    insturments_island1 smallint not null,
    instruments_island2 smallint not null,
    primary key (inventory_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;



create table memory_game (
	memory_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    last_score smallint not null,
    primary key (memory_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table rhythm_game (
	rhythm_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    last_score smallint not null,
    primary key (rhythm_id)
)  ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table memorysounds_game (
	memorysound_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    last_score smallint,
    primary key (memorysound_id)
)  ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table trivia_game (
	trivia_id smallint unsigned not null auto_increment,
    best_score smallint not null,
    last_score smallint,
    primary key (trivia_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table scores (
	score_id smallint unsigned not null auto_increment,
    memory_id smallint unsigned not null,
    trivia_id smallint unsigned not null,
    rhythm_id smallint unsigned not null,
    memorysound_id smallint unsigned not null,
    time_played time,
    primary key (score_id),
    CONSTRAINT `fk_memory_scores` FOREIGN KEY (memory_id) REFERENCES memory_game (memory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_trivia_cores` FOREIGN KEY (trivia_id) REFERENCES trivia_game (trivia_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_rhythm_scores` FOREIGN KEY (rhythm_id) REFERENCES rhythm_game (rhythm_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_memorysound_scores` FOREIGN KEY (memorysound_id) REFERENCES memorysounds_game (memorysound_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table progress (
	user_id smallint unsigned not null,
    sections_id smallint unsigned not null,
    inventory_id smallint unsigned not null,
    score_id smallint unsigned not null,
    CONSTRAINT `fk_user_progress` FOREIGN KEY (user_id) REFERENCES game_user (user_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_section_progress` FOREIGN KEY (sections_id) REFERENCES sections (sections_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_inventory_progress` FOREIGN KEY (inventory_id) REFERENCES inventory (inventory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_score_progress` FOREIGN KEY (score_id) REFERENCES scores (score_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
