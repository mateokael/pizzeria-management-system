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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `batch_adjustments`
--

LOCK TABLES `batch_adjustments` WRITE;
/*!40000 ALTER TABLE `batch_adjustments` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
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
INSERT INTO `employees` VALUES (1,'Larlo','Carcao','09453020789',6,'2026-07-12','Active','2026-07-12 17:01:17'),(3,'Lando','Rendon','09281234567',1,'2026-07-12','Active','2026-07-12 17:01:17'),(4,'Linda','Walk','09391234567',2,'2026-07-12','Active','2026-07-12 17:01:17'),(5,'Romeo','Taiga','09451234567',4,'2026-07-12','Active','2026-07-12 17:01:17'),(6,'Ruds','Idoloza','09458989991',3,'2026-07-12','Active','2026-07-12 17:03:52'),(7,'Azmeth','Sarmin','09171234567',5,'2026-07-12','Active','2026-07-12 20:39:34');
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
INSERT INTO `expenses` VALUES (1,1,'Bacon Bits x5 1 kg @ ?307.6 each = 5000g (Expiry: 2026-07-23)',1538.00,'2026-06-25',_binary ''),(2,1,'Pineapple Chunks x5 1 kg @ ?164.4 each = 5000g (Expiry: 2027-01-08)',822.00,'2026-07-12',_binary ''),(3,1,'Sugar Syrup x6 500 ml @ ?30.6 each = 3000ml (Expiry: 2027-01-08)',183.60,'2026-07-12',_binary ''),(4,1,'Beef Pepperoni x5 1 kg @ ?486.1 each = 5000g (Expiry: 2026-07-30)',2430.50,'2026-07-09',_binary ''),(5,1,'Extra Cheese Blend x6 1 kg @ ?386.6 each = 6000g (Expiry: 2026-08-06)',2319.60,'2026-07-09',_binary ''),(6,1,'Pizza Box x3 Box of 50 @ ?243.88 each = 150pcs (Expiry: 2028-06-24)',731.64,'2026-06-25',_binary ''),(7,1,'Breading Mix x8 500 g @ ?52.15 each = 4000g (Expiry: 2026-12-14)',417.20,'2026-06-17',_binary ''),(8,1,'Potato Wedges (frozen) x2 5 kg @ ?461.0 each = 10000g (Expiry: 2026-12-07)',922.00,'2026-07-10',_binary ''),(9,1,'Side Dish Box x3 Box of 50 @ ?143.07 each = 150pcs (Expiry: 2028-06-22)',429.21,'2026-06-23',_binary ''),(10,1,'Iced Tea Mix x5 500 g @ ?101.85 each = 2500g (Expiry: 2027-07-10)',509.25,'2026-07-10',_binary ''),(11,1,'Mozzarella Stick x8 Box of 50 @ ?408.64 each = 400pcs (Expiry: 2026-12-08)',3269.12,'2026-07-11',_binary ''),(12,1,'Cup x3 Box of 50 @ ?71.78 each = 150pcs (Expiry: 2028-06-23)',215.34,'2026-06-24',_binary ''),(13,1,'Cabbage Mix x8 1 kg @ ?81.3 each = 8000g (Expiry: 2026-07-17)',650.40,'2026-07-03',_binary ''),(14,1,'Mineral Water x6 5 L @ ?49.0 each = 30000ml (Expiry: 2027-06-19)',294.00,'2026-06-19',_binary ''),(15,1,'Pizza Dough x3 Box of 50 @ ?591.05 each = 150pcs (Expiry: 2026-07-16)',1773.15,'2026-07-10',_binary ''),(16,1,'Bell Pepper Mix x8 1 kg @ ?191.3 each = 8000g (Expiry: 2026-12-03)',1530.40,'2026-07-06',_binary ''),(17,1,'Mayo Dressing x8 500 ml @ ?63.6 each = 4000ml (Expiry: 2026-08-20)',508.80,'2026-06-21',_binary ''),(18,1,'Pineapple Juice Concentrate x6 1 L @ ?102.3 each = 6000ml (Expiry: 2026-12-08)',613.80,'2026-07-11',_binary ''),(19,1,'Garlic Butter x8 500 g @ ?151.35 each = 4000g (Expiry: 2026-07-25)',1210.80,'2026-06-27',_binary ''),(20,1,'Pepperoni Slices x5 1 kg @ ?473.1 each = 5000g (Expiry: 2026-07-24)',2365.50,'2026-07-03',_binary ''),(21,1,'Onion Ring (battered) x8 Box of 50 @ ?205.93 each = 400pcs (Expiry: 2026-12-01)',1647.44,'2026-07-04',_binary ''),(22,1,'Mozzarella Cheese x4 5 kg @ ?1647.0 each = 20000g (Expiry: 2026-08-08)',6588.00,'2026-07-11',_binary ''),(23,1,'Tomato Sauce x8 1 L @ ?85.5 each = 8000ml (Expiry: 2026-12-27)',684.00,'2026-06-30',_binary ''),(24,1,'Lemon x2 Box of 50 @ ?284.2 each = 100pcs (Expiry: 2026-07-24)',568.40,'2026-07-03',_binary ''),(25,1,'Baguette x2 Box of 50 @ ?1244.88 each = 100pcs (Expiry: 2026-07-17)',2489.76,'2026-07-12',_binary ''),(26,1,'Ham x5 1 kg @ ?423.0 each = 5000g (Expiry: 2026-08-01)',2115.00,'2026-07-11',_binary ''),(27,1,'Mushroom Slices x5 1 kg @ ?265.5 each = 5000g (Expiry: 2026-11-22)',1327.50,'2026-06-25',_binary ''),(28,1,'Pizza Dough x2 Box of 12 @ ?141.3 each = 24pcs (Expiry: 2026-07-05)',282.60,'2026-06-29',_binary ''),(29,1,'Baguette x2 Box of 12 @ ?308.1 each = 24pcs (Expiry: 2026-07-05)',616.20,'2026-06-30',_binary ''),(30,1,'Cabbage Mix x4 500 g @ ?37.3 each = 2000g (Expiry: 2026-07-03)',149.20,'2026-06-19',_binary ''),(31,1,'Mozzarella Cheese x8 500 g @ ?190.75 each = 4000g (Expiry: 2026-07-14)',1526.00,'2026-06-16',_binary ''),(32,1,'Pepperoni Slices x2 500 g @ ?235.25 each = 1000g (Expiry: 2026-07-17)',470.50,'2026-06-26',_binary ''),(33,1,'Ham x2 500 g @ ?186.2 each = 1000g (Expiry: 2026-07-14)',372.40,'2026-06-23',_binary '');
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
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredientbatches`
--

LOCK TABLES `ingredientbatches` WRITE;
/*!40000 ALTER TABLE `ingredientbatches` DISABLE KEYS */;
INSERT INTO `ingredientbatches` VALUES (1,10,5000,5000,0.31,'2026-06-25','2026-07-23',0),(2,6,5000,5000,0.16,'2026-07-12','2027-01-08',0),(3,22,3000,3000,0.06,'2026-07-12','2027-01-08',0),(4,9,5000,5000,0.49,'2026-07-09','2026-07-30',0),(5,8,6000,6000,0.39,'2026-07-09','2026-08-06',0),(6,26,150,150,4.88,'2026-06-25','2028-06-24',0),(7,15,4000,4000,0.10,'2026-06-17','2026-12-14',0),(8,19,10000,10000,0.09,'2026-07-10','2026-12-07',0),(9,27,150,150,2.86,'2026-06-23','2028-06-22',0),(10,20,2500,2500,0.20,'2026-07-10','2027-07-10',0),(11,14,400,400,8.17,'2026-07-11','2026-12-08',0),(12,25,150,150,1.44,'2026-06-24','2028-06-23',0),(13,16,8000,8000,0.08,'2026-07-03','2026-07-17',0),(14,24,30000,30000,0.01,'2026-06-19','2027-06-19',0),(15,1,150,150,11.82,'2026-07-10','2026-07-16',0),(16,7,8000,8000,0.19,'2026-07-06','2026-12-03',0),(17,17,4000,4000,0.13,'2026-06-21','2026-08-20',0),(18,23,6000,6000,0.10,'2026-07-11','2026-12-08',0),(19,12,4000,4000,0.30,'2026-06-27','2026-07-25',0),(20,4,5000,5000,0.47,'2026-07-03','2026-07-24',0),(21,18,400,400,4.12,'2026-07-04','2026-12-01',0),(22,3,20000,20000,0.33,'2026-07-11','2026-08-08',0),(23,2,8000,8000,0.09,'2026-06-30','2026-12-27',0),(24,21,100,100,5.68,'2026-07-03','2026-07-24',0),(25,13,100,100,24.90,'2026-07-12','2026-07-17',0),(26,5,5000,5000,0.42,'2026-07-11','2026-08-01',0),(27,11,5000,5000,0.27,'2026-06-25','2026-11-22',0),(28,1,24,24,11.78,'2026-06-29','2026-07-05',0),(29,13,24,24,25.68,'2026-06-30','2026-07-05',0),(30,16,2000,2000,0.07,'2026-06-19','2026-07-03',0),(31,3,4000,4000,0.38,'2026-06-16','2026-07-14',0),(32,4,1000,1000,0.47,'2026-06-26','2026-07-17',0),(33,5,1000,1000,0.37,'2026-06-23','2026-07-14',0);
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
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
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
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_deliveries`
--

LOCK TABLES `supplier_deliveries` WRITE;
/*!40000 ALTER TABLE `supplier_deliveries` DISABLE KEYS */;
INSERT INTO `supplier_deliveries` VALUES (1,2,10,1,'1 kg',0.3076,'2026-06-25','2026-07-23'),(2,3,6,2,'1 kg',0.1644,'2026-07-12','2027-01-08'),(3,3,22,3,'500 ml',0.0612,'2026-07-12','2027-01-08'),(4,2,9,4,'1 kg',0.4861,'2026-07-09','2026-07-30'),(5,1,8,5,'1 kg',0.3866,'2026-07-09','2026-08-06'),(6,3,26,6,'Box of 50',4.8776,'2026-06-25','2028-06-24'),(7,1,15,7,'500 g',0.1043,'2026-06-17','2026-12-14'),(8,3,19,8,'5 kg',0.0922,'2026-07-10','2026-12-07'),(9,3,27,9,'Box of 50',2.8614,'2026-06-23','2028-06-22'),(10,3,20,10,'500 g',0.2037,'2026-07-10','2027-07-10'),(11,1,14,11,'Box of 50',8.1728,'2026-07-11','2026-12-08'),(12,3,25,12,'Box of 50',1.4356,'2026-06-24','2028-06-23'),(13,3,16,13,'1 kg',0.0813,'2026-07-03','2026-07-17'),(14,3,24,14,'5 L',0.0098,'2026-06-19','2027-06-19'),(15,1,1,15,'Box of 50',11.8210,'2026-07-10','2026-07-16'),(16,3,7,16,'1 kg',0.1913,'2026-07-06','2026-12-03'),(17,3,17,17,'500 ml',0.1272,'2026-06-21','2026-08-20'),(18,3,23,18,'1 L',0.1023,'2026-07-11','2026-12-08'),(19,1,12,19,'500 g',0.3027,'2026-06-27','2026-07-25'),(20,2,4,20,'1 kg',0.4731,'2026-07-03','2026-07-24'),(21,3,18,21,'Box of 50',4.1186,'2026-07-04','2026-12-01'),(22,1,3,22,'5 kg',0.3294,'2026-07-11','2026-08-08'),(23,3,2,23,'1 L',0.0855,'2026-06-30','2026-12-27'),(24,3,21,24,'Box of 50',5.6840,'2026-07-03','2026-07-24'),(25,1,13,25,'Box of 50',24.8976,'2026-07-12','2026-07-17'),(26,2,5,26,'1 kg',0.4230,'2026-07-11','2026-08-01'),(27,3,11,27,'1 kg',0.2655,'2026-06-25','2026-11-22'),(28,1,1,28,'Box of 12',11.7750,'2026-06-29','2026-07-05'),(29,1,13,29,'Box of 12',25.6750,'2026-06-30','2026-07-05'),(30,3,16,30,'500 g',0.0746,'2026-06-19','2026-07-03'),(31,1,3,31,'500 g',0.3815,'2026-06-16','2026-07-14'),(32,2,4,32,'500 g',0.4705,'2026-06-26','2026-07-17'),(33,2,5,33,'500 g',0.3724,'2026-06-23','2026-07-14');
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
INSERT INTO `suppliers` VALUES (1,'Golden Wheat Bakers & Dairy Supply','Ramon Masangkay','09171112222','Quezon City','2026-07-12 16:50:58'),(2,'Metro Meats Supply','Carlo Villanueva','09182223333','Pasig City','2026-07-12 16:50:58'),(3,'GreenLeaf Produce & Packaging','Carro Isidro','09193334444','Taguig City','2026-07-12 16:50:58');
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactiondetails`
--

LOCK TABLES `transactiondetails` WRITE;
/*!40000 ALTER TABLE `transactiondetails` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
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

-- Dump completed on 2026-07-13 14:58:19
