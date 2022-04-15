DROP SCHEMA IF EXISTS percussion_island;
CREATE SCHEMA percussion_island;
USE percussion_island;

CREATE TABLE game_user (
  user_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  user_name VARCHAR(45) NOT NULL,
  email VARCHAR(45) NOT NULL,
  date_joined TIMESTAMP NOT NULL,
  PRIMARY KEY  (user_id),
  KEY idx_user_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table progress (
	progress_id smallint unsigned not null auto_increment,
    sections_id smallint unsigned not null,
    inventory_id smallint unsigned not null,
    score_id smallint unsigned not null,
    primary key (progress_id),
    CONSTRAINT `fk_progress_sections` FOREIGN KEY (island_id) REFERENCES sections (sections_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_progress_inventory` FOREIGN KEY (inventory_id) REFERENCES inventory (inventory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_progress_score` FOREIGN KEY (score_id) REFERENCES score (score_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table inventory (
	inventory_id smallint unsigned not null auto_increment,
    collected_instrument smallint not null,
    instruments_hub smallint not null,
    insturments_island1 smallint not null,
    instruments_island2 smallint not null,
    primary key (inventory_id)
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

create table questions (
	question_id smallint unsigned not null auto_increment,
    question varchar(100) not null,
    cor_answer varchar(50) not null,
    answer_2 varchar(50) not null,
    answer_3 varchar(50) not null,
    answer_4 varchar(50) not null,
    primary key (question_id)
)   ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

create table scores (
	score_id smallint unsigned not null auto_increment,
    memory_id smallint not null,
    trivia_id smallint not null,
    rhythm_id smallint not null,
    memorysounds_id smallint not null,
    primary key (score_id),
    CONSTRAINT `fk_scores_memory` FOREIGN KEY (memory_id) REFERENCES memory_game (memory_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_trivia` FOREIGN KEY (trivia_id) REFERENCES trivia_game (trivia_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_rhythm` FOREIGN KEY (rhythm_id) REFERENCES rhythm_game (rhythm_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT `fk_scores_memorysounds` FOREIGN KEY (memorysounds_id) REFERENCES memorysounds_game (memorysounds_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;