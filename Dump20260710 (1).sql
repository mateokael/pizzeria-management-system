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
INSERT INTO `batch_adjustments` VALUES (1,33,'Update',2000,200,0.10,0.10,'2026-09-01','2026-09-01','Miscount','test','2026-07-09 21:54:57'),(2,33,'Update',200,200,0.10,0.10,'2026-09-01','2026-09-01','Wrong Entry',NULL,'2026-07-09 21:55:25'),(3,33,'Delete',200,0,0.10,0.10,'2026-09-01','2026-09-01','Miscount','nagkamali','2026-07-09 21:55:44'),(4,34,'Delete',500,0,0.02,0.02,'2026-09-10','2026-09-10','Breakage','qwe','2026-07-09 22:00:52'),(5,32,'Update',1000,999,50.00,50.00,'2026-07-10','2026-07-10','Wrong Entry',NULL,'2026-07-09 22:15:12');
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
INSERT INTO `customers` VALUES (1,'lacne','d',NULL,'2026-07-02 01:38:41'),(2,'name','test',NULL,'2026-07-02 01:52:32'),(3,'try',NULL,NULL,'2026-07-02 01:55:25'),(5,'test',NULL,NULL,'2026-07-02 06:01:40'),(6,'carcar','isidro',NULL,'2026-07-02 07:35:19'),(9,'lance',NULL,NULL,'2026-07-09 23:41:23'),(10,'a',NULL,NULL,'2026-07-09 23:54:05'),(11,'l',NULL,NULL,'2026-07-09 23:56:19');
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
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `DateHired` date DEFAULT NULL,
  `Status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `DateAdded` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`EmployeeID`),
  UNIQUE KEY `Username` (`Username`),
  KEY `fk_employees_position` (`PositionID`),
  CONSTRAINT `fk_employees_position` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'lance','dumagcao','0908780',2,NULL,NULL,'2026-07-10','Active','2026-07-10 01:22:17'),(2,'admin',NULL,NULL,6,'admin','admin123',NULL,'Active','2026-07-10 12:03:17'),(3,'test','cash','0980',5,'cashier','test','2026-07-10','Active','2026-07-10 12:12:31');
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expenses`
--

LOCK TABLES `expenses` WRITE;
/*!40000 ALTER TABLE `expenses` DISABLE KEYS */;
INSERT INTO `expenses` VALUES (2,1,'nice',400.00,'2026-07-02',_binary '\0'),(3,1,'Bacon Mushroom x20 @ ₱120 (Expiry: 2026-09-01)',2400.00,'2026-07-02',_binary ''),(4,1,'Beef Pepperoni x20 @ ₱130 (Expiry: 2026-09-01)',2600.00,'2026-07-02',_binary ''),(5,1,'Cheese Overload x20 @ ₱125 (Expiry: 2026-09-01)',2500.00,'2026-07-02',_binary ''),(6,3,'Oven',70.00,'2026-07-02',_binary '\0'),(7,4,'nice',400.00,'2026-07-02',_binary '\0'),(8,1,'Coke SYrup(test) x1000 @ ₱50 (Expiry: 2026-07-10)',50000.00,'2026-07-09',_binary ''),(9,1,'Coke SYrup(test) x2 1 L @ ₱100 each = 2000ml (Expiry: 2026-09-01)',200.00,'2026-07-09',_binary ''),(10,1,'Coke SYrup(test) x1 500 ml @ ₱10 each = 500ml (Expiry: 2026-09-10)',10.00,'2026-07-09',_binary ''),(11,5,'Breakage: 500 units lost',10.00,'2026-07-09',_binary ''),(12,1,'Coke SYrup(test) x2 500 ml @ ₱100 each = 1000ml (Expiry: 2026-10-01)',200.00,'2026-07-09',_binary ''),(13,2,'Electricity',1000.00,'2026-07-10',_binary '\0'),(14,1,'testIng x1 500 g @ ₱100 each = 500g (Expiry: 2026-10-01)',100.00,'2026-07-10',_binary ''),(15,1,'testING x1 500 ml @ ₱100 each = 500ml (Expiry: 2026-07-11)',100.00,'2026-07-10',_binary ''),(16,1,'Bacon Bits x1 500 g @ ₱5 each = 500g (Expiry: 2026-07-11)',5.00,'2026-07-10',_binary '');
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
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredientbatches`
--

LOCK TABLES `ingredientbatches` WRITE;
/*!40000 ALTER TABLE `ingredientbatches` DISABLE KEYS */;
INSERT INTO `ingredientbatches` VALUES (1,1,10000,9988,1.00,'2026-07-09','2026-08-08',0),(2,2,10000,9070,1.00,'2026-07-09','2026-08-08',0),(3,3,10000,8320,1.00,'2026-07-09','2026-08-08',0),(4,4,10000,10000,1.00,'2026-07-09','2026-08-08',0),(5,5,10000,10000,1.00,'2026-07-09','2026-08-08',0),(6,6,10000,10000,1.00,'2026-07-09','2026-08-08',0),(7,7,10000,10000,1.00,'2026-07-09','2026-08-08',0),(8,8,10000,9700,1.00,'2026-07-09','2026-08-08',0),(9,9,10000,9790,1.00,'2026-07-09','2026-08-08',0),(10,10,10000,9820,1.00,'2026-07-09','2026-08-08',0),(11,11,10000,9850,1.00,'2026-07-09','2026-08-08',0),(12,12,10000,10000,1.00,'2026-07-09','2026-08-08',0),(13,13,10000,10000,1.00,'2026-07-09','2026-08-08',0),(14,14,10000,10000,1.00,'2026-07-09','2026-08-08',0),(15,15,10000,10000,1.00,'2026-07-09','2026-08-08',0),(16,16,10000,9550,1.00,'2026-07-09','2026-08-08',0),(17,17,10000,9880,1.00,'2026-07-09','2026-08-08',0),(18,18,10000,10000,1.00,'2026-07-09','2026-08-08',0),(19,19,10000,9400,1.00,'2026-07-09','2026-08-08',0),(20,20,10000,9780,1.00,'2026-07-09','2026-08-08',0),(21,21,10000,9997,1.00,'2026-07-09','2026-08-08',0),(22,22,10000,9690,1.00,'2026-07-09','2026-08-08',0),(23,23,10000,9940,1.00,'2026-07-09','2026-08-08',0),(24,24,10000,5750,1.00,'2026-07-09','2026-08-08',0),(25,25,10000,9985,1.00,'2026-07-09','2026-08-08',0),(32,26,1000,699,50.00,'2026-07-09','2026-07-10',0),(33,26,2000,0,0.10,'2026-07-09','2026-09-01',1),(34,26,500,0,0.02,'2026-07-09','2026-09-10',1),(35,26,1000,1000,0.20,'2026-07-09','2026-10-01',0),(38,10,500,480,0.01,'2026-07-10','2026-07-11',0);
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
INSERT INTO `ingredients` VALUES (1,'Pizza Dough','pcs'),(2,'Tomato Sauce','ml'),(3,'Mozzarella Cheese','g'),(4,'Pepperoni Slices','g'),(5,'Ham','g'),(6,'Pineapple Chunks','g'),(7,'Bell Pepper Mix','g'),(8,'Extra Cheese Blend','g'),(9,'Beef Pepperoni','g'),(10,'Bacon Bits','g'),(11,'Mushroom Slices','g'),(12,'Garlic Butter','g'),(13,'Baguette','pcs'),(14,'Mozzarella Stick','pcs'),(15,'Breading Mix','g'),(16,'Cabbage Mix','g'),(17,'Mayo Dressing','ml'),(18,'Onion Ring (battered)','pcs'),(19,'Potato Wedges (frozen)','g'),(20,'Iced Tea Mix','g'),(21,'Lemon','pcs'),(22,'Sugar Syrup','ml'),(23,'Pineapple Juice Concentrate','ml'),(24,'Water','ml'),(25,'Cup','pcs'),(26,'Coke SYrup(test)','ml');
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
INSERT INTO `productingredients` VALUES (1,1,1.000),(1,2,80.000),(1,3,150.000),(2,1,1.000),(2,2,80.000),(2,3,130.000),(2,4,60.000),(3,1,1.000),(3,2,80.000),(3,3,130.000),(3,5,60.000),(3,6,50.000),(4,1,1.000),(4,2,80.000),(4,3,120.000),(4,7,100.000),(5,1,1.000),(5,2,70.000),(5,3,150.000),(5,8,100.000),(6,1,1.000),(6,2,80.000),(6,3,130.000),(6,9,70.000),(7,1,1.000),(7,2,80.000),(7,3,130.000),(7,10,60.000),(7,11,50.000),(8,3,30.000),(8,12,40.000),(8,13,1.000),(9,14,6.000),(9,15,20.000),(10,16,150.000),(10,17,40.000),(11,15,15.000),(11,18,8.000),(12,19,200.000),(13,20,20.000),(13,22,20.000),(13,24,300.000),(13,25,1.000),(14,21,1.000),(14,22,30.000),(14,24,250.000),(14,25,1.000),(15,23,60.000),(15,24,200.000),(15,25,1.000),(22,2,10.001),(22,10,10.001),(23,1,1.000);
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'Margherita',1,109.00,1,'1.png'),(2,'Pepperoni',1,129.00,1,'2.png'),(3,'Hawaiian',1,119.00,1,'3.png'),(4,'Vegetable',1,109.00,1,'4.png'),(5,'Cheese Overload',1,135.00,1,'5.png'),(6,'Beef Pepperoni',1,139.00,1,'6.png'),(7,'Bacon Mushroom',1,129.00,1,NULL),(8,'Garlic Bread',2,59.00,1,'8.png'),(9,'Mozzarella Sticks',2,59.00,1,'9.png'),(10,'Coleslaw',2,39.00,1,'10.png'),(11,'Onion Rings',2,75.00,1,'11.png'),(12,'Potato Wedges',2,69.00,1,'12.png'),(13,'Iced Tea',3,45.00,1,'13.png'),(14,'Lemonade',3,49.00,1,'14.png'),(15,'Pineapple Juice',3,49.00,1,'15.png'),(19,'Coke(test)',3,60.00,0,NULL),(22,'test1',3,100.00,0,NULL),(23,'test2',3,100.00,0,NULL),(24,'Cheese Overload',1,135.00,0,NULL);
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
  `received_by` int(11) DEFAULT NULL,
  PRIMARY KEY (`delivery_id`),
  KEY `supplier_id` (`supplier_id`),
  KEY `ingredient_id` (`ingredient_id`),
  KEY `supplier_deliveries_ibfk_3` (`batch_id`),
  CONSTRAINT `supplier_deliveries_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`),
  CONSTRAINT `supplier_deliveries_ibfk_2` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`IngredientID`),
  CONSTRAINT `supplier_deliveries_ibfk_3` FOREIGN KEY (`batch_id`) REFERENCES `ingredientbatches` (`BatchID`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier_deliveries`
--

LOCK TABLES `supplier_deliveries` WRITE;
/*!40000 ALTER TABLE `supplier_deliveries` DISABLE KEYS */;
INSERT INTO `supplier_deliveries` VALUES (1,1,26,33,'1 L',0.1000,'2026-07-09','2026-09-01',NULL),(2,1,26,34,'500 ml',0.0200,'2026-07-09','2026-09-10',NULL),(3,1,26,35,'500 ml',0.2000,'2026-07-09','2026-10-01',NULL),(6,1,10,38,'500 g',0.0100,'2026-07-10','2026-07-11',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'TESTPIZZASAUCE','John Pizza','0908780209','Taguig','2026-07-09 20:16:33');
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
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactiondetails`
--

LOCK TABLES `transactiondetails` WRITE;
/*!40000 ALTER TABLE `transactiondetails` DISABLE KEYS */;
INSERT INTO `transactiondetails` VALUES (1,1,7,1,129.00),(2,2,7,3,129.00),(3,3,7,1,129.00),(5,5,7,1,129.00),(6,6,7,6,129.00),(7,7,1,2,109.00),(8,7,13,1,45.00),(9,8,13,5,45.00),(10,9,13,1,45.00),(11,10,19,1,60.00),(12,10,13,1,45.00),(13,10,14,1,49.00),(15,10,12,1,69.00),(16,10,5,1,135.00),(17,10,10,1,39.00),(18,10,1,1,109.00),(19,10,7,1,129.00),(20,10,6,1,139.00),(23,11,14,1,49.00),(25,11,12,1,69.00),(26,11,5,1,135.00),(27,11,1,1,109.00),(28,11,10,1,39.00),(29,11,7,1,129.00),(30,11,6,1,139.00),(31,12,19,1,60.00),(32,12,13,1,45.00),(33,12,14,1,49.00),(34,12,15,1,49.00),(35,12,12,1,69.00),(36,12,5,1,135.00),(37,12,1,1,109.00),(38,12,10,1,39.00),(39,12,7,1,129.00),(40,12,6,1,139.00),(41,13,13,3,45.00),(42,14,22,2,100.00);
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
  `AmountPaid` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`TransactionID`),
  KEY `fk_transactions_customer` (`CustomerID`),
  CONSTRAINT `fk_transactions_customer` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,'2026-07-02 01:38:41','Completed',700.00),(2,2,'2026-07-02 01:52:32','Voided',500.00),(3,3,'2026-07-02 01:55:25','Completed',540.00),(5,5,'2026-07-02 06:01:40','Completed',200.00),(6,5,'2026-07-02 06:56:33','Completed',810.00),(7,6,'2026-07-02 07:35:19','Completed',400.00),(8,5,'2026-07-09 10:56:00','Completed',300.00),(9,9,'2026-07-09 23:41:23','Completed',50.00),(10,5,'2026-07-09 23:48:58','Completed',900.00),(11,10,'2026-07-09 23:54:05','Completed',900.00),(12,11,'2026-07-09 23:56:19','Completed',900.00),(13,9,'2026-07-10 09:49:39','Completed',200.00),(14,9,'2026-07-10 13:48:05','Completed',400.00);
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

-- Dump completed on 2026-07-10 15:31:44
