/*
SQLyog Community Edition- MySQL GUI v8.15 
MySQL - 5.1.37-community : Database - parkir
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`parkir` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `parkir`;

/*Table structure for table `app` */

DROP TABLE IF EXISTS `app`;

CREATE TABLE `app` (
  `app_id` int(11) NOT NULL AUTO_INCREMENT,
  `company_name` varchar(255) NOT NULL,
  `company_address` varchar(255) NOT NULL,
  `phone_number` varchar(100) NOT NULL,
  `current_motor_tarif_id` int(11) DEFAULT NULL,
  `current_car_tarif_id` int(11) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`app_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `app` */

insert  into `app`(`app_id`,`company_name`,`company_address`,`phone_number`,`current_motor_tarif_id`,`current_car_tarif_id`,`created_at`,`modified_at`) values (1,'PT. Kolang Kaling','Jl. Sore-sore No 12','031-834343',1,2,NULL,NULL);

/*Table structure for table `gate_operations` */

DROP TABLE IF EXISTS `gate_operations`;

CREATE TABLE `gate_operations` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `gate_id` int(11) NOT NULL,
  `price_id` int(11) NOT NULL,
  `start` datetime DEFAULT NULL,
  `end` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

/*Data for the table `gate_operations` */

insert  into `gate_operations`(`id`,`user_id`,`gate_id`,`price_id`,`start`,`end`) values (4,1,2,1,'2009-10-21 15:34:08','2009-10-21 15:34:10'),(5,1,2,1,'2009-10-22 14:19:11',NULL),(6,1,2,1,'2009-10-23 05:22:30','2009-10-23 05:23:24'),(7,1,2,1,'2009-10-23 05:40:23',NULL),(8,1,2,1,'2009-10-23 05:41:53',NULL),(9,1,2,1,'2009-10-23 05:43:07','2009-10-23 05:44:39'),(10,1,2,1,'2009-10-23 06:11:17','2009-10-23 06:20:03'),(11,1,2,1,'2009-10-23 06:58:24',NULL),(12,1,2,1,'2009-10-23 06:59:48','2009-10-23 07:00:33'),(13,1,2,1,'2009-10-23 07:17:06','2009-10-23 07:17:50'),(14,1,2,1,'2009-10-24 12:32:10','2009-10-24 12:32:15'),(15,1,2,1,'2009-10-24 12:37:27','2009-10-24 12:38:36'),(16,1,2,1,'2009-10-28 21:20:13','2009-10-28 21:22:07'),(17,1,2,1,'2009-10-28 21:43:56','2009-10-28 21:44:41'),(18,1,2,1,'2009-11-25 19:32:17','2009-11-25 19:32:22');

/*Table structure for table `gates` */

DROP TABLE IF EXISTS `gates`;

CREATE TABLE `gates` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gate_class` int(1) DEFAULT NULL COMMENT 'mobil = 1, motor =2',
  `gate_type` int(1) NOT NULL COMMENT 'masuk = 1, keluar =2',
  `gate_code` varchar(2) NOT NULL,
  `gate_name` varchar(100) NOT NULL,
  `image_dir` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `gates` */

insert  into `gates`(`id`,`gate_class`,`gate_type`,`gate_code`,`gate_name`,`image_dir`) values (1,2,1,'A','Pintu Masuk Motor',NULL),(2,2,2,'D','Pintu Keluar Motor',NULL);

/*Table structure for table `member_groups` */

DROP TABLE IF EXISTS `member_groups`;

CREATE TABLE `member_groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `member_groups` */

insert  into `member_groups`(`id`,`name`) values (1,'pegawai'),(2,'rekanan');

/*Table structure for table `members` */

DROP TABLE IF EXISTS `members`;

CREATE TABLE `members` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rf_id` varchar(20) NOT NULL,
  `member_group_id` int(1) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `identity_no` varchar(100) DEFAULT NULL,
  `identity_type` varchar(10) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `mobile_phone` varchar(20) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `current_deposit` int(11) DEFAULT NULL,
  `last_deposit_at` datetime DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `members` */

insert  into `members`(`id`,`rf_id`,`member_group_id`,`name`,`identity_no`,`identity_type`,`phone`,`mobile_phone`,`address`,`current_deposit`,`last_deposit_at`,`created_at`,`modified_at`) values (1,';1212121212:',2,'doni','12121121','KTP','031-12121','0812121','Jl. Nangka 10',210000,'2009-10-21 09:44:23','2009-10-21 09:44:23',NULL);

/*Table structure for table `roles` */

DROP TABLE IF EXISTS `roles`;

CREATE TABLE `roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `roles` */

insert  into `roles`(`id`,`role_name`) values (1,'admin'),(2,'operator');

/*Table structure for table `tarifs` */

DROP TABLE IF EXISTS `tarifs`;

CREATE TABLE `tarifs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `group_id` int(11) NOT NULL,
  `initial_price` int(11) NOT NULL,
  `extended_price` int(11) DEFAULT NULL,
  `extended_after` int(2) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tarifs` */

insert  into `tarifs`(`id`,`name`,`group_id`,`initial_price`,`extended_price`,`extended_after`,`created_at`,`modified_at`) values (1,'harga motor',2,1000,1000,3,'2009-10-18 00:00:00','2009-10-24 13:16:13'),(2,'harga mobil',1,5000,2000,3,'2009-10-18 00:00:00',NULL);

/*Table structure for table `tarifs_groups` */

DROP TABLE IF EXISTS `tarifs_groups`;

CREATE TABLE `tarifs_groups` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `group_name` varchar(255) NOT NULL,
  `created_at` datetime DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tarifs_groups` */

insert  into `tarifs_groups`(`id`,`group_name`,`created_at`,`modified_at`) values (1,'Harga Tiket Mobil','2009-10-18 00:00:00',NULL),(2,'Harga Tiket Motor','2009-10-18 00:00:00',NULL);

/*Table structure for table `tickets` */

DROP TABLE IF EXISTS `tickets`;

CREATE TABLE `tickets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gate_in_id` int(11) DEFAULT '-1',
  `gate_out_id` int(11) DEFAULT '-1',
  `gate_out_operator_id` int(11) DEFAULT '-1',
  `member_id` int(11) NOT NULL DEFAULT '-1',
  `ticket_number` varchar(30) DEFAULT NULL,
  `nopol` varchar(15) DEFAULT '',
  `date_in` datetime NOT NULL,
  `date_out` datetime DEFAULT NULL,
  `image_path` varchar(255) DEFAULT NULL,
  `initial_price` int(11) DEFAULT '0',
  `extended_price` int(11) DEFAULT '0',
  `total_price` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

/*Data for the table `tickets` */

insert  into `tickets`(`id`,`gate_in_id`,`gate_out_id`,`gate_out_operator_id`,`member_id`,`ticket_number`,`nopol`,`date_in`,`date_out`,`image_path`,`initial_price`,`extended_price`,`total_price`) values (9,1,2,1,-1,'A091024123653','','2009-10-24 12:36:53','2009-10-28 21:21:56','A091024123653.jpg',10000,101000,111000),(10,1,-1,-1,-1,'A091024123655','','2009-10-24 12:36:55',NULL,'A091024123655.jpg',10000,0,0),(11,1,-1,-1,-1,'A091024124632','','2009-10-24 12:46:32',NULL,'A091024124632.jpg',10000,0,0),(12,1,-1,-1,-1,'A091024124856','','2009-10-24 12:48:56',NULL,'A091024124856.jpg',10000,0,0),(13,1,-1,-1,-1,'A091024124900','','2009-10-24 12:49:00',NULL,'A091024124900.jpg',10000,0,0),(14,1,-1,-1,-1,'A091024124902','','2009-10-24 12:49:02',NULL,'A091024124902.jpg',10000,0,0),(15,1,-1,-1,-1,'A091024125447','','2009-10-24 12:54:47',NULL,'A091024125447.jpg',10000,0,0),(16,1,-1,-1,-1,'A091024125828','','2009-10-24 12:58:28',NULL,'A091024125828.jpg',10000,0,0),(17,1,-1,-1,-1,'A091024125830','','2009-10-24 12:58:30',NULL,'A091024125830.jpg',10000,0,0),(18,1,-1,-1,-1,'A091024125832','','2009-10-24 12:58:32',NULL,'A091024125832.jpg',10000,0,0),(19,1,-1,-1,-1,'A091024125834','','2009-10-24 12:58:34',NULL,'A091024125834.jpg',10000,0,0),(20,1,-1,-1,-1,'A091024125836','','2009-10-24 12:58:36',NULL,'A091024125836.jpg',10000,0,0),(21,1,-1,-1,-1,'A091024125837','','2009-10-24 12:58:37',NULL,'A091024125837.jpg',10000,0,0),(22,1,-1,-1,-1,'A091024125839','','2009-10-24 12:58:39',NULL,'A091024125839.jpg',10000,0,0),(23,1,-1,-1,-1,'A091024125841','','2009-10-24 12:58:41',NULL,'A091024125841.jpg',10000,0,0),(24,1,-1,-1,-1,'A091024125842','','2009-10-24 12:58:42',NULL,'A091024125842.jpg',10000,0,0),(25,1,-1,-1,-1,'A091024125844','','2009-10-24 12:58:44',NULL,'A091024125844.jpg',10000,0,0),(26,1,-1,-1,-1,'A091024125902','','2009-10-24 12:59:02',NULL,'A091024125902.jpg',10000,0,0),(27,1,-1,-1,-1,'A091028211747','','2009-10-28 21:17:48',NULL,'A091028211747.jpg',1000,0,0),(28,1,-1,-1,-1,'A091028211821','','2009-10-28 21:18:21',NULL,'A091028211821.jpg',1000,0,0);

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role_id` int(1) DEFAULT NULL,
  `member_id` int(11) DEFAULT '-1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `users` */

insert  into `users`(`id`,`username`,`password`,`role_id`,`member_id`) values (1,'susanto','*84960FAE8D87B055BF88A71F8FA3B7A675CCE5BF',1,-1),(2,'bejo','*C0E95152E4F94AAFC8F5C8346714C4B06FBDCC11',2,-1);

/* Procedure structure for procedure `all_users` */

/*!50003 DROP PROCEDURE IF EXISTS  `all_users` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `all_users`(in na char(20))
begin 
  select username, password from users
  where username like na;
end */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
