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
  `Discount` decimal(19,3) DEFAULT NULL,
  `Paid` decimal(10,0) NOT NULL,
  `Changes` decimal(10,0) NOT NULL DEFAULT '0',
  `InvoiceDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `PaidDate` datetime DEFAULT NULL,
  `Paidwith` varchar(45) DEFAULT NULL,
  `month` int NOT NULL,
  `year` int NOT NULL,
  `InvoiceOfficer` bigint NOT NULL,
  `PaidOfficer` bigint DEFAULT NULL,
  `TransactionId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Invoice_officer_idx` (`InvoiceOfficer`),
  CONSTRAINT `Invoice_officer` FOREIGN KEY (`InvoiceOfficer`) REFERENCES `officer` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  `Postition` int DEFAULT '0',
  `Salary` decimal(19,2) NOT NULL DEFAULT '15000.00',
  `Registerd` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Expired` tinyint(1) NOT NULL DEFAULT '0',
  `Img` longblob,
  `Issuper` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `officer_postition_idx` (`Postition`),
  CONSTRAINT `officer_postition` FOREIGN KEY (`Postition`) REFERENCES `postition` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
  `Enabled` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `Room_Building_idx` (`Building`),
  CONSTRAINT `Room_Building` FOREIGN KEY (`Building`) REFERENCES `buildings` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-06 12:40:39
