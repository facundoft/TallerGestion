-- MySQL dump 10.13  Distrib 8.0.39, for Win64 (x86_64)
--
-- Host: localhost    Database: gestion
-- ------------------------------------------------------
-- Server version	8.0.39

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `atenciones`
--

DROP TABLE IF EXISTS `atenciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `atenciones` (
  `AtencionID` int NOT NULL AUTO_INCREMENT,
  `ClienteID` int DEFAULT NULL,
  `OficinaID` int DEFAULT NULL,
  `PuestoID` int DEFAULT NULL,
  `OperarioID` int DEFAULT NULL,
  `TramiteID` int DEFAULT NULL,
  `FechaHoraLlegada` datetime DEFAULT NULL,
  `FechaHoraAtencion` datetime DEFAULT NULL,
  `FechaHoraFinalizacion` datetime DEFAULT NULL,
  `Estado` varchar(20) DEFAULT NULL,
  `SegundaLlamado` tinyint DEFAULT NULL,
  PRIMARY KEY (`AtencionID`),
  KEY `ClienteID` (`ClienteID`),
  KEY `OficinaID` (`OficinaID`),
  KEY `PuestoID` (`PuestoID`),
  KEY `OperarioID` (`OperarioID`),
  KEY `atenciones_ibfk_5_idx` (`TramiteID`),
  CONSTRAINT `atenciones_ibfk_1` FOREIGN KEY (`ClienteID`) REFERENCES `clientes` (`ClienteID`),
  CONSTRAINT `atenciones_ibfk_2` FOREIGN KEY (`OficinaID`) REFERENCES `oficinascomerciales` (`OficinaID`),
  CONSTRAINT `atenciones_ibfk_3` FOREIGN KEY (`PuestoID`) REFERENCES `puestosatencion` (`PuestoID`),
  CONSTRAINT `atenciones_ibfk_4` FOREIGN KEY (`OperarioID`) REFERENCES `operarios` (`OperarioID`),
  CONSTRAINT `atenciones_ibfk_5` FOREIGN KEY (`TramiteID`) REFERENCES `tramite` (`TramiteID`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atenciones`
--

LOCK TABLES `atenciones` WRITE;
/*!40000 ALTER TABLE `atenciones` DISABLE KEYS */;
INSERT INTO `atenciones` VALUES (33,3,1,289,204,41,'2023-10-10 08:30:00','2023-10-10 08:45:00','2023-10-10 09:00:00','Finalizada',0),(34,8,2,210,208,42,'2023-10-10 09:00:00','2023-10-10 09:15:00','2023-10-10 09:45:00','Finalizada',0),(35,6,3,212,212,43,'2023-10-10 09:30:00','2023-10-10 09:40:00','2023-10-10 10:00:00','Finalizada',1),(36,5,4,216,216,44,'2023-10-11 08:00:00','2023-10-11 08:20:00','2023-10-11 08:50:00','En Atenci├│n',0),(37,4,5,220,220,45,'2023-10-11 08:45:00','2023-10-11 09:00:00','2023-10-11 09:30:00','Cancelada',1),(38,7,6,228,224,46,'2023-10-11 09:15:00','2023-10-11 09:30:00','2023-10-11 10:00:00','Finalizada',0),(39,3,7,228,228,47,'2023-10-12 08:30:00','2023-10-12 08:45:00','2023-10-12 09:05:00','Finalizada',0),(40,8,8,232,232,48,'2023-10-12 09:00:00','2023-10-12 09:20:00','2023-10-12 09:40:00','Finalizada',1),(41,6,9,236,236,49,'2023-10-12 09:30:00','2023-10-12 09:45:00','2023-10-12 10:00:00','En Espera',0),(42,5,10,240,240,50,'2023-10-13 08:30:00','2023-10-13 08:50:00','2023-10-13 09:10:00','Finalizada',0);
/*!40000 ALTER TABLE `atenciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `cantatencionestramite`
--

DROP TABLE IF EXISTS `cantatencionestramite`;
/*!50001 DROP VIEW IF EXISTS `cantatencionestramite`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `cantatencionestramite` AS SELECT 
 1 AS `CantAtenciones`,
 1 AS `TramiteID`,
 1 AS `DescripcionTramite`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `ClienteID` int NOT NULL AUTO_INCREMENT,
  `CedulaIdentidad` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ClienteID`),
  UNIQUE KEY `CedulaIdentidad` (`CedulaIdentidad`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (3,'12312312'),(8,'21321121'),(6,'45645678'),(5,'63759197'),(4,'98765432'),(7,'98798765');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oficinascomerciales`
--

DROP TABLE IF EXISTS `oficinascomerciales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `oficinascomerciales` (
  `OficinaID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) DEFAULT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Ciudad` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`OficinaID`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oficinascomerciales`
--

LOCK TABLES `oficinascomerciales` WRITE;
/*!40000 ALTER TABLE `oficinascomerciales` DISABLE KEYS */;
INSERT INTO `oficinascomerciales` VALUES (1,'Oficina Montevideo','pues mvd','Montevideo'),(2,'Oficina Canelones',NULL,'Canelones'),(3,'Oficina Maldonado',NULL,'Maldonado'),(4,'Oficina Treinta y Tres',NULL,'Treinta y Tres'),(5,'Oficina Cerro Largo',NULL,'Melo'),(6,'Oficina Rivera','calle Rivera','Rivera'),(7,'Oficina Artigas',NULL,'Artigas'),(8,'Oficina Salto',NULL,'Salto'),(9,'Oficina Paysand├║',NULL,'Paysand├║'),(10,'Oficina R├¡o Negro',NULL,'Fray Bentos'),(11,'Oficina Soriano',NULL,'Mercedes'),(12,'Oficina Colonia',NULL,'Colonia del Sacramento'),(13,'Oficina San Jos├®',NULL,'San Jos├® de Mayo'),(14,'Oficina Flores',NULL,'Trinidad'),(15,'Oficina Florida',NULL,'Florida'),(16,'Oficina Durazno',NULL,'Durazno'),(17,'Oficina Lavalleja',NULL,'Minas'),(18,'Oficina Tacuaremb├│',NULL,'Tacuaremb├│'),(19,'Oficina Rocha',NULL,'Rocha');
/*!40000 ALTER TABLE `oficinascomerciales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operarios`
--

DROP TABLE IF EXISTS `operarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operarios` (
  `OperarioID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) DEFAULT NULL,
  `Apellido` varchar(100) DEFAULT NULL,
  `OficinaID` int DEFAULT NULL,
  PRIMARY KEY (`OperarioID`),
  KEY `OficinaID` (`OficinaID`),
  CONSTRAINT `operarios_ibfk_1` FOREIGN KEY (`OficinaID`) REFERENCES `oficinascomerciales` (`OficinaID`)
) ENGINE=InnoDB AUTO_INCREMENT=280 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operarios`
--

LOCK TABLES `operarios` WRITE;
/*!40000 ALTER TABLE `operarios` DISABLE KEYS */;
INSERT INTO `operarios` VALUES (204,'Nombre001','Apellido001',1),(205,'Nombre002','Apellido002',1),(206,'Nombre003','Apellido003',1),(207,'Nombre004','Apellido004',1),(208,'Nombre005','Apellido005',2),(209,'Nombre006','Apellido006',2),(210,'Nombre007','Apellido007',2),(211,'Nombre008','Apellido008',2),(212,'Nombre009','Apellido009',3),(213,'Nombre010','Apellido010',3),(214,'Nombre011','Apellido011',3),(215,'Nombre012','Apellido012',3),(216,'Nombre013','Apellido013',4),(217,'Nombre014','Apellido014',4),(218,'Nombre015','Apellido015',4),(219,'Nombre016','Apellido016',4),(220,'Nombre017','Apellido017',5),(221,'Nombre018','Apellido018',5),(222,'Nombre019','Apellido019',5),(223,'Nombre020','Apellido020',5),(224,'Nombre021','Apellido021',6),(225,'Nombre022','Apellido022',6),(226,'Nombre023','Apellido023',6),(227,'Nombre024','Apellido024',6),(228,'Nombre025','Apellido025',7),(229,'Nombre026','Apellido026',7),(230,'Nombre027','Apellido027',7),(231,'Nombre028','Apellido028',7),(232,'Nombre029','Apellido029',8),(233,'Nombre030','Apellido030',8),(234,'Nombre031','Apellido031',8),(235,'Nombre032','Apellido032',8),(236,'Nombre033','Apellido033',9),(237,'Nombre034','Apellido034',9),(238,'Nombre035','Apellido035',9),(239,'Nombre036','Apellido036',9),(240,'Nombre037','Apellido037',10),(241,'Nombre038','Apellido038',10),(242,'Nombre039','Apellido039',10),(243,'Nombre040','Apellido040',10),(244,'Nombre041','Apellido041',11),(245,'Nombre042','Apellido042',11),(246,'Nombre043','Apellido043',11),(247,'Nombre044','Apellido044',11),(248,'Nombre045','Apellido045',12),(249,'Nombre046','Apellido046',12),(250,'Nombre047','Apellido047',12),(251,'Nombre048','Apellido048',12),(252,'Nombre049','Apellido049',13),(253,'Nombre050','Apellido050',13),(254,'Nombre051','Apellido051',13),(255,'Nombre052','Apellido052',13),(256,'Nombre053','Apellido053',14),(257,'Nombre054','Apellido054',14),(258,'Nombre055','Apellido055',14),(259,'Nombre056','Apellido056',14),(260,'Nombre057','Apellido057',15),(261,'Nombre058','Apellido058',15),(262,'Nombre059','Apellido059',15),(263,'Nombre060','Apellido060',15),(264,'Nombre061','Apellido061',16),(265,'Nombre062','Apellido062',16),(266,'Nombre063','Apellido063',16),(267,'Nombre064','Apellido064',16),(268,'Nombre065','Apellido065',17),(269,'Nombre066','Apellido066',17),(270,'Nombre067','Apellido067',17),(271,'Nombre068','Apellido068',17),(272,'Nombre069','Apellido069',18),(273,'Nombre070','Apellido070',18),(274,'Nombre071','Apellido071',18),(275,'Nombre072','Apellido072',18),(276,'Nombre073','Apellido073',19),(277,'Nombre074','Apellido074',19),(278,'Nombre075','Apellido075',19),(279,'Nombre076','Apellido076',19);
/*!40000 ALTER TABLE `operarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puestosatencion`
--

DROP TABLE IF EXISTS `puestosatencion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `puestosatencion` (
  `PuestoID` int NOT NULL AUTO_INCREMENT,
  `OficinaID` int DEFAULT NULL,
  `NumeroPuesto` int DEFAULT NULL,
  PRIMARY KEY (`PuestoID`),
  KEY `OficinaID` (`OficinaID`),
  CONSTRAINT `puestosatencion_ibfk_1` FOREIGN KEY (`OficinaID`) REFERENCES `oficinascomerciales` (`OficinaID`)
) ENGINE=InnoDB AUTO_INCREMENT=305 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puestosatencion`
--

LOCK TABLES `puestosatencion` WRITE;
/*!40000 ALTER TABLE `puestosatencion` DISABLE KEYS */;
INSERT INTO `puestosatencion` VALUES (208,2,4),(210,2,2),(211,2,1),(212,3,4),(213,3,3),(214,3,2),(215,3,1),(216,4,4),(217,4,3),(218,4,2),(219,4,1),(220,5,4),(221,5,3),(222,5,2),(223,5,1),(225,NULL,3),(226,NULL,2),(227,NULL,1),(228,7,4),(229,7,3),(230,7,2),(231,7,1),(232,8,4),(233,8,3),(234,8,2),(235,8,1),(236,9,4),(237,9,3),(238,9,2),(239,9,1),(240,10,4),(241,10,3),(242,10,2),(243,10,1),(244,11,4),(245,11,3),(246,11,2),(247,11,1),(248,12,4),(249,12,3),(250,12,2),(251,12,1),(252,13,4),(253,13,3),(254,13,2),(255,13,1),(256,14,4),(257,14,3),(258,14,2),(259,14,1),(260,15,4),(261,15,3),(262,15,2),(263,15,1),(264,16,4),(265,16,3),(266,16,2),(267,16,1),(268,17,4),(269,17,3),(270,17,2),(271,17,1),(272,18,4),(273,18,3),(274,18,2),(275,18,1),(276,19,4),(277,19,3),(278,19,2),(279,19,1),(284,2,1),(289,1,1);
/*!40000 ALTER TABLE `puestosatencion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tramite`
--

DROP TABLE IF EXISTS `tramite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tramite` (
  `TramiteID` int NOT NULL AUTO_INCREMENT,
  `DescripcionTramite` varchar(100) NOT NULL,
  PRIMARY KEY (`TramiteID`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tramite`
--

LOCK TABLES `tramite` WRITE;
/*!40000 ALTER TABLE `tramite` DISABLE KEYS */;
INSERT INTO `tramite` VALUES (41,'Renovaci├│n de licencia de conducir'),(42,'Transferencia de propiedad de veh├¡culo'),(43,'Pago de patente de rodados'),(44,'Solicitud de permiso de circulaci├│n'),(45,'Inspecci├│n t├®cnica vehicular'),(46,'Empadronamiento de veh├¡culo nuevo'),(47,'Baja de veh├¡culo'),(48,'Duplicado de libreta de propiedad'),(49,'Cambio de categor├¡a de licencia de conducir'),(50,'Solicitud de matr├¡cula personalizada'),(51,'Denuncia de venta de veh├¡culo'),(52,'Certificado de antecedentes de tr├ínsito'),(53,'Solicitud de libreta internacional de conducir'),(54,'Cambio de motor'),(55,'Autorizaci├│n para conducir en el extranjero'),(56,'Reempadronamiento de veh├¡culo'),(57,'Solicitud de exoneraci├│n de patente'),(58,'Cambio de caracter├¡sticas del veh├¡culo'),(59,'Duplicado de matr├¡cula'),(60,'Consulta de infracciones de tr├ínsito');
/*!40000 ALTER TABLE `tramite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Final view structure for view `cantatencionestramite`
--

/*!50001 DROP VIEW IF EXISTS `cantatencionestramite`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = cp850 */;
/*!50001 SET character_set_results     = cp850 */;
/*!50001 SET collation_connection      = cp850_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `cantatencionestramite` AS select count(`atenciones`.`AtencionID`) AS `CantAtenciones`,`tramite`.`TramiteID` AS `TramiteID`,`tramite`.`DescripcionTramite` AS `DescripcionTramite` from (`tramite` join `atenciones` on((`tramite`.`TramiteID` = `atenciones`.`TramiteID`))) group by `tramite`.`TramiteID` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-02 22:50:10
