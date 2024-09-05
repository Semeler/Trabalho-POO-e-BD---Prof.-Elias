-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gestao_financeira_semeler
-- ------------------------------------------------------
-- Server version	8.0.39

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
-- Table structure for table `vendaservico`
--

DROP TABLE IF EXISTS `vendaservico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendaservico` (
  `idVendaServico` int NOT NULL,
  `valorunitario` decimal(10,0) DEFAULT NULL,
  `quantidade` int DEFAULT NULL,
  `fk_id_servico` int DEFAULT NULL,
  `fk_id_venda` int DEFAULT NULL,
  PRIMARY KEY (`idVendaServico`),
  KEY `fk_id_servico` (`fk_id_servico`),
  KEY `fk_id_venda` (`fk_id_venda`),
  CONSTRAINT `vendaservico_ibfk_1` FOREIGN KEY (`fk_id_servico`) REFERENCES `servico` (`idServico`),
  CONSTRAINT `vendaservico_ibfk_2` FOREIGN KEY (`fk_id_venda`) REFERENCES `venda` (`idVenda`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendaservico`
--

LOCK TABLES `vendaservico` WRITE;
/*!40000 ALTER TABLE `vendaservico` DISABLE KEYS */;
INSERT INTO `vendaservico` VALUES (1,10,2,1,2),(2,110,7,6,10),(3,80,3,4,12),(4,95,2,3,13),(5,25,5,2,14);
/*!40000 ALTER TABLE `vendaservico` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-05  8:49:56
