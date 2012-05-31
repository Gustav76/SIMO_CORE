CREATE DATABASE  IF NOT EXISTS `simo im` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `simo im`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: simo im
-- ------------------------------------------------------
-- Server version	5.5.24

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `ID_USUARIO` int(11) NOT NULL AUTO_INCREMENT,
  `USUARIO` char(255) NOT NULL,
  `CLAVE_USUARIO` char(255) NOT NULL,
  `NOMBRES` char(255) NOT NULL,
  `APELLIDOS` char(255) DEFAULT NULL,
  `FECHA_NACIMIENTO` date DEFAULT NULL,
  `FECHA_INGRESO` date DEFAULT NULL,
  `FECHA_DESLIGADO` date DEFAULT NULL,
  `ESTADO` smallint(6) NOT NULL,
  `GRUPOS` smallint(6) NOT NULL,
  PRIMARY KEY (`ID_USUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='Es la entidad base del sistema, consiste en los usuarios dir';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`ID_USUARIO`, `USUARIO`, `CLAVE_USUARIO`, `NOMBRES`, `APELLIDOS`, `FECHA_NACIMIENTO`, `FECHA_INGRESO`, `FECHA_DESLIGADO`, `ESTADO`, `GRUPOS`) VALUES (1,'root','1a1dc91c907325c69271ddf0c944bc72','Administrador',NULL,NULL,NULL,NULL,0,7),(2,'roddy','1a1dc91c907325c69271ddf0c944bc72','Roddy Benjamín','González Garcés','1989-03-01','2012-05-27',NULL,0,7),(3,'perico','1a1dc91c907325c69271ddf0c944bc72','Perico','De los Palotes',NULL,NULL,'2012-05-27',1,1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema_objetivo`
--

DROP TABLE IF EXISTS `sistema_objetivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema_objetivo` (
  `ID_SISTEMA_OBJERIVO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_SISTEMA_OBJETIVO` char(255) NOT NULL,
  `DIRECCION_SISTEMA_OBJETIVO` char(255) NOT NULL,
  PRIMARY KEY (`ID_SISTEMA_OBJERIVO`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistema_objetivo`
--

LOCK TABLES `sistema_objetivo` WRITE;
/*!40000 ALTER TABLE `sistema_objetivo` DISABLE KEYS */;
INSERT INTO `sistema_objetivo` (`ID_SISTEMA_OBJERIVO`, `NOMBRE_SISTEMA_OBJETIVO`, `DIRECCION_SISTEMA_OBJETIVO`) VALUES (1,'Sistema de pruebas 1','localhost'),(2,'Sistema de pruebas 2','mail.server.net'),(3,'MySQL dev','10.0.0.255');
/*!40000 ALTER TABLE `sistema_objetivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_identidad_sistema_objetivo`
--

DROP TABLE IF EXISTS `detalle_identidad_sistema_objetivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `detalle_identidad_sistema_objetivo` (
  `ID_DETALLE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_IDENTIDAD` int(11) NOT NULL,
  `ID_SISTEMA_OBJERIVO` int(11) NOT NULL,
  PRIMARY KEY (`ID_DETALLE`),
  KEY `FK_CONECTA` (`ID_IDENTIDAD`),
  KEY `FK_DETALLA` (`ID_SISTEMA_OBJERIVO`),
  CONSTRAINT `FK_CONECTA` FOREIGN KEY (`ID_IDENTIDAD`) REFERENCES `identidad` (`ID_IDENTIDAD`),
  CONSTRAINT `FK_DETALLA` FOREIGN KEY (`ID_SISTEMA_OBJERIVO`) REFERENCES `sistema_objetivo` (`ID_SISTEMA_OBJERIVO`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_identidad_sistema_objetivo`
--

LOCK TABLES `detalle_identidad_sistema_objetivo` WRITE;
/*!40000 ALTER TABLE `detalle_identidad_sistema_objetivo` DISABLE KEYS */;
INSERT INTO `detalle_identidad_sistema_objetivo` (`ID_DETALLE`, `ID_IDENTIDAD`, `ID_SISTEMA_OBJERIVO`) VALUES (1,1,1),(2,1,2),(3,2,1),(4,2,2);
/*!40000 ALTER TABLE `detalle_identidad_sistema_objetivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `respuesta_campo`
--

DROP TABLE IF EXISTS `respuesta_campo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `respuesta_campo` (
  `ID_RESPUESTA` int(11) NOT NULL AUTO_INCREMENT,
  `ID_SOLICITUD` int(11) NOT NULL,
  `ID_CAMPO_FORMULARIO` int(11) NOT NULL,
  `VALOR_CAMPO` char(255) DEFAULT NULL,
  PRIMARY KEY (`ID_RESPUESTA`),
  KEY `FK_ASOCIADO_A_RESPUESTA` (`ID_SOLICITUD`),
  KEY `FK_RESPONDE` (`ID_CAMPO_FORMULARIO`),
  CONSTRAINT `FK_ASOCIADO_A_RESPUESTA` FOREIGN KEY (`ID_SOLICITUD`) REFERENCES `solicitud_de_acceso` (`ID_SOLICITUD`),
  CONSTRAINT `FK_RESPONDE` FOREIGN KEY (`ID_CAMPO_FORMULARIO`) REFERENCES `campo_formulario` (`ID_CAMPO_FORMULARIO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `respuesta_campo`
--

LOCK TABLES `respuesta_campo` WRITE;
/*!40000 ALTER TABLE `respuesta_campo` DISABLE KEYS */;
/*!40000 ALTER TABLE `respuesta_campo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `identidad`
--

DROP TABLE IF EXISTS `identidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `identidad` (
  `ID_IDENTIDAD` int(11) NOT NULL AUTO_INCREMENT,
  `ID_USUARIO` int(11) NOT NULL,
  `NOMBRE_IDENTIDAD` char(255) NOT NULL,
  `CLAVE_IDENTIDAD` char(255) NOT NULL,
  PRIMARY KEY (`ID_IDENTIDAD`),
  KEY `FK_POSEE` (`ID_USUARIO`),
  CONSTRAINT `FK_POSEE` FOREIGN KEY (`ID_USUARIO`) REFERENCES `usuario` (`ID_USUARIO`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `identidad`
--

LOCK TABLES `identidad` WRITE;
/*!40000 ALTER TABLE `identidad` DISABLE KEYS */;
INSERT INTO `identidad` (`ID_IDENTIDAD`, `ID_USUARIO`, `NOMBRE_IDENTIDAD`, `CLAVE_IDENTIDAD`) VALUES (1,1,'PRIMERA ID','sin clave'),(2,1,'segunda id','sin clave'),(3,2,'Roddy ID',''),(4,1,'tercera id','sin clave');
/*!40000 ALTER TABLE `identidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campo_formulario`
--

DROP TABLE IF EXISTS `campo_formulario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `campo_formulario` (
  `ID_CAMPO_FORMULARIO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PUNTO_APROBACION` int(11) NOT NULL,
  `ETIQUETA` char(255) NOT NULL,
  `POSICION_CAMPO` int(11) NOT NULL,
  PRIMARY KEY (`ID_CAMPO_FORMULARIO`),
  KEY `FK_CONTIENE` (`ID_PUNTO_APROBACION`),
  CONSTRAINT `FK_CONTIENE` FOREIGN KEY (`ID_PUNTO_APROBACION`) REFERENCES `punto_de_aprobacion` (`ID_PUNTO_APROBACION`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campo_formulario`
--

LOCK TABLES `campo_formulario` WRITE;
/*!40000 ALTER TABLE `campo_formulario` DISABLE KEYS */;
/*!40000 ALTER TABLE `campo_formulario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitud_de_acceso`
--

DROP TABLE IF EXISTS `solicitud_de_acceso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `solicitud_de_acceso` (
  `ID_SOLICITUD` int(11) NOT NULL AUTO_INCREMENT,
  `ID_USUARIO` int(11) NOT NULL,
  `ID_PUNTO_APROBACION` int(11) NOT NULL,
  `ESTADO_SOLICITUD` smallint(6) NOT NULL,
  `FECHA_SOLICITUD` date NOT NULL,
  PRIMARY KEY (`ID_SOLICITUD`),
  KEY `FK_SOLICITA` (`ID_USUARIO`),
  KEY `FK_SOLICITA_EN_PUNTO` (`ID_PUNTO_APROBACION`),
  CONSTRAINT `FK_SOLICITA` FOREIGN KEY (`ID_USUARIO`) REFERENCES `usuario` (`ID_USUARIO`),
  CONSTRAINT `FK_SOLICITA_EN_PUNTO` FOREIGN KEY (`ID_PUNTO_APROBACION`) REFERENCES `punto_de_aprobacion` (`ID_PUNTO_APROBACION`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitud_de_acceso`
--

LOCK TABLES `solicitud_de_acceso` WRITE;
/*!40000 ALTER TABLE `solicitud_de_acceso` DISABLE KEYS */;
/*!40000 ALTER TABLE `solicitud_de_acceso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `punto_de_aprobacion`
--

DROP TABLE IF EXISTS `punto_de_aprobacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `punto_de_aprobacion` (
  `ID_PUNTO_APROBACION` int(11) NOT NULL AUTO_INCREMENT,
  `ID_SISTEMA_OBJERIVO` int(11) NOT NULL,
  `ID_USUARIO` int(11) NOT NULL,
  `POSICION_PUNTO_APROBACION` int(11) NOT NULL,
  PRIMARY KEY (`ID_PUNTO_APROBACION`),
  KEY `FK_ASOCIADO` (`ID_SISTEMA_OBJERIVO`),
  KEY `FK_CONTROLA` (`ID_USUARIO`),
  CONSTRAINT `FK_ASOCIADO` FOREIGN KEY (`ID_SISTEMA_OBJERIVO`) REFERENCES `sistema_objetivo` (`ID_SISTEMA_OBJERIVO`),
  CONSTRAINT `FK_CONTROLA` FOREIGN KEY (`ID_USUARIO`) REFERENCES `usuario` (`ID_USUARIO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `punto_de_aprobacion`
--

LOCK TABLES `punto_de_aprobacion` WRITE;
/*!40000 ALTER TABLE `punto_de_aprobacion` DISABLE KEYS */;
/*!40000 ALTER TABLE `punto_de_aprobacion` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-05-27 21:17:09
