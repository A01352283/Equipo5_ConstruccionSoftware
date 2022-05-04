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
-- Temporary view structure for view `top_rhythm_scores`
--

DROP TABLE IF EXISTS `top_rhythm_scores`;
/*!50001 DROP VIEW IF EXISTS `top_rhythm_scores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_rhythm_scores` AS SELECT 
 1 AS `user_name`,
 1 AS `rhythm_best_score`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `top_trivia_scores`
--

DROP TABLE IF EXISTS `top_trivia_scores`;
/*!50001 DROP VIEW IF EXISTS `top_trivia_scores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_trivia_scores` AS SELECT 
 1 AS `user_name`,
 1 AS `trivia_best_score`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `top_memory_scores`
--

DROP TABLE IF EXISTS `top_memory_scores`;
/*!50001 DROP VIEW IF EXISTS `top_memory_scores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_memory_scores` AS SELECT 
 1 AS `user_name`,
 1 AS `memory_best_score`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `top_memorysounds_scores`
--

DROP TABLE IF EXISTS `top_memorysounds_scores`;
/*!50001 DROP VIEW IF EXISTS `top_memorysounds_scores`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `top_memorysounds_scores` AS SELECT 
 1 AS `user_name`,
 1 AS `memorysounds_best_score`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_play_time`
--

DROP TABLE IF EXISTS `total_play_time`;
/*!50001 DROP VIEW IF EXISTS `total_play_time`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `total_play_time` AS SELECT 
 1 AS `total_memory_play_time`,
 1 AS `total_trivia_play_time`,
 1 AS `total_memorysounds_play_time`,
 1 AS `total_rhythm_play_time`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `top_rhythm_scores`
--

/*!50001 DROP VIEW IF EXISTS `top_rhythm_scores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_rhythm_scores` AS select `gu`.`user_name` AS `user_name`,`gs`.`rhythm_best_score` AS `rhythm_best_score` from (`game_user_scores` `gs` join `game_user` `gu` on((`gs`.`user_id` = `gu`.`user_id`))) order by `gs`.`rhythm_best_score` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `top_trivia_scores`
--

/*!50001 DROP VIEW IF EXISTS `top_trivia_scores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_trivia_scores` AS select `gu`.`user_name` AS `user_name`,`gs`.`trivia_best_score` AS `trivia_best_score` from (`game_user_scores` `gs` join `game_user` `gu` on((`gs`.`user_id` = `gu`.`user_id`))) order by `gs`.`trivia_best_score` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `top_memory_scores`
--

/*!50001 DROP VIEW IF EXISTS `top_memory_scores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_memory_scores` AS select `gu`.`user_name` AS `user_name`,`gs`.`memory_best_score` AS `memory_best_score` from (`game_user_scores` `gs` join `game_user` `gu` on((`gs`.`user_id` = `gu`.`user_id`))) order by `gs`.`memory_best_score` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `top_memorysounds_scores`
--

/*!50001 DROP VIEW IF EXISTS `top_memorysounds_scores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `top_memorysounds_scores` AS select `gu`.`user_name` AS `user_name`,`gs`.`memorysounds_best_score` AS `memorysounds_best_score` from (`game_user_scores` `gs` join `game_user` `gu` on((`gs`.`user_id` = `gu`.`user_id`))) order by `gs`.`memorysounds_best_score` desc limit 10 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_play_time`
--

/*!50001 DROP VIEW IF EXISTS `total_play_time`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `total_play_time` AS select sec_to_time(sum(`game_user_scores`.`memory_play_time`)) AS `total_memory_play_time`,sec_to_time(sum(`game_user_scores`.`trivia_play_time`)) AS `total_trivia_play_time`,sec_to_time(sum(`game_user_scores`.`memorysounds_play_time`)) AS `total_memorysounds_play_time`,sec_to_time(sum(`game_user_scores`.`rhythm_play_time`)) AS `total_rhythm_play_time` from `game_user_scores` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Dumping events for database 'percussion_island3'
--

--
-- Dumping routines for database 'percussion_island3'
--
/*!50003 DROP PROCEDURE IF EXISTS `get_user_id` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_user_id`(in user_n VARCHAR(45))
BEGIN
SELECT user_id 
FROM game_user where user_name = user_n;
END ;;
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
