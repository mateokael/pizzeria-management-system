-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: pizzeria_db
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

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
-- Table structure for table `batch_adjustments`
--

DROP TABLE IF EXISTS `batch_adjustments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `batch_adjustments` (
  `AdjustmentID` int(11) NOT NULL AUTO_INCREMENT,
  `BatchID` int(11) NOT NULL,
  `ActionType` varchar(20) NOT NULL,
  `OldRemainingQty` int(11) DEFAULT NULL,
  `NewRemainingQty` int(11) DEFAULT NULL,
  `OldCostPerUnit` decimal(10,2) DEFAULT NULL,
  `NewCostPerUnit` decimal(10,2) DEFAULT NULL,
  `OldExpiryDate` date DEFAULT NULL,
  `NewExpiryDate` date DEFAULT NULL,
  `Reason` varchar(50) NOT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `AdjustedDate` datetime NOT NULL,
  PRIMARY KEY (`AdjustmentID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batch_adjustments`
--

LOCK TABLES `batch_adjustments` WRITE;
/*!40000 ALTER TABLE `batch_adjustments` DISABLE KEYS */;
INSERT INTO `batch_adjustments` VALUES (1,57,'Delete',500,0,0.02,0.02,'2026-07-13','2026-07-13','Wrong Entry',NULL,'2026-07-12 19:40:30'),(2,58,'Update',1000,999,0.20,0.20,'2026-07-13','2026-07-13','Wrong Entry',NULL,'2026-07-12 19:48:09'),(3,58,'Update',999,999,0.20,0.22,'2026-07-13','2026-07-13','Wrong Entry',NULL,'2026-07-12 19:48:14'),(4,58,'Update',999,999,0.22,0.22,'2026-07-13','2026-09-01','Wrong Entry',NULL,'2026-07-12 19:48:22'),(5,58,'Update',999,997,0.22,0.22,'2026-09-01','2026-09-01','Wrong Entry',NULL,'2026-07-13 12:29:29');
/*!40000 ALTER TABLE `batch_adjustments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(50) NOT NULL,
  PRIMARY KEY (`CategoryID`),
  UNIQUE KEY `CategoryName` (`CategoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (3,'Drinks'),(1,'Pizza'),(2,'Side Dish');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credentials`
--

DROP TABLE IF EXISTS `credentials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credentials` (
  `EmployeeID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`EmployeeID`),
  UNIQUE KEY `uq_credentials_username` (`Username`),
  CONSTRAINT `fk_credentials_employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credentials`
--

LOCK TABLES `credentials` WRITE;
/*!40000 ALTER TABLE `credentials` DISABLE KEYS */;
INSERT INTO `credentials` VALUES (1,'admin','godisgood09453020789'),(7,'cashier','123');
/*!40000 ALTER TABLE `credentials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `ContactNo` varchar(20) DEFAULT NULL,
  `DateAdded` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Lance',NULL,'0908780890','2026-07-12 17:38:07'),(2,'Caro',NULL,NULL,'2026-07-12 17:40:11'),(3,'Ian',NULL,NULL,'2026-07-12 17:41:26'),(4,'Rod',NULL,NULL,'2026-07-12 17:41:57'),(5,'a',NULL,NULL,'2026-07-12 18:32:15'),(6,'testt',NULL,NULL,'2026-07-12 18:35:44'),(7,'lan',NULL,NULL,'2026-07-12 19:09:17'),(8,'last',NULL,NULL,'2026-07-12 19:16:34'),(9,'test2',NULL,NULL,'2026-07-12 19:20:30'),(10,'testcustomer',NULL,NULL,'2026-07-12 19:40:54'),(11,'Rene','Barca','09522463569','2026-07-13 00:14:43');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `EmployeeID` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `ContactNo` varchar(20) DEFAULT NULL,
  `PositionID` int(11) NOT NULL,
  `DateHired` date DEFAULT NULL,
  `Status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `DateAdded` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`EmployeeID`),
  KEY `fk_employees_position` (`PositionID`),
  CONSTRAINT `fk_employees_position` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Larlo','Carcao','09453020789',6,'2026-07-12','Active','2026-07-12 17:01:17'),(3,'Lando','Rendon','09281234567',1,'2026-07-12','Active','2026-07-12 17:01:17'),(4,'Linda','Walk','09391234567',2,'2026-07-12','Active','2026-07-12 17:01:17'),(5,'Romeo','Taiga','09451234567',4,'2026-07-12','Active','2026-07-12 17:01:17'),(6,'Ruds','Idoloza','09458989991',3,'2026-07-12','Active','2026-07-12 17:03:52'),(7,'test','employ','09171234567',5,'2026-07-12','Active','2026-07-12 20:39:34');
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expensecategories`
--

DROP TABLE IF EXISTS `expensecategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expensecategories` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(50) NOT NULL,
  PRIMARY KEY (`CategoryID`),
  UNIQUE KEY `CategoryName` (`CategoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expensecategories`
--

LOCK TABLES `expensecategories` WRITE;
/*!40000 ALTER TABLE `expensecategories` DISABLE KEYS */;
INSERT INTO `expensecategories` VALUES (5,'Loss'),(3,'Maintenance'),(4,'Miscellaneous'),(1,'Restock'),(2,'Utilities');
/*!40000 ALTER TABLE `expensecategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expenses`
--

DROP TABLE IF EXISTS `expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `expenses` (
  `ExpenseID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryID` int(11) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Amount` decimal(10,2) NOT NULL,
  `ExpenseDate` date NOT NULL,
  `IsAutoGenerated` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`ExpenseID`),
  KEY `fk_expenses_category` (`CategoryID`),
  CONSTRAINT `fk_expenses_category` FOREIGN KEY (`CategoryID`) REFERENCES `expensecategories` (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses` VALUES (1,1,'Pizza Dough x1 Box of 50 @ ?600 each = 50pcs (Expiry: 2026-07-19)',600.00,'2026-07-12',_binary ''),(2,1,'Tomato Sauce x1 5 L @ ?450 each = 5000ml (Expiry: 2027-01-12)',450.00,'2026-07-12',_binary ''),(3,1,'Mozzarella Cheese x1 5 kg @ ?1750 each = 5000g (Expiry: 2026-08-09)',1750.00,'2026-07-12',_binary ''),(4,1,'Extra Cheese Blend x1 5 kg @ ?1900 each = 5000g (Expiry: 2026-08-09)',1900.00,'2026-07-12',_binary ''),(5,1,'Garlic Butter x1 1 kg @ ?300 each = 1000g (Expiry: 2026-08-09)',300.00,'2026-07-12',_binary ''),(6,1,'Baguette x1 Box of 24 @ ?600 each = 24pcs (Expiry: 2026-07-17)',600.00,'2026-07-12',_binary ''),(7,1,'Mozzarella Stick x2 Box of 50 @ ?400 each = 100pcs (Expiry: 2026-12-12)',800.00,'2026-07-12',_binary ''),(8,1,'Breading Mix x1 5 kg @ ?500 each = 5000g (Expiry: 2027-01-12)',500.00,'2026-07-12',_binary ''),(9,1,'Mayo Dressing x1 5 L @ ?600 each = 5000ml (Expiry: 2026-09-12)',600.00,'2026-07-12',_binary ''),(10,1,'Iced Tea Mix x1 5 kg @ ?1000 each = 5000g (Expiry: 2027-07-12)',1000.00,'2026-07-12',_binary ''),(11,1,'Sugar Syrup x1 5 L @ ?300 each = 5000ml (Expiry: 2027-01-12)',300.00,'2026-07-12',_binary ''),(12,1,'Pineapple Juice Concentrate x1 5 L @ ?500 each = 5000ml (Expiry: 2026-12-12)',500.00,'2026-07-12',_binary ''),(13,1,'Pepperoni Slices x1 5 kg @ ?2250 each = 5000g (Expiry: 2026-08-02)',2250.00,'2026-07-12',_binary ''),(14,1,'Ham x1 5 kg @ ?2000 each = 5000g (Expiry: 2026-08-02)',2000.00,'2026-07-12',_binary ''),(15,1,'Beef Pepperoni x1 5 kg @ ?2500 each = 5000g (Expiry: 2026-08-02)',2500.00,'2026-07-12',_binary ''),(16,1,'Bacon Bits x1 5 kg @ ?3000 each = 5000g (Expiry: 2026-08-09)',3000.00,'2026-07-12',_binary ''),(17,1,'Pineapple Chunks x1 5 kg @ ?750 each = 5000g (Expiry: 2027-01-12)',750.00,'2026-07-12',_binary ''),(18,1,'Bell Pepper Mix x1 5 kg @ ?900 each = 5000g (Expiry: 2026-12-12)',900.00,'2026-07-12',_binary ''),(19,1,'Mushroom Slices x1 5 kg @ ?1250 each = 5000g (Expiry: 2026-12-12)',1250.00,'2026-07-12',_binary ''),(20,1,'Cabbage Mix x1 5 kg @ ?400 each = 5000g (Expiry: 2026-07-26)',400.00,'2026-07-12',_binary ''),(21,1,'Onion Ring (battered) x2 Box of 50 @ ?200 each = 100pcs (Expiry: 2026-12-12)',400.00,'2026-07-12',_binary ''),(22,1,'Potato Wedges (frozen) x1 25 kg sack @ ?2250 each = 25000g (Expiry: 2026-12-12)',2250.00,'2026-07-12',_binary ''),(23,1,'Lemon x1 Box of 50 @ ?300 each = 50pcs (Expiry: 2026-08-02)',300.00,'2026-07-12',_binary ''),(24,1,'Mineral Water x1 20 L @ ?160 each = 20000ml (Expiry: 2027-07-12)',160.00,'2026-07-12',_binary ''),(25,1,'Cup x4 Box of 50 @ ?75 each = 200pcs (Expiry: 2028-07-12)',300.00,'2026-07-12',_binary ''),(26,1,'Pizza Box x2 Box of 50 @ ?250 each = 100pcs (Expiry: 2028-07-12)',500.00,'2026-07-12',_binary ''),(27,1,'Side Dish Box x2 Box of 50 @ ?150 each = 100pcs (Expiry: 2028-07-12)',300.00,'2026-07-12',_binary ''),(28,2,'Electricity',2500.00,'2026-07-12',_binary '\0'),(29,2,'Tap Water',500.00,'2026-07-12',_binary '\0'),(30,3,'Oven Maintenance',900.00,'2026-07-12',_binary '\0'),(31,1,'testing x1 500 ml @ ₱1 each = 500ml (Expiry: 2026-07-13)',1.00,'2026-07-12',_binary ''),(32,1,'Bacon Bits x1 500 g @ ₱10 each = 500g (Expiry: 2026-07-13)',10.00,'2026-07-12',_binary ''),(33,1,'Bacon Bits x2 500 g @ ₱100 each = 1000g (Expiry: 2026-07-13)',200.00,'2026-07-12',_binary '');
/*!40000 ALTER TABLE `expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredientbatches`
--

DROP TABLE IF EXISTS `ingredientbatches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredientbatches` (
  `BatchID` int(11) NOT NULL AUTO_INCREMENT,
  `IngredientID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `RemainingQty` int(11) NOT NULL,
  `CostPerUnit` decimal(10,2) NOT NULL,
  `RestockDate` date NOT NULL,
  `ExpiryDate` date NOT NULL,
  `IsVoided` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`BatchID`),
  KEY `IngredientID` (`IngredientID`),
  CONSTRAINT `ingredientbatches_ibfk_1` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredientbatches`
--

LOCK TABLES `ingredientbatches` WRITE;
/*!40000 ALTER TABLE `ingredientbatches` DISABLE KEYS */;
INSERT INTO `ingredientbatches` VALUES (28,1,50,35,12.00,'2026-07-12','2026-07-19',0),(29,2,5000,3810,0.09,'2026-07-12','2027-01-12',0),(30,3,5000,3030,0.35,'2026-07-12','2026-08-09',0),(31,8,5000,4900,0.38,'2026-07-12','2026-08-09',0),(32,12,1000,1000,0.30,'2026-07-12','2026-08-09',0),(33,13,24,24,25.00,'2026-07-12','2026-07-17',0),(34,14,100,76,8.00,'2026-07-12','2026-12-12',0),(35,15,5000,4875,0.10,'2026-07-12','2027-01-12',0),(36,17,5000,5000,0.12,'2026-07-12','2026-09-12',0),(37,20,5000,4860,0.20,'2026-07-12','2027-07-12',0),(38,22,5000,4650,0.06,'2026-07-12','2027-01-12',0),(39,23,5000,5000,0.10,'2026-07-12','2026-12-12',0),(40,4,5000,4940,0.45,'2026-07-12','2026-08-02',0),(41,5,5000,4580,0.40,'2026-07-12','2026-08-02',0),(42,9,5000,4650,0.50,'2026-07-12','2026-08-02',0),(43,10,5000,4939,0.60,'2026-07-12','2026-08-09',0),(44,6,5000,4650,0.15,'2026-07-12','2027-01-12',0),(45,7,5000,5000,0.18,'2026-07-12','2026-12-12',0),(46,11,5000,4950,0.25,'2026-07-12','2026-12-12',0),(47,16,5000,5000,0.08,'2026-07-12','2026-07-26',0),(48,18,100,76,4.00,'2026-07-12','2026-12-12',0),(49,19,25000,24800,0.09,'2026-07-12','2026-12-12',0),(50,21,50,43,6.00,'2026-07-12','2026-08-02',0),(51,24,20000,16150,0.01,'2026-07-12','2027-07-12',0),(52,25,200,186,1.50,'2026-07-12','2028-07-12',0),(53,26,100,85,5.00,'2026-07-12','2028-07-12',0),(54,27,100,92,3.00,'2026-07-12','2028-07-12',0),(55,1,50,50,12.00,'2026-07-05','2026-07-10',0),(57,10,500,0,0.02,'2026-07-12','2026-07-13',1),(58,10,1000,997,0.22,'2026-07-12','2026-09-01',0);
/*!40000 ALTER TABLE `ingredientbatches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredients` (
  `IngredientID` int(11) NOT NULL AUTO_INCREMENT,
  `IngredientName` varchar(100) NOT NULL,
  `Unit` varchar(20) NOT NULL,
  PRIMARY KEY (`IngredientID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (1,'Pizza Dough','pcs'),(2,'Tomato Sauce','ml'),(3,'Mozzarella Cheese','g'),(4,'Pepperoni Slices','g'),(5,'Ham','g'),(6,'Pineapple Chunks','g'),(7,'Bell Pepper Mix','g'),(8,'Extra Cheese Blend','g'),(9,'Beef Pepperoni','g'),(10,'Bacon Bits','g'),(11,'Mushroom Slices','g'),(12,'Garlic Butter','g'),(13,'Baguette','pcs'),(14,'Mozzarella Stick','pcs'),(15,'Breading Mix','g'),(16,'Cabbage Mix','g'),(17,'Mayo Dressing','ml'),(18,'Onion Ring (battered)','pcs'),(19,'Potato Wedges (frozen)','g'),(20,'Iced Tea Mix','g'),(21,'Lemon','pcs'),(22,'Sugar Syrup','ml'),(23,'Pineapple Juice Concentrate','ml'),(24,'Mineral Water','ml'),(25,'Cup','pcs'),(26,'Pizza Box','pcs'),(27,'Side Dish Box','pcs');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `PositionID` int(11) NOT NULL AUTO_INCREMENT,
  `PositionName` varchar(50) NOT NULL,
  `IsSystemRole` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`PositionID`),
  UNIQUE KEY `PositionName` (`PositionName`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Cook',0),(2,'Waiter',0),(3,'Dishwasher',0),(4,'Janitor',0),(5,'Cashier',1),(6,'Manager',1);
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productingredients`
--

DROP TABLE IF EXISTS `productingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productingredients` (
  `ProductID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  `QtyRequired` decimal(10,3) NOT NULL,
  PRIMARY KEY (`ProductID`,`IngredientID`),
  KEY `IngredientID` (`IngredientID`),
  CONSTRAINT `productingredients_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`),
  CONSTRAINT `productingredients_ibfk_2` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productingredients`
--

LOCK TABLES `productingredients` WRITE;
/*!40000 ALTER TABLE `productingredients` DISABLE KEYS */;
INSERT INTO `productingredients` VALUES (1,1,1.000),(1,2,80.000),(1,3,150.000),(1,26,1.000),(2,1,1.000),(2,2,80.000),(2,3,130.000),(2,4,60.000),(2,26,1.000),(3,1,1.000),(3,2,80.000),(3,3,130.000),(3,5,60.000),(3,6,50.000),(3,26,1.000),(4,1,1.000),(4,2,80.000),(4,3,120.000),(4,7,100.000),(4,26,1.000),(5,1,1.000),(5,2,70.000),(5,3,150.000),(5,8,100.000),(5,26,1.000),(6,1,1.000),(6,2,80.000),(6,3,130.000),(6,9,70.000),(6,26,1.000),(7,1,1.000),(7,2,80.000),(7,3,130.000),(7,10,60.000),(7,11,50.000),(7,26,1.000),(8,3,30.000),(8,12,40.000),(8,13,1.000),(8,27,1.000),(9,14,6.000),(9,15,20.000),(9,27,1.000),(10,16,150.000),(10,17,40.000),(10,27,1.000),(11,15,15.000),(11,18,8.000),(11,27,1.000),(12,19,200.000),(12,27,1.000),(13,20,20.000),(13,22,20.000),(13,24,300.000),(13,25,1.000),(14,21,1.000),(14,22,30.000),(14,24,250.000),(14,25,1.000),(15,23,60.000),(15,24,200.000),(15,25,1.000),(16,10,1.000);
/*!40000 ALTER TABLE `productingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(100) NOT NULL,
  `CategoryID` int(11) NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1,
  `ImageFilename` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ProductID`),
  KEY `fk_products_category` (`CategoryID`),
  CONSTRAINT `fk_products_category` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Margherita',1,109.00,1,'1.png'),(2,'Pepperoni',1,129.00,1,'2.png'),(3,'Hawaiian',1,119.00,1,'3.png'),(4,'Vegetable',1,109.00,1,'4.png'),(5,'Cheese Overload',1,135.00,1,'5.png'),(6,'Beef Pepperoni',1,139.00,1,'6.png'),(7,'Bacon Mushroom',1,129.00,1,'7.png'),(8,'Garlic Bread',2,59.00,1,'8.png'),(9,'Mozzarella Sticks',2,59.00,1,'9.png'),(10,'Coleslaw',2,39.00,1,'10.png'),(11,'Onion Rings',2,75.00,1,'11.png'),(12,'Potato Wedges',2,69.00,1,'12.png'),(13,'Iced Tea',3,45.00,1,'13.png'),(14,'Lemonade',3,49.00,1,'14.png'),(15,'Pineapple Juice',3,49.00,1,'15.png'),(16,'test1',3,200.00,0,NULL);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier_deliveries`
--

DROP TABLE IF EXISTS `supplier_deliveries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `supplier_deliveries` (
  `delivery_id` int(11) NOT NULL AUTO_INCREMENT,
  `supplier_id` int(11) NOT NULL,
  `ingredient_id` int(11) NOT NULL,
  `batch_id` int(11) DEFAULT NULL,
  `pack_label` varchar(50) NOT NULL,
  `cost_per_base_unit` decimal(10,4) NOT NULL,
  `delivery_date` date NOT NULL,
  `expiry_date` date NOT NULL,
  PRIMARY KEY (`delivery_id`),
  KEY `supplier_id` (`supplier_id`),
  KEY `ingredient_id` (`ingredient_id`),
  KEY `supplier_deliveries_ibfk_3` (`batch_id`),
  CONSTRAINT `supplier_deliveries_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`),
  CONSTRAINT `supplier_deliveries_ibfk_2` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`IngredientID`),
  CONSTRAINT `supplier_deliveries_ibfk_3` FOREIGN KEY (`batch_id`) REFERENCES `ingredientbatches` (`BatchID`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_deliveries`
--

LOCK TABLES `supplier_deliveries` WRITE;
/*!40000 ALTER TABLE `supplier_deliveries` DISABLE KEYS */;
INSERT INTO `supplier_deliveries` VALUES (28,1,1,28,'Box of 50',12.0000,'2026-07-12','2026-07-19'),(29,1,2,29,'5 L',0.0900,'2026-07-12','2027-01-12'),(30,1,3,30,'5 kg',0.3500,'2026-07-12','2026-08-09'),(31,1,8,31,'5 kg',0.3800,'2026-07-12','2026-08-09'),(32,1,12,32,'1 kg',0.3000,'2026-07-12','2026-08-09'),(33,1,13,33,'Box of 24',25.0000,'2026-07-12','2026-07-17'),(34,1,14,34,'Box of 50',8.0000,'2026-07-12','2026-12-12'),(35,1,15,35,'5 kg',0.1000,'2026-07-12','2027-01-12'),(36,1,17,36,'5 L',0.1200,'2026-07-12','2026-09-12'),(37,1,20,37,'5 kg',0.2000,'2026-07-12','2027-07-12'),(38,1,22,38,'5 L',0.0600,'2026-07-12','2027-01-12'),(39,1,23,39,'5 L',0.1000,'2026-07-12','2026-12-12'),(40,2,4,40,'5 kg',0.4500,'2026-07-12','2026-08-02'),(41,2,5,41,'5 kg',0.4000,'2026-07-12','2026-08-02'),(42,2,9,42,'5 kg',0.5000,'2026-07-12','2026-08-02'),(43,2,10,43,'5 kg',0.6000,'2026-07-12','2026-08-09'),(44,3,6,44,'5 kg',0.1500,'2026-07-12','2027-01-12'),(45,3,7,45,'5 kg',0.1800,'2026-07-12','2026-12-12'),(46,3,11,46,'5 kg',0.2500,'2026-07-12','2026-12-12'),(47,3,16,47,'5 kg',0.0800,'2026-07-12','2026-07-26'),(48,3,18,48,'Box of 50',4.0000,'2026-07-12','2026-12-12'),(49,3,19,49,'25 kg sack',0.0900,'2026-07-12','2026-12-12'),(50,3,21,50,'Box of 50',6.0000,'2026-07-12','2026-08-02'),(51,3,24,51,'20 L',0.0080,'2026-07-12','2027-07-12'),(52,3,25,52,'Box of 50',1.5000,'2026-07-12','2028-07-12'),(53,3,26,53,'Box of 50',5.0000,'2026-07-12','2028-07-12'),(54,3,27,54,'Box of 50',3.0000,'2026-07-12','2028-07-12'),(56,1,10,57,'500 g',0.0200,'2026-07-12','2026-07-13'),(57,2,10,58,'500 g',0.2000,'2026-07-12','2026-07-13');
/*!40000 ALTER TABLE `supplier_deliveries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL AUTO_INCREMENT,
  `supplier_name` varchar(100) NOT NULL,
  `contact_name` varchar(100) DEFAULT NULL,
  `contact` varchar(50) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Golden Wheat Bakers & Dairy Supply','Ramon Magsaysay','09171112222','Quezon City','2026-07-12 16:50:58'),(2,'Metro Meats Supply','Carlo Villanueva','09182223333','Pasig City','2026-07-12 16:50:58'),(3,'GreenLeaf Produce & Packaging','Carro Isidro','09193334444','Taguig City','2026-07-12 16:50:58');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactiondetails`
--

DROP TABLE IF EXISTS `transactiondetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactiondetails` (
  `DetailID` int(11) NOT NULL AUTO_INCREMENT,
  `TransactionID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`DetailID`),
  KEY `fk_details_transaction` (`TransactionID`),
  KEY `fk_details_product` (`ProductID`),
  CONSTRAINT `fk_details_product` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`),
  CONSTRAINT `fk_details_transaction` FOREIGN KEY (`TransactionID`) REFERENCES `transactions` (`TransactionID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactiondetails`
--

LOCK TABLES `transactiondetails` WRITE;
/*!40000 ALTER TABLE `transactiondetails` DISABLE KEYS */;
INSERT INTO `transactiondetails` VALUES (1,1,3,1,119.00),(2,1,6,2,139.00),(3,1,2,1,129.00),(4,1,13,4,45.00),(5,1,14,1,49.00),(6,1,11,3,75.00),(7,1,9,1,59.00),(8,1,12,1,69.00),(9,2,10,1,39.00),(11,4,3,2,119.00),(13,3,3,2,119.00),(17,5,13,1,45.00),(18,3,14,4,49.00),(19,6,14,2,49.00),(20,7,5,1,135.00),(21,8,3,1,119.00),(22,9,3,1,119.00),(23,10,7,1,129.00),(24,11,16,1,200.00),(25,12,6,3,139.00),(26,12,13,2,45.00),(27,12,9,3,59.00);
/*!40000 ALTER TABLE `transactiondetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `TransactionID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) DEFAULT NULL,
  `TransactionDate` datetime NOT NULL DEFAULT current_timestamp(),
  `Status` varchar(20) NOT NULL DEFAULT 'Completed',
  `ConfirmedByEmployeeID` int(11) DEFAULT NULL,
  `AmountPaid` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`TransactionID`),
  KEY `fk_transactions_customer` (`CustomerID`),
  KEY `fk_transactions_employee` (`ConfirmedByEmployeeID`),
  CONSTRAINT `fk_transactions_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`),
  CONSTRAINT `fk_transactions_employee` FOREIGN KEY (`ConfirmedByEmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,'2026-07-12 17:38:07','Completed',1,1200.00),(2,2,'2026-07-12 17:40:11','Voided',NULL,NULL),(3,3,'2026-07-12 17:41:26','Completed',1,500.00),(4,4,'2026-07-12 17:41:57','Completed',NULL,240.00),(5,5,'2026-07-12 18:32:15','Completed',1,50.00),(6,6,'2026-07-12 18:35:44','Pending',NULL,NULL),(7,7,'2026-07-12 19:09:17','Pending',NULL,NULL),(8,7,'2026-07-12 19:09:45','Pending',NULL,NULL),(9,8,'2026-07-12 19:16:34','Completed',7,200.00),(10,9,'2026-07-12 19:20:30','Completed',NULL,200.00),(11,10,'2026-07-12 19:40:54','Completed',1,300.00),(12,11,'2026-07-13 00:14:43','Completed',7,700.00);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-07-13 12:54:23
