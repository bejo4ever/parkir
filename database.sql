/*
SQLyog Community Edition- MySQL GUI v8.16 
MySQL - 5.0.45-community-nt : Database - hibernate
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

DROP DATABASE `parkir`;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`parkir` /*!40100 DEFAULT CHARACTER SET latin1 */;

/*Table structure for table `app` */


USE `parkir`;

DROP TABLE IF EXISTS `app`;

CREATE TABLE `app` (
  `app_id` int(11) NOT NULL auto_increment,
  `company_name` varchar(255) NOT NULL,
  `company_address` varchar(255) NOT NULL,
  `phone_number` varchar(100) NOT NULL,
  `current_motor_tarif_id` int(11) default NULL,
  `current_car_tarif_id` int(11) default NULL,
  `created_at` datetime default NULL,
  `modified_at` datetime default NULL,
  PRIMARY KEY  (`app_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `app` */

insert  into `app`(`app_id`,`company_name`,`company_address`,`phone_number`,`current_motor_tarif_id`,`current_car_tarif_id`,`created_at`,`modified_at`) values (1,'PT. Kolang Kaling','Jl. Sore-sore No 12','031-834343',1,2,NULL,NULL);

/*Table structure for table `gate_operations` */

DROP TABLE IF EXISTS `gate_operations`;

CREATE TABLE `gate_operations` (
  `id` int(11) NOT NULL auto_increment,
  `user_id` int(11) NOT NULL,
  `gate_id` int(11) NOT NULL,
  `price_id` int(11) NOT NULL,
  `start` datetime default NULL,
  `end` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `gate_operations` */

insert  into `gate_operations`(`id`,`user_id`,`gate_id`,`price_id`,`start`,`end`) values (4,1,2,1,'2009-10-21 15:34:08','2009-10-21 15:34:10'),(5,1,2,1,'2009-10-22 14:19:11',NULL);

/*Table structure for table `gates` */

DROP TABLE IF EXISTS `gates`;

CREATE TABLE `gates` (
  `id` int(11) NOT NULL auto_increment,
  `gate_class` int(1) default NULL COMMENT 'mobil = 1, motor =2',
  `gate_type` int(1) NOT NULL COMMENT 'masuk = 1, keluar =2',
  `gate_code` varchar(2) NOT NULL,
  `gate_name` varchar(100) NOT NULL,
  `image_dir` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `gates` */

insert  into `gates`(`id`,`gate_class`,`gate_type`,`gate_code`,`gate_name`,`image_dir`) values (1,2,1,'A','Pintu Masuk Motor',NULL),(2,2,2,'D','Pintu Keluar Motor',NULL);

/*Table structure for table `member_groups` */

DROP TABLE IF EXISTS `member_groups`;

CREATE TABLE `member_groups` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(100) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `member_groups` */

insert  into `member_groups`(`id`,`name`) values (1,'pegawai'),(2,'rekanan');

/*Table structure for table `members` */

DROP TABLE IF EXISTS `members`;

CREATE TABLE `members` (
  `id` int(11) NOT NULL auto_increment,
  `rf_id` varchar(20) NOT NULL,
  `member_group_id` int(1) NOT NULL,
  `name` varchar(100) default NULL,
  `identity_no` varchar(100) default NULL,
  `identity_type` varchar(10) default NULL,
  `phone` varchar(20) default NULL,
  `mobile_phone` varchar(20) default NULL,
  `address` varchar(100) default NULL,
  `current_deposit` int(11) default NULL,
  `last_deposit_at` datetime default NULL,
  `created_at` datetime default NULL,
  `modified_at` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `members` */

insert  into `members`(`id`,`rf_id`,`member_group_id`,`name`,`identity_no`,`identity_type`,`phone`,`mobile_phone`,`address`,`current_deposit`,`last_deposit_at`,`created_at`,`modified_at`) values (1,';1212121212:',2,'doni','12121121','KTP','031-12121','0812121','Jl. Nangka 10',10000,'2009-10-21 09:44:23','2009-10-21 09:44:23',NULL);

/*Table structure for table `roles` */

DROP TABLE IF EXISTS `roles`;

CREATE TABLE `roles` (
  `id` int(11) NOT NULL auto_increment,
  `role_name` varchar(100) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `roles` */

insert  into `roles`(`id`,`role_name`) values (1,'admin'),(2,'operator');

/*Table structure for table `tarifs` */

DROP TABLE IF EXISTS `tarifs`;

CREATE TABLE `tarifs` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(255) default NULL,
  `group_id` int(11) NOT NULL,
  `initial_price` int(11) NOT NULL,
  `extended_price` int(11) default NULL,
  `extended_after` int(2) default NULL,
  `created_at` datetime default NULL,
  `modified_at` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tarifs` */

insert  into `tarifs`(`id`,`name`,`group_id`,`initial_price`,`extended_price`,`extended_after`,`created_at`,`modified_at`) values (1,'harga motor',2,10000,1000,3,'2009-10-18 00:00:00','2009-10-19 15:02:15'),(2,'harga mobil',1,5000,2000,3,'2009-10-18 00:00:00',NULL);

/*Table structure for table `tarifs_groups` */

DROP TABLE IF EXISTS `tarifs_groups`;

CREATE TABLE `tarifs_groups` (
  `id` int(11) NOT NULL auto_increment,
  `group_name` varchar(255) NOT NULL,
  `created_at` datetime default NULL,
  `modified_at` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tarifs_groups` */

insert  into `tarifs_groups`(`id`,`group_name`,`created_at`,`modified_at`) values (1,'Harga Tiket Mobil','2009-10-18 00:00:00',NULL),(2,'Harga Tiket Motor','2009-10-18 00:00:00',NULL);

/*Table structure for table `tickets` */

DROP TABLE IF EXISTS `tickets`;

CREATE TABLE `tickets` (
  `id` int(11) NOT NULL auto_increment,
  `gate_in_id` int(11) default NULL,
  `gate_out_id` int(11) default NULL,
  `gate_out_operator_id` int(11) default NULL,
  `member_id` int(11) NOT NULL default '-1',
  `ticket_number` varchar(30) default NULL,
  `date_in` datetime NOT NULL,
  `date_out` datetime default NULL,
  `image_path` varchar(255) default NULL,
  `initial_price` int(11) default NULL,
  `extended_price` int(11) default '0',
  `total_price` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `tickets` */

insert  into `tickets`(`id`,`gate_in_id`,`gate_out_id`,`gate_out_operator_id`,`member_id`,`ticket_number`,`date_in`,`date_out`,`image_path`,`initial_price`,`extended_price`,`total_price`) values (1,1,NULL,NULL,-1,'A091021124610','2009-10-21 12:46:10',NULL,'A091021124610.jpg',10000,0,NULL),(2,1,NULL,NULL,-1,'A091021140017','2009-10-21 14:00:17',NULL,'A091021140017.jpg',10000,0,NULL),(3,1,NULL,NULL,-1,'A091021142042','2009-10-21 14:20:42',NULL,'A091021142042.jpg',10000,0,NULL),(4,1,NULL,NULL,-1,'A091021142106','2009-10-21 14:21:06',NULL,'A091021142106.jpg',10000,0,NULL);

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int(11) NOT NULL auto_increment,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role_id` int(1) default NULL,
  `member_id` int(11) default '-1',
  PRIMARY KEY  (`id`)
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
