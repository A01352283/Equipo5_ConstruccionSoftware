CREATE DATABASE  IF NOT EXISTS `percussion_island3` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `percussion_island3`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: percussion_island3
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `game_user_scores`
--

DROP TABLE IF EXISTS `game_user_scores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `game_user_scores` (
  `user_id` smallint unsigned NOT NULL,
  `rhythm_best_score` smallint unsigned NOT NULL DEFAULT '0',
  `rhythm_last_score` smallint unsigned NOT NULL DEFAULT '0',
  `rhythm_play_time` time NOT NULL DEFAULT (_utf8mb4'00:00:00'),
  `trivia_best_score` smallint unsigned NOT NULL DEFAULT '0',
  `trivia_last_score` smallint unsigned NOT NULL DEFAULT '0',
  `trivia_play_time` time NOT NULL DEFAULT (_utf8mb4'00:00:00'),
  `memory_best_score` smallint unsigned NOT NULL DEFAULT '0',
  `memory_last_score` smallint unsigned NOT NULL DEFAULT '0',
  `memory_play_time` time NOT NULL DEFAULT (_utf8mb4'00:00:00'),
  `memorysounds_best_score` smallint unsigned NOT NULL DEFAULT '0',
  `memorysounds_last_score` smallint unsigned NOT NULL DEFAULT '0',
  `memorysounds_play_time` time NOT NULL DEFAULT (_utf8mb4'00:00:00'),
  PRIMARY KEY (`user_id`),
  CONSTRAINT `fk_user_scores` FOREIGN KEY (`user_id`) REFERENCES `game_user` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `game_user_scores`
--

LOCK TABLES `game_user_scores` WRITE;
/*!40000 ALTER TABLE `game_user_scores` DISABLE KEYS */;
INSERT INTO `game_user_scores` VALUES (1,250,136,'00:12:41',190,129,'00:08:24',221,192,'00:06:09',120,106,'00:03:00'),(2,230,172,'00:21:32',110,93,'00:03:25',270,130,'00:18:26',234,156,'00:11:42'),(3,120,80,'00:03:22',220,164,'00:19:15',205,190,'00:12:32',190,133,'00:08:24'),(4,176,109,'00:07:12',260,194,'00:16:46',173,102,'00:08:52',110,90,'00:02:51'),(5,260,125,'00:17:26',229,204,'00:20:56',197,103,'00:09:45',252,142,'00:16:36'),(6,220,160,'00:17:43',261,113,'00:19:25',200,130,'00:07:25',252,230,'00:13:32'),(7,291,113,'00:22:41',190,161,'00:11:36',232,198,'00:14:12',170,108,'00:08:59'),(8,135,102,'00:07:41',210,157,'00:13:48',256,232,'00:19:12',262,250,'00:30:49'),(9,175,106,'00:07:15',210,151,'00:13:44',164,89,'00:05:33',264,208,'00:21:35'),(10,161,125,'00:07:52',251,175,'00:12:36',215,130,'00:13:47',256,197,'00:26:37'),(11,230,184,'00:21:17',179,82,'00:08:40',290,258,'00:29:52',216,146,'00:18:42'),(12,252,126,'00:16:03',190,124,'00:11:27',240,172,'00:29:11',183,127,'00:17:41'),(13,163,71,'00:05:15',252,176,'00:19:45',197,101,'00:17:13',210,188,'00:18:47'),(14,216,176,'00:14:24',251,164,'00:21:05',192,106,'00:13:52',251,175,'00:20:53'),(15,247,171,'00:19:16',210,121,'00:16:45',216,182,'00:17:28',241,128,'00:18:27'),(16,262,157,'00:25:52',152,67,'00:08:56',201,162,'00:11:32',197,102,'00:12:43'),(17,185,161,'00:08:36',230,113,'00:13:02',257,181,'00:25:13',109,40,'00:05:23'),(18,251,194,'00:27:17',124,72,'00:07:38',152,108,'00:10:16',189,106,'00:14:25'),(19,109,83,'00:07:44',252,124,'00:18:15',180,136,'00:11:57',263,127,'00:28:15'),(20,150,122,'00:09:34',216,127,'00:16:15',152,101,'00:07:26',95,32,'00:05:15'),(21,251,129,'00:18:14',195,157,'00:09:15',254,167,'00:14:15',151,106,'00:07:45'),(22,161,116,'00:06:14',238,143,'00:16:16',151,117,'00:08:12',215,193,'00:14:25');
/*!40000 ALTER TABLE `game_user_scores` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_rhythm_best_score` BEFORE UPDATE ON `game_user_scores` FOR EACH ROW BEGIN
	IF NEW.rhythm_last_score > OLD.rhythm_best_score THEN
	SET NEW.rhythm_best_score = NEW.rhythm_last_score;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_trivia_best_score` BEFORE UPDATE ON `game_user_scores` FOR EACH ROW BEGIN
	IF NEW.trivia_last_score > OLD.trivia_best_score THEN
	SET NEW.trivia_best_score = NEW.trivia_last_score;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_memory_best_score` BEFORE UPDATE ON `game_user_scores` FOR EACH ROW BEGIN
	IF NEW.memory_last_score > OLD.memory_best_score THEN
	SET NEW.memory_best_score = NEW.memory_last_score;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_memorysounds_best_score` BEFORE UPDATE ON `game_user_scores` FOR EACH ROW BEGIN
	IF NEW.memorysounds_last_score > OLD.memorysounds_best_score THEN
	SET NEW.memorysounds_best_score = NEW.memorysounds_last_score;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `sum_mg_time` BEFORE UPDATE ON `game_user_scores` FOR EACH ROW BEGIN
	SET NEW.trivia_play_time= OLD.trivia_play_time + NEW.trivia_play_time;
    SET NEW.memory_play_time= OLD.memory_play_time + NEW.memory_play_time;
    SET NEW.memorysounds_play_time= OLD.memorysounds_play_time + NEW.memorysounds_play_time;
    SET NEW.rhythm_play_time= OLD.rhythm_play_time + NEW.rhythm_play_time;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-03 23:37:13
