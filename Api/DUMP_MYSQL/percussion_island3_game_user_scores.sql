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
  CONSTRAINT `fk_user_scores` FOREIGN KEY (`user_id`) REFERENCES `game_user` (`user_id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `game_user_scores`
--

LOCK TABLES `game_user_scores` WRITE;
/*!40000 ALTER TABLE `game_user_scores` DISABLE KEYS */;
INSERT INTO `game_user_scores` VALUES (1,0,27,'00:01:00',0,39,'00:12:00',0,40,'00:16:00',0,66,'00:02:00'),(2,0,572,'00:05:52',0,780,'00:04:25',0,530,'00:03:50',0,666,'00:05:45'),(3,0,515,'00:06:52',0,461,'00:05:35',0,790,'00:02:42',0,683,'00:01:45'),(4,0,679,'00:10:42',0,614,'00:10:50',0,462,'00:42:12',0,842,'00:06:55'),(5,0,145,'00:03:53',0,672,'00:20:50',0,783,'00:39:25',0,342,'00:56:55'),(6,0,360,'00:27:23',0,513,'00:07:35',0,230,'00:09:25',0,273,'00:03:52'),(7,0,913,'00:15:11',0,861,'00:17:35',0,616,'00:05:22',0,478,'00:13:59'),(8,0,452,'00:01:11',0,257,'00:03:38',0,472,'00:16:12',0,250,'00:30:49'),(9,0,876,'10:01:11',0,691,'00:33:34',0,316,'01:06:35',0,368,'00:20:35'),(10,0,455,'00:05:52',0,780,'00:12:00',0,530,'02:16:00',0,90,'00:30:12'),(11,0,794,'02:45:52',0,1030,'05:20:10',0,693,'01:09:10',0,394,'00:53:12'),(12,0,526,'01:56:23',0,724,'00:36:24',0,572,'01:19:21',0,327,'00:03:12'),(13,0,671,'00:47:11',0,146,'01:22:25',0,831,'00:31:13',0,968,'00:23:17'),(14,0,246,'00:18:24',0,624,'01:13:35',0,1090,'00:39:52',0,865,'01:13:13'),(15,0,624,'00:31:00',0,724,'00:36:25',0,782,'00:19:22',0,646,'00:36:47'),(16,0,167,'00:05:24',0,467,'01:03:26',0,780,'00:24:32',0,500,'00:11:43'),(17,0,421,'01:53:16',0,613,'00:43:12',0,300,'00:32:11',0,780,'00:17:43'),(18,0,494,'00:01:30',0,742,'01:51:00',0,678,'01:33:13',0,210,'00:14:23'),(19,0,713,'00:17:44',0,624,'00:04:25',0,136,'00:12:00',0,427,'00:05:45'),(20,0,472,'01:18:34',0,967,'00:46:15',0,546,'00:24:10',0,732,'01:23:35'),(21,0,629,'02:38:14',0,1010,'00:31:35',0,367,'01:24:30',0,100,'01:37:45'),(22,0,721,'00:58:24',0,743,'01:10:06',0,670,'01:05:10',0,693,'02:17:35');
/*!40000 ALTER TABLE `game_user_scores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22 22:49:56
