-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: dorm
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
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bank` (
  `Id` int NOT NULL,
  `Name` varchar(90) NOT NULL,
  `ShortName` varchar(45) DEFAULT NULL,
  `SwiftCode` varchar(45) DEFAULT NULL,
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
  `Location` varchar(90) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
  `Stayed` datetime NOT NULL,
  `Address` varchar(90) DEFAULT NULL,
  `Rental` decimal(10,0) NOT NULL,
  `ContractDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `StayUntil` datetime DEFAULT NULL,
  `Booking` tinyint(1) NOT NULL DEFAULT '0',
  `BookingFee` decimal(10,0) NOT NULL DEFAULT '0',
  `ContractFee` decimal(10,0) NOT NULL DEFAULT '0',
  `DamageInsurance` decimal(10,0) NOT NULL DEFAULT '0',
  `RentalType` varchar(45) NOT NULL,
  `EmployeeId` bigint NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
  `InvoiceId` varchar(90) DEFAULT NULL,
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
  `IsService` tinyint(1) NOT NULL DEFAULT '0',
  `Service` bigint DEFAULT NULL,
  `ServicePrice` decimal(10,0) NOT NULL DEFAULT '0',
  `Iscancel` tinyint(1) NOT NULL DEFAULT '0',
  `Ispaid` tinyint(1) NOT NULL DEFAULT '0',
  `Tax` decimal(10,0) NOT NULL DEFAULT '0',
  `RentalPrice` decimal(10,0) NOT NULL DEFAULT '0',
  `Slip` longblob,
  `Slipname` mediumtext,
  `SlipType` varchar(45) DEFAULT NULL,
  `CancellationComment` longtext,
  PRIMARY KEY (`Id`),
  KEY `Invoice_officer_idx` (`InvoiceOfficer`),
  CONSTRAINT `Invoice_officer` FOREIGN KEY (`InvoiceOfficer`) REFERENCES `officer` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `invoiceservice`
--

DROP TABLE IF EXISTS `invoiceservice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoiceservice` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `InvoiceId` varchar(90) NOT NULL,
  `ServiceId` bigint DEFAULT NULL,
  `Price` decimal(10,0) NOT NULL DEFAULT '0',
  `OtherService` tinyint(1) NOT NULL DEFAULT '0',
  `Specifiy` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `InvoiceService_Service_idx` (`ServiceId`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `member` (
  `MemberId` bigint NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(90) NOT NULL,
  `Surname` varchar(90) NOT NULL,
  `Prefix` varchar(45) NOT NULL,
  `SocialId` varchar(45) DEFAULT NULL,
  `SocialType` varchar(45) DEFAULT NULL,
  `Tel` int NOT NULL,
  PRIMARY KEY (`MemberId`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `myservices`
--

DROP TABLE IF EXISTS `myservices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `myservices` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` longtext NOT NULL,
  `Price` decimal(10,0) NOT NULL DEFAULT '0',
  `Enabled` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
  `remark` mediumtext,
  `expiredDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `officer_postition_idx` (`Postition`),
  CONSTRAINT `officer_postition` FOREIGN KEY (`Postition`) REFERENCES `postition` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
  `Stayed` datetime DEFAULT NULL,
  `Address` varchar(90) DEFAULT NULL,
  `Rental` decimal(10,0) NOT NULL,
  `ContractDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `StayUntil` datetime DEFAULT NULL,
  `Deposit` decimal(10,0) NOT NULL DEFAULT '0',
  `Refunded` tinyint(1) NOT NULL DEFAULT '0',
  `DamageFee` decimal(10,0) NOT NULL DEFAULT '0',
  `Comments` longtext,
  `IsStayed` tinyint(1) NOT NULL DEFAULT '1',
  `RentalType` varchar(45) NOT NULL,
  `EmployeeId` bigint NOT NULL,
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
  `Next` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `postition_Department_idx` (`Department`),
  KEY `Postition_Line_idx` (`Line`),
  CONSTRAINT `postition_Department` FOREIGN KEY (`Department`) REFERENCES `department` (`Id`),
  CONSTRAINT `Postition_Line` FOREIGN KEY (`Line`) REFERENCES `postitionline` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `postitionchanged`
--

DROP TABLE IF EXISTS `postitionchanged`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `postitionchanged` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `officerId` bigint NOT NULL,
  `OldPostition` int NOT NULL,
  `OldSalary` decimal(10,0) NOT NULL,
  `NewPostition` int NOT NULL,
  `NewSalary` decimal(10,0) NOT NULL,
  `Remark` varchar(255) NOT NULL,
  `Date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
-- Table structure for table `rentalaccount`
--

DROP TABLE IF EXISTS `rentalaccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rentalaccount` (
  `RentalId` varchar(90) NOT NULL,
  `Bank` varchar(45) NOT NULL,
  `AccountId` bigint NOT NULL,
  `AccountName` varchar(90) NOT NULL,
  `Specify` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`RentalId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `rentalmember`
--

DROP TABLE IF EXISTS `rentalmember`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rentalmember` (
  `RentalId` varchar(90) NOT NULL,
  `MemberId` bigint NOT NULL,
  `IsMain` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`RentalId`,`MemberId`)
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
  UNIQUE KEY `RoomName_UNIQUE` (`RoomName`),
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
  `Attr01` varchar(90) DEFAULT NULL,
  `Attr02` varchar(90) DEFAULT NULL,
  `Attr03` varchar(90) DEFAULT NULL,
  `Attr04` varchar(90) DEFAULT NULL,
  `Attr05` varchar(90) DEFAULT NULL,
  `Attr06` varchar(90) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoomFurns_idx` (`RoomId`),
  CONSTRAINT `RoomFurns` FOREIGN KEY (`RoomId`) REFERENCES `room` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roomfurnheader`
--

DROP TABLE IF EXISTS `roomfurnheader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomfurnheader` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Type` varchar(90) NOT NULL,
  `Header` varchar(45) DEFAULT NULL,
  `Description` varchar(90) DEFAULT NULL,
  `CustomValue` tinyint(1) NOT NULL,
  `ValueType` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roomfurnheadervalues`
--

DROP TABLE IF EXISTS `roomfurnheadervalues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomfurnheadervalues` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `HeaderId` bigint NOT NULL,
  `Value` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roomfurntemplate`
--

DROP TABLE IF EXISTS `roomfurntemplate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomfurntemplate` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `TemplateId` int NOT NULL,
  `Name` varchar(90) NOT NULL,
  `Type` varchar(90) NOT NULL,
  `Price` decimal(19,2) NOT NULL,
  `Model` varchar(90) DEFAULT NULL,
  `Attr01` varchar(90) DEFAULT NULL,
  `Attr02` varchar(90) DEFAULT NULL,
  `Attr03` varchar(90) DEFAULT NULL,
  `Attr04` varchar(90) DEFAULT NULL,
  `Attr05` varchar(90) DEFAULT NULL,
  `Attr06` varchar(90) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoomFurnsTmp_idx` (`TemplateId`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roomtemplate`
--

DROP TABLE IF EXISTS `roomtemplate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomtemplate` (
  `Id` int NOT NULL,
  `TemplateName` varchar(45) DEFAULT NULL,
  `Size` decimal(19,2) DEFAULT NULL,
  `Aircond` tinyint(1) NOT NULL DEFAULT '1',
  `WaterHeater` tinyint(1) NOT NULL DEFAULT '1',
  `TV` tinyint(1) NOT NULL DEFAULT '1',
  `Fan` tinyint(1) NOT NULL DEFAULT '0',
  `Rental` decimal(19,2) NOT NULL DEFAULT '3500.00',
  `Furniture` tinyint(1) NOT NULL DEFAULT '1',
  `Fridge` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoomName_UNIQUE` (`TemplateName`)
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
  PRIMARY KEY (`Id`),
  KEY `Login_Time` (`LoggedIn` DESC)
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
  `InvoiceId` varchar(90) DEFAULT NULL,
  PRIMARY KEY (`month`,`RentalId`,`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

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
/*!50003 DROP PROCEDURE IF EXISTS `sp_Expiredofficer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Expiredofficer`(officerId bigint,rmk mediumtext)
BEGIN
update officer set Expired=1,remark=rmk,expiredDate=current_timestamp() where Id=officerId;
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
/*!50003 DROP PROCEDURE IF EXISTS `sp_restoreofficer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_restoreofficer`(officerId bigint,resetdate tinyint(1))
BEGIN
update officer set Expired=0,remark=null,expiredDate=null where Id=officerId;
if resetdate = 1
then 
update officer set Registerd=current_timestamp() where Id=officerId;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SaveTemplate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_SaveTemplate`(rid int, roomName varchar(45))
BEGIN
declare itemId int ;
set itemId= (select case when count(Id) > 0 then 1+max(Id) else 1 end from roomTemplate);
start transaction;
insert into roomtemplate (Id,`TemplateName`,`Size`,`Aircond`,`WaterHeater`,`TV`,`Fan`,`Rental`,`Furniture`,`Fridge`)
select itemId,roomName,Size,Aircond,WaterHeater,TV,Fan,Rental,Furniture,Fridge from room where id=rid;
insert into roomfurntemplate(`TemplateId`,`Name`,`Type`,`Price`,`Model`,`Attr01`,`Attr02`,`Attr03`,`Attr04`,`Attr05`,`Attr06`)
select itemId,Name,Type,Price,Model,Attr01,Attr02,Attr03,Attr04,Attr05,Attr06 from roomfurn where RoomId=rid;
commit;
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
/*!50003 DROP PROCEDURE IF EXISTS `sp_upgradepostition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_upgradepostition`(empId bigint,newpost int ,newsalary decimal)
BEGIN
declare oldp int;
declare olds decimal;
declare rmk varchar(255);
set oldp = (select Postition from officer where id=empId);
set olds = (select salary from officer where id=empId);
set rmk = (select case 
when oldp<>newpost then'Position Upgrade'
else 'Salary Upgrade' end);
start transaction;
insert into postitionchanged(officerId,OldPostition,OldSalary,NewPostition,NewSalary,Remark)
value(empId,oldp,olds,newpost,newsalary,rmk);
update officer set Postition=newpost,Salary=newsalary where Id=empId;
commit;
select 1;
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

-- Dump completed on 2022-04-21 18:17:27
