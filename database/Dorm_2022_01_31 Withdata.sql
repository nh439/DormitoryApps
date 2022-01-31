-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: dorm
-- ------------------------------------------------------
-- Server version	8.0.26

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
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `Id` varchar(90) NOT NULL,
  `etc` varchar(45) NOT NULL,
  `Moo` int NOT NULL DEFAULT '0',
  `Subdistrict` varchar(45) NOT NULL,
  `District` varchar(45) NOT NULL,
  `Province` varchar(45) NOT NULL,
  `PostalCode` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES ('689fa387-10a8-450a-ae8c-f7eb20b2b8aa','115/87',1,'ท่าสองยาง','ท่าสองยาง','ตาก',63150),('c4bb624a-0007-4c73-85dc-4442b7c5056c','115/87',2,'แม่ท้อ','เมืองตาก','ตาก',63000);
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `buildings`
--

DROP TABLE IF EXISTS `buildings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buildings` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Location` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buildings`
--

LOCK TABLES `buildings` WRITE;
/*!40000 ALTER TABLE `buildings` DISABLE KEYS */;
/*!40000 ALTER TABLE `buildings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currentcustomer`
--

DROP TABLE IF EXISTS `currentcustomer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `currentcustomer` (
  `Id` varchar(90) NOT NULL,
  `RoomId` int DEFAULT NULL,
  `Firstname` varchar(90) NOT NULL,
  `Surname` varchar(90) NOT NULL,
  `Stayed` datetime NOT NULL,
  `IsMain` tinyint(1) NOT NULL DEFAULT '1',
  `Address` varchar(90) DEFAULT NULL,
  `Rental` decimal(10,0) NOT NULL,
  `ContractDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `Cust_room_idx` (`RoomId`),
  CONSTRAINT `Cust_room` FOREIGN KEY (`RoomId`) REFERENCES `room` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currentcustomer`
--

LOCK TABLES `currentcustomer` WRITE;
/*!40000 ALTER TABLE `currentcustomer` DISABLE KEYS */;
/*!40000 ALTER TABLE `currentcustomer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerimg`
--

DROP TABLE IF EXISTS `customerimg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerimg` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `RentalId` varchar(90) NOT NULL,
  `Filename` varchar(90) NOT NULL,
  `Filetype` varchar(45) NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Img` longblob NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerimg`
--

LOCK TABLES `customerimg` WRITE;
/*!40000 ALTER TABLE `customerimg` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerimg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(90) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (2,'IT '),(6,'ความปลอดภัย'),(8,'จัดซื้ออุปกรณ์'),(5,'ซ่อมบำรุง'),(4,'ดูแลลูกค้า'),(3,'ทำความสะอาด'),(1,'บริหาร'),(7,'บัญชี');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `electricity`
--

DROP TABLE IF EXISTS `electricity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `electricity` (
  `RentalId` varchar(90) NOT NULL,
  `month` int NOT NULL,
  `Year` int NOT NULL,
  `BeforeUnit` decimal(10,0) NOT NULL,
  `CurrentUnit` decimal(10,0) NOT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Total` decimal(10,0) NOT NULL,
  `Notedate` datetime NOT NULL,
  `Paid` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`month`,`RentalId`,`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `electricity`
--

LOCK TABLES `electricity` WRITE;
/*!40000 ALTER TABLE `electricity` DISABLE KEYS */;
/*!40000 ALTER TABLE `electricity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice` (
  `Id` varchar(90) NOT NULL,
  `RentalId` varchar(90) NOT NULL,
  `GrandTotal` decimal(10,0) NOT NULL,
  `Fee` decimal(10,0) DEFAULT NULL,
  `Paid` decimal(10,0) NOT NULL,
  `Changes` decimal(10,0) NOT NULL DEFAULT '0',
  `InvoiceDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `PaidDate` datetime DEFAULT NULL,
  `Paidwith` varchar(45) DEFAULT NULL,
  `month` int NOT NULL,
  `year` int NOT NULL,
  `InvoiceOfficer` bigint NOT NULL,
  `PaidOfficer` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Invoice_officer_idx` (`InvoiceOfficer`),
  CONSTRAINT `Invoice_officer` FOREIGN KEY (`InvoiceOfficer`) REFERENCES `officer` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `officer`
--

DROP TABLE IF EXISTS `officer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `officer` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Username` varchar(90) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Idx` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Prefix` varchar(45) NOT NULL,
  `Firstname` varchar(90) NOT NULL,
  `Surname` varchar(90) NOT NULL,
  `Brithday` datetime NOT NULL,
  `Address` varchar(90) NOT NULL,
  `Gender` tinyint(1) DEFAULT '0',
  `Postition` int NOT NULL DEFAULT '0',
  `Salary` decimal(19,2) NOT NULL DEFAULT '15000.00',
  `Registerd` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Expired` tinyint(1) NOT NULL DEFAULT '0',
  `Img` longblob,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `officer_postition_idx` (`Postition`),
  CONSTRAINT `officer_postition` FOREIGN KEY (`Postition`) REFERENCES `postition` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `officer`
--

LOCK TABLES `officer` WRITE;
/*!40000 ALTER TABLE `officer` DISABLE KEYS */;
INSERT INTO `officer` VALUES (1,'User01','l0oEuOdHhLKU5eGpbhrvBitipME0o9Vu','xznSHzBu6TB7d+DWTDFeRiKaNaOvZhgf','AB@av.com','นาย','AAAA','BBBB','1997-01-29 00:00:00','689fa387-10a8-450a-ae8c-f7eb20b2b8aa',1,1,18000.00,'2022-01-27 22:14:00',0,NULL),(2,'User02','9NWNqlNZ2uun9+RTHFKyOU9+6TXXuNkD','oIvkDeAEtZMNxAAKy2kDHWU6qSxVO7mp','AD@SD.com','นางสาว','AAA','GGG','1998-01-27 23:30:55','c4bb624a-0007-4c73-85dc-4442b7c5056c',1,1,15000.00,'2022-01-27 23:32:03',0,NULL);
/*!40000 ALTER TABLE `officer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pastcustomer`
--

DROP TABLE IF EXISTS `pastcustomer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pastcustomer` (
  `Id` varchar(90) NOT NULL,
  `RoomId` int DEFAULT NULL,
  `Firstname` varchar(90) NOT NULL,
  `Surname` varchar(90) NOT NULL,
  `Stayed` datetime NOT NULL,
  `IsMain` tinyint(1) NOT NULL DEFAULT '1',
  `Address` varchar(90) DEFAULT NULL,
  `Rental` decimal(10,0) NOT NULL,
  `ContractDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `StayUntil` datetime DEFAULT NULL,
  `Deposit` decimal(10,0) NOT NULL DEFAULT '0',
  `Refunded` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Cust_room_idx` (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pastcustomer`
--

LOCK TABLES `pastcustomer` WRITE;
/*!40000 ALTER TABLE `pastcustomer` DISABLE KEYS */;
/*!40000 ALTER TABLE `pastcustomer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postition`
--

DROP TABLE IF EXISTS `postition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `postition` (
  `Id` int NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Level` int NOT NULL,
  `Salary` decimal(19,2) NOT NULL,
  `Department` int NOT NULL,
  `Line` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `postition_Department_idx` (`Department`),
  KEY `Postition_Line_idx` (`Line`),
  CONSTRAINT `postition_Department` FOREIGN KEY (`Department`) REFERENCES `department` (`Id`),
  CONSTRAINT `Postition_Line` FOREIGN KEY (`Line`) REFERENCES `postitionline` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postition`
--

LOCK TABLES `postition` WRITE;
/*!40000 ALTER TABLE `postition` DISABLE KEYS */;
INSERT INTO `postition` VALUES (1,'P1',1,15000.00,1,1),(2,'S1',1,17000.00,2,2);
/*!40000 ALTER TABLE `postition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postitionline`
--

DROP TABLE IF EXISTS `postitionline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `postitionline` (
  `Id` int NOT NULL,
  `Name` varchar(90) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postitionline`
--

LOCK TABLES `postitionline` WRITE;
/*!40000 ALTER TABLE `postitionline` DISABLE KEYS */;
INSERT INTO `postitionline` VALUES (3,'Admin'),(1,'IT Support'),(4,'งานห้อง'),(2,'บัญชี');
/*!40000 ALTER TABLE `postitionline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `room`
--

DROP TABLE IF EXISTS `room`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `room` (
  `Id` int NOT NULL,
  `RoomName` varchar(45) DEFAULT NULL,
  `Floor` int NOT NULL,
  `Size` decimal(19,2) DEFAULT NULL,
  `Building` int DEFAULT NULL,
  `Aircond` tinyint(1) NOT NULL DEFAULT '1',
  `WaterHeater` tinyint(1) NOT NULL DEFAULT '1',
  `TV` tinyint(1) NOT NULL DEFAULT '1',
  `Fan` tinyint(1) NOT NULL DEFAULT '0',
  `Rental` decimal(19,2) NOT NULL DEFAULT '3500.00',
  `Furniture` tinyint(1) NOT NULL DEFAULT '1',
  `Fridge` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Room_Building_idx` (`Building`),
  CONSTRAINT `Room_Building` FOREIGN KEY (`Building`) REFERENCES `buildings` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room`
--

LOCK TABLES `room` WRITE;
/*!40000 ALTER TABLE `room` DISABLE KEYS */;
/*!40000 ALTER TABLE `room` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomfurn`
--

DROP TABLE IF EXISTS `roomfurn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomfurn` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `RoomId` int NOT NULL,
  `Name` varchar(90) NOT NULL,
  `Type` varchar(90) NOT NULL,
  `Price` decimal(19,2) NOT NULL,
  `Model` varchar(90) DEFAULT NULL,
  `Attr01` varchar(45) DEFAULT NULL,
  `Attr02` varchar(45) DEFAULT NULL,
  `Attr03` varchar(45) DEFAULT NULL,
  `Attr04` varchar(45) DEFAULT NULL,
  `Attr05` varchar(45) DEFAULT NULL,
  `Attr06` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoomFurns_idx` (`RoomId`),
  CONSTRAINT `RoomFurns` FOREIGN KEY (`RoomId`) REFERENCES `room` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomfurn`
--

LOCK TABLES `roomfurn` WRITE;
/*!40000 ALTER TABLE `roomfurn` DISABLE KEYS */;
/*!40000 ALTER TABLE `roomfurn` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomimg`
--

DROP TABLE IF EXISTS `roomimg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomimg` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `RoomId` int NOT NULL,
  `FileName` varchar(90) NOT NULL,
  `FileType` varchar(90) NOT NULL,
  `Size` bigint NOT NULL,
  `Img` longblob NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Room_Img_idx` (`RoomId`),
  CONSTRAINT `Room_Img` FOREIGN KEY (`RoomId`) REFERENCES `room` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomimg`
--

LOCK TABLES `roomimg` WRITE;
/*!40000 ALTER TABLE `roomimg` DISABLE KEYS */;
/*!40000 ALTER TABLE `roomimg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `session`
--

DROP TABLE IF EXISTS `session`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `session` (
  `Id` varchar(255) NOT NULL,
  `UserId` bigint NOT NULL,
  `LoggedIn` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LoggOut` datetime DEFAULT NULL,
  `Isloggout` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `session`
--

LOCK TABLES `session` WRITE;
/*!40000 ALTER TABLE `session` DISABLE KEYS */;
INSERT INTO `session` VALUES ('2e5cfdfb-8040-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:42:48',NULL,0),('3c6cb612-803f-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:36:02','2022-01-28 20:36:39',1),('538353a5-8040-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:43:50','2022-01-28 20:46:14',1),('5525e355-80c4-11ec-8df6-7085c20e5ea5',1,'2022-01-29 12:28:47','2022-01-29 12:28:54',1),('5635dde8-81b8-11ec-8df6-7085c20e5ea5',1,'2022-01-30 17:35:26','2022-01-30 17:36:29',1),('6344c041-81da-11ec-8df6-7085c20e5ea5',1,'2022-01-30 21:39:10',NULL,0),('64ecf061-81d9-11ec-8df6-7085c20e5ea5',1,'2022-01-30 21:32:04',NULL,0),('740f911d-8040-11ec-8df6-7085c20e5ea5',2,'2022-01-28 20:44:45','2022-01-28 20:46:03',1),('8149846c-800d-11ec-8df6-7085c20e5ea5',1,'2022-01-28 14:40:03',NULL,0),('a8fa9757-803e-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:31:55',NULL,0),('d846c892-803d-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:26:05',NULL,0),('e3ee2c01-81d9-11ec-8df6-7085c20e5ea5',1,'2022-01-30 21:35:37',NULL,0),('ed655b02-802d-11ec-8df6-7085c20e5ea5',1,'2022-01-28 18:32:08',NULL,0),('efa7f016-803f-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:41:03','2022-01-28 20:41:30',1),('f34d97a1-803e-11ec-8df6-7085c20e5ea5',1,'2022-01-28 20:33:59','2022-01-28 20:34:29',1);
/*!40000 ALTER TABLE `session` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `water`
--

DROP TABLE IF EXISTS `water`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `water` (
  `RentalId` varchar(90) NOT NULL,
  `month` int NOT NULL,
  `Year` int NOT NULL,
  `BeforeUnit` decimal(10,0) NOT NULL,
  `CurrentUnit` decimal(10,0) NOT NULL,
  `Price` decimal(10,0) NOT NULL,
  `Total` decimal(10,0) NOT NULL,
  `Notedate` datetime NOT NULL,
  `Paid` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`month`,`RentalId`,`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `water`
--

LOCK TABLES `water` WRITE;
/*!40000 ALTER TABLE `water` DISABLE KEYS */;
/*!40000 ALTER TABLE `water` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'dorm'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_callsalt` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_callsalt`(name varchar(255) )
BEGIN
select Idx from officer where Username=name or Email=name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_createSession` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_createSession`(Id bigint)
BEGIN
declare Sid varchar(255);
set Sid = (select uuid());
insert into session(Id,UserId) values(Sid,Id);
select Sid as SessionId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ForcedLogout` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ForcedLogout`(Id bigint)
BEGIN
update Session set LoggOut=current_timestamp(),Isloggout=1 where UserId=1 and Isloggout=0;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getcurrentuser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getcurrentuser`(sessionId varchar(255))
BEGIN
select * from officer where Id=(select userId from session where Id=sessionId and Isloggout=0);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_login` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login`(uname varchar(255),pwd varchar(255))
BEGIN
declare cnt int;
set cnt =
(select count(*) from officer where (Username=uname or email = username=uname) and Password=pwd);
select cnt as count;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_setLogout` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_setLogout`(Sid varchar(255))
BEGIN
update Session set LoggOut=current_timestamp(),Isloggout=1 where Id=Sid;
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

-- Dump completed on 2022-01-31 15:26:20
