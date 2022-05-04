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
  `cor_answer` varchar(100) NOT NULL,
  `answer_2` varchar(100) NOT NULL,
  `answer_3` varchar(100) NOT NULL,
  `answer_4` varchar(100) NOT NULL,
  PRIMARY KEY (`question_id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'What is a typical shell depth for a concert snare drum? ','5-6 inches deep','3-4 inches deep','7-8 inches deep','1-2 inches deep'),(2,'What are good maintenance routines that should be performed on a concert snare?','Change the heads regularly and check the snares','Change the shell regularly','Change the tension regularly','Change the counter hoop'),(3,'Which is the recommended beating area on a snare drum?','Just off the center of the drum','At the exact center of the drum','Closest to the edge of the drum','In the snare head'),(4,'What is the best place on the bar to play most keyboard percussion instruments? ','In the center of the bar or on the edge.','Directly above the string','On the nodal spot','On the outside edge of the bar'),(5,'What can you do to keep your keyboard instruments in their best shape?','Putting a cover, cleaning dust and checking the strings','Never putting a cover on the instruments because of moisture','Putting books on top of the keyboard to keep it \"balanced\"','Using floor wax to clean the keyboard, once a month'),(6,'What do you use to play the keyboard instruments?','Mallets','Drumsticks','Iron ramrod','Hands'),(7,'Which is not one of the pedal systems found in timpani?','Davidson system','Balanced actions pedals','Dresden system','Ball lock system'),(8,'Which are the most common sizes of timpani?','32, 29, 26, 23 inches','30, 27, 24, 21 inches','33, 30, 27, 24 inches','32, 28, 24, 22 inches'),(9,'Which one is not one a common grip for timpani playing?','Italian grip','German grip','American grip','French grip'),(10,'What is a typical size for a good concert bass drum?',' 26 - 36 inches deep shell','32 - 40 inches deep shell','18- 24 inches deep shell','38 - 42 inches deep shell'),(11,'What is the best general beating area on the concert bass drum?','Just off the center of the head','Directly in the center of the head','2 inches off the edge','4 inches off the edge'),(12,'Name the regular maintenance routines that should be performed on a concert bass drum.','Check heads regularly for dents or holes and replace them','Wax the drum weekly','Check for holes and use duct tape to fix them','Do a \"sand massage\" for the drum on a monthly basis'),(13,'What is the typical size of a concert tambourine?','10 inches',' 8 inches','12 inches','15 inches'),(14,'What does PAS mean?','Percussion Arts Society','Peace American Society','Poland Association Society','Percussion American Service'),(15,'Which of the next materials a tambourine shell can be made of?','Wood','Bronze','Glass','Silver'),(16,'What do you use to play a tambourine?','Your hands','Mallets','Drumsticks','A pedal'),(17,'What is a good general size for crash cymbals?','18 inches','10 inches','26 inches','14 inches'),(18,'What is the best type of strap for a cymbal??',' Leather cymbal straps','Rope cymbal straps','Wooden cymbal holders','Nylon cymbal straps'),(19,'How is the volume of the cymbals controlled?','The volume is determined by how fast the cymbals come together','The volume is determined by how far apart the cymbals are','The volume is determined by the grip','There is no way to control volume'),(20,'What is the typical size for a concert triangle?',' 6 to 9 inches','5 inches','2 to 12 inches','10 to 12 inches'),(21,'When selecting a triangle, which characteristic is most important?','There should be a wide range of overtones and no distinct pitch','There should be a distinct pitch','The silver should be highly polished','The silver should not be polished'),(22,'How many loops are recommended for the string in the clip that holds the triangle?','Two loops','One loop','Six loops','The clip does not require string loops'),(23,'What is the difference between a gong and a tam-tam?','A gong has a definite pitch and a tam-tam does not','A gong is the mini version of a tam-tam','A tam-tam is the mini version of the gong','A tam-tam has a definite pitch and a gong does not'),(24,'When selecting a tam-tam, what should you look for?','A good tam-tam will produce a long, low sustained sound','The size should be 10-12 inches','A good tam-tam will produce a long, high sustained sound','A good tam-tam will produce a short, low sound'),(25,'Which is the best general area to play the tam-tam?','Just off the center','Directly in the center','On the edge','Just off the edge'),(26,'Synthetic or plastic blocks are a great substitute for wood blocks','No','Only when the plastic is polished','Yes','Synthetic blocks are actually better than wooden blocks'),(27,'When playing the woodblock, the slit should be facing…','Towards the audience','Towards the player','Towards the floor','Towards the ceiling'),(28,'What is the best general area to play the wood blocks?','Towards the center','Just off the edge','On the exact edge','There is no sweet spot'),(29,'Why is a timpani mallet not always the best choice for striking a suspended cymbal?','A timpani mallet is not heavy enough to activate the whole cymbal','The core is too soft to produce good sound','The cymbal will cause excessive wear on the soft felt','The mallet is too thin, so it might break'),(30,'What is the best way to muffle a cymbal?','By grabbing it with your hand','Using a towel','Using a clamp','The cymbal should not be muffled'),(31,'What do you use to clean your cymbal?','Cymbal cleaners','A metal sponge','Brass polish','Microfiber cloth');
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

-- Dump completed on 2022-05-03 23:37:13
