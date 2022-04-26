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
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `question_id` smallint unsigned NOT NULL AUTO_INCREMENT,
  `question` varchar(100) NOT NULL,
  `cor_answer` varchar(50) NOT NULL,
  `answer_2` varchar(50) NOT NULL,
  `answer_3` varchar(50) NOT NULL,
  `answer_4` varchar(50) NOT NULL,
  PRIMARY KEY (`question_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'How old are you?','22','65','94','17'),(2,'Favorite movie?','Star Wars','Matrix','Pulp Fiction','Black Panther'),(3,'Favorite Color?','pink','blue','red','yellow'),(4,'Best instrument?','Bass','Drum','Bell Drum','Banana Shaker'),(5,'Best City?','Nyc','Mexico City','Monterrey','Montreal'),(6,'Best drink?','coffee','beer','milk','water'),(7,'Christmas Day?','December 25','January 1','October 3','November 28'),(8,'Best day of the week?','Friday','Monday','Tuesday','Thursday'),(9,'Best University?','Tec','UNAM','Anahuac','UP'),(10,'Which instrument is not percussive?','Guitar','Bongo','Bell Drum','Banana Shaker'),(11,'Which year is it?','2022','2001','2020','1999'),(12,'Best Country?','Mexico','USA','Spain','Japan'),(13,'Best videogame?','Percussion Island','Hollow Knight','Space Invaders','Pokemon'),(14,'What does PAS mean?','Percussion Arts Society','Peace American Society','Poland Association Strike','Poll American Society'),(15,'Best soccer team?','Barca','Madrid','America','Milan'),(16,'Best coding language?','Python','C++','JS','HTML'),(17,'Best Tec Campus?','Santa Fe','Cuernavaca','Monterrey','Guadalajara'),(18,'0+1?','1','-1','10','23'),(19,'What does int mean?','integer','interest','invisible','incorrect'),(20,'Best Restaurant?','Chilis','Sushiroll','BurgerKing','KFC');
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-22 22:49:55
