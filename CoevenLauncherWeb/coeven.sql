/*
Navicat MySQL Data Transfer

Source Server         : LocalHost
Source Server Version : 50527
Source Host           : localhost:3306
Source Database       : coeven

Target Server Type    : MYSQL
Target Server Version : 50527
File Encoding         : 65001

Date: 2015-11-26 20:50:44
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `api_log`
-- ----------------------------
DROP TABLE IF EXISTS `api_log`;
CREATE TABLE `api_log` (
  `Index` int(11) NOT NULL AUTO_INCREMENT,
  `log_user` int(11) NOT NULL,
  `log_token` text NOT NULL,
  `log_ip` text NOT NULL,
  `log_url` text NOT NULL,
  `log_date` datetime NOT NULL,
  `log_type` int(11) NOT NULL,
  PRIMARY KEY (`Index`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of api_log
-- ----------------------------
INSERT INTO `api_log` VALUES ('1', '1', '7nSXJAKE4LHue9AtNsK2ST0a3cJjqzLt', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-08-10 00:43:24', '1');
INSERT INTO `api_log` VALUES ('2', '1', 'iXsJ7Dp8mmNJYLnPrUkjHpoufmMd2leQ', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-08-10 00:43:53', '1');
INSERT INTO `api_log` VALUES ('3', '1', 'EG3V0V2yPUR4dQlsLrRczVefe1P4QWsE', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-08-10 00:45:21', '1');
INSERT INTO `api_log` VALUES ('4', '1', 'ysVdKiBF5Xu3z1iIDBetfg2IU8UeyNAp', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-08-10 00:45:22', '1');
INSERT INTO `api_log` VALUES ('5', '1', 'a4HGJzyEVYPpcoJLyp05q7QdN7Zu8vDK', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:31:51', '1');
INSERT INTO `api_log` VALUES ('6', '1', 'w1enjn3Wd7NMIoFKMKp9SjdSXEPfwSs6', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:39:34', '1');
INSERT INTO `api_log` VALUES ('7', '1', 'oS2u5SRonHazXEr82BEGmSgi8lfz5k5A', '127.0.0.1', 'http://127.1.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:40:26', '1');
INSERT INTO `api_log` VALUES ('8', '1', 'vzOMpP69bg5xhWXNItqfUXILRYyG1CaP', '127.0.0.1', 'http://127.1.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:40:48', '1');
INSERT INTO `api_log` VALUES ('9', '1', 'X7tDsRM4g4q3ii7V4F4yvKZf6E8TPYbN', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:42:03', '1');
INSERT INTO `api_log` VALUES ('10', '1', '7MAJeTRGIEia3b81c44zCnlGhKEGFeeq', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-13 00:42:25', '1');
INSERT INTO `api_log` VALUES ('11', '1', 'dPPV33nCeyNbIUPXYcHNZ160dtgtDaUw', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-19 00:15:42', '1');
INSERT INTO `api_log` VALUES ('12', '1', 'zwyGkaJqYYzbY2jOgWFElNPxabyPcc2m', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:44:57', '1');
INSERT INTO `api_log` VALUES ('13', '1', 'qr0tj0F0OuKjpXte42y7fOdOWSaEAkDt', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:45:02', '1');
INSERT INTO `api_log` VALUES ('14', '1', 'aJkCadtXwmNOJgv2KwjY2dssAXEPQO6X', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:45:41', '1');
INSERT INTO `api_log` VALUES ('15', '1', 'NpwaTOai7DIHVXpdinXcHZAt6o0oYGrO', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:48:01', '1');
INSERT INTO `api_log` VALUES ('16', '1', 'XXGKnQ2dyOojmQlL7pZNGsW7oufX5rx2', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:48:38', '1');
INSERT INTO `api_log` VALUES ('17', '1', 'xfkLJUOKnKGoc6oNpPUyJfHKmeKZ37vl', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 00:51:13', '1');
INSERT INTO `api_log` VALUES ('18', '1', '7OUykyVf38Hl9wPwXbo2k60BzKKqz3de', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:26:45', '1');
INSERT INTO `api_log` VALUES ('19', '1', 'LOQrc4YCvN7YSPh83vTaeGXG9GUL1mK0', '127.0.0.1', 'http://127.0.0.1/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:28:50', '1');
INSERT INTO `api_log` VALUES ('20', '1', 'ExufE8bbWknfk4GabQbalDsX8SCMryfj', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:39:55', '1');
INSERT INTO `api_log` VALUES ('21', '1', 'F9hOhKykRSwqeuLOK5oIgB0R6xFr8P0c', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:47:41', '1');
INSERT INTO `api_log` VALUES ('22', '1', 'zPNTXDCE4R3jARBYKtbfg2jcmpVsKWw5', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:52:43', '1');
INSERT INTO `api_log` VALUES ('23', '1', 'MGGJaQSqFImyv86Jnsx2vvG3DEXTXJn9', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:55:33', '1');
INSERT INTO `api_log` VALUES ('24', '1', 'LuiSCtuiTdLINA6J4UZrU1mr3iHOHyXa', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 01:56:25', '1');
INSERT INTO `api_log` VALUES ('25', '1', 'xbBKJeYBcQRCM2QtPf2pat0999QTDgan', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 02:01:31', '1');
INSERT INTO `api_log` VALUES ('26', '1', 't5T3ZPHymSmEWHXzAh62C4SgU2RZLFbo', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 02:02:42', '1');
INSERT INTO `api_log` VALUES ('27', '1', 'r04dxocpl4MVHZntXC7jWWA71pR720y3', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-27 02:04:00', '1');
INSERT INTO `api_log` VALUES ('28', '1', 'Iaa2huPyM54ypNTFTXJYsqz4OxS2b8Cu', '127.0.0.1', 'http://127.0.0.1/cvnLauncher/cvn/api/launcher.inc.php?token=cvnapilchr&action=cvnlogin&user=Tronic&pass=01010110101010110101010101101', '2015-10-28 01:41:06', '1');

-- ----------------------------
-- Table structure for `api_token`
-- ----------------------------
DROP TABLE IF EXISTS `api_token`;
CREATE TABLE `api_token` (
  `Index` int(11) NOT NULL AUTO_INCREMENT,
  `cID` int(11) NOT NULL,
  `cToken` text NOT NULL,
  `cBorn` datetime NOT NULL,
  `cDie` int(11) NOT NULL,
  PRIMARY KEY (`Index`)
) ENGINE=InnoDB AUTO_INCREMENT=9555 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of api_token
-- ----------------------------
INSERT INTO `api_token` VALUES ('3691', '2', '22', '0000-00-00 00:00:00', '1999999999');
INSERT INTO `api_token` VALUES ('9554', '1', 'Iaa2huPyM54ypNTFTXJYsqz4OxS2b8Cu', '2015-10-28 01:41:47', '1445992917');

-- ----------------------------
-- Table structure for `api_version`
-- ----------------------------
DROP TABLE IF EXISTS `api_version`;
CREATE TABLE `api_version` (
  `Index` int(11) NOT NULL AUTO_INCREMENT,
  `api_code` text NOT NULL,
  `api_version` int(11) NOT NULL,
  `api_build` int(11) NOT NULL,
  `api_patch` int(11) NOT NULL,
  `api_fecha` datetime NOT NULL,
  PRIMARY KEY (`Index`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of api_version
-- ----------------------------
INSERT INTO `api_version` VALUES ('1', 'VER0000', '1', '0', '0', '2014-11-29 19:04:04');
INSERT INTO `api_version` VALUES ('2', 'VER0001', '1', '0', '1', '2014-12-25 17:34:09');
INSERT INTO `api_version` VALUES ('3', 'VER0002', '1', '0', '2', '2015-01-03 18:19:51');
INSERT INTO `api_version` VALUES ('4', 'VER0003', '1', '0', '3', '2015-01-15 21:46:02');

-- ----------------------------
-- Table structure for `cvn_ads`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_ads`;
CREATE TABLE `cvn_ads` (
  `Indice` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` text NOT NULL,
  `Descripcion` text NOT NULL,
  `Imagen` text NOT NULL,
  `Url` text NOT NULL,
  `TargetID` int(10) unsigned zerofill NOT NULL,
  `TargetSeen` int(10) unsigned zerofill NOT NULL,
  PRIMARY KEY (`Indice`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_ads
-- ----------------------------
INSERT INTO `cvn_ads` VALUES ('1', 'Conspiraciones y espías en Splinter Cell Conviction 8', 'Otro grandioso género de los videojuegos es el del sigilo o infiltración, típicamente el jugador debe moverse a través de los diferentes niveles sin que el enemigo lo detecte, con ayuda de diferentes dispositivos al estilo de los mejores espías del cine, generalmente este tipo de juego demanda un mayor reto, ', 'http://2.bp.blogspot.com/-GW4MNz52iiM/VLq1dCkwjmI/AAAAAAAAAZM/s-OKVvCC_3E/s1600/Conspiraciones%2By%2Besp%C3%ADas%2Ben%2BSplinter%2BCell%2BConviction%2B-%2B%2BNoticiasMMORPG.jpg', 'http://www.noticiasmmorpg.com/2015/01/conspiraciones-y-espias-en-splinter.html', '0000000001', '0000000001');

-- ----------------------------
-- Table structure for `cvn_installer`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_installer`;
CREATE TABLE `cvn_installer` (
  `cvn_game` int(11) NOT NULL,
  `cvn_iversion` text NOT NULL,
  `cvn_downloaded` int(11) NOT NULL,
  PRIMARY KEY (`cvn_game`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_installer
-- ----------------------------
INSERT INTO `cvn_installer` VALUES ('1', '1.0.0', '20');

-- ----------------------------
-- Table structure for `cvn_maintenance`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_maintenance`;
CREATE TABLE `cvn_maintenance` (
  `cServerID` int(11) NOT NULL AUTO_INCREMENT,
  `cServerStatus` int(11) NOT NULL,
  `cServerCodeName` text NOT NULL,
  `cServerName` text NOT NULL,
  PRIMARY KEY (`cServerID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_maintenance
-- ----------------------------
INSERT INTO `cvn_maintenance` VALUES ('1', '1', 'xelion', 'Xelion Online');
INSERT INTO `cvn_maintenance` VALUES ('2', '1', 'coeven', 'Coeven Games');

-- ----------------------------
-- Table structure for `cvn_notice`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_notice`;
CREATE TABLE `cvn_notice` (
  `Index` int(11) NOT NULL AUTO_INCREMENT,
  `cvn_name` text NOT NULL,
  `cvn_notice` text NOT NULL,
  PRIMARY KEY (`Index`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_notice
-- ----------------------------
INSERT INTO `cvn_notice` VALUES ('1', '<span style=\"color:yellow\">Sistema:</span>', '<strong>Coeven Launcher</strong> ya se encuentra disponible para su descarga');
INSERT INTO `cvn_notice` VALUES ('2', '<span style=\"color:yellow\">Sistema:</span>', 'Comparte en <strong>Facebook</strong> para ganar premios semanales.');
INSERT INTO `cvn_notice` VALUES ('3', '<span style=\"color:yellow\">Sistema:</span>', '<strong>Xelion Online</strong> ya se encuentra disponible para su descarga desde la web oficial de <strong>Coeven</strong>');
INSERT INTO `cvn_notice` VALUES ('4', '<span style=\"color:yellow\">Sistema:</span>', 'Ya se encuentra disponible la version 1.0.3 del Launcher desde la web oficial de <strong>Coeven</strong>');

-- ----------------------------
-- Table structure for `cvn_users`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_users`;
CREATE TABLE `cvn_users` (
  `cID` int(11) NOT NULL AUTO_INCREMENT,
  `cUsername` text NOT NULL,
  `cPassword` text NOT NULL,
  `cPasswordSalt` text NOT NULL,
  `cEmail` text NOT NULL,
  `cPicture` text,
  `cAuthID` int(11) NOT NULL,
  `cIP` text NOT NULL,
  `cDate` datetime NOT NULL,
  `cPoints` int(10) unsigned zerofill NOT NULL,
  `cVerified` int(10) unsigned zerofill NOT NULL,
  PRIMARY KEY (`cID`)
) ENGINE=InnoDB AUTO_INCREMENT=27338 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_users
-- ----------------------------
INSERT INTO `cvn_users` VALUES ('1', 'Tronic', 'xelionpass01', '01010110101010110101010101101', 'tronic@coeven.com', 'http://xelion.coeven.com/es/shop/Recursos/IMG/Profiles/7e3950.jpg', '1', '127.0.0.1', '2013-11-25 00:29:08', '0000010000', '0000000001');
INSERT INTO `cvn_users` VALUES ('27337', 'Tronicb', 'xelionpass01', '01010110101010110101010101101', 'tronicb@coeven.com', null, '1', '127.0.0.1', '2015-08-09 20:57:05', '0000000000', '0000000000');

-- ----------------------------
-- Table structure for `cvn_verification`
-- ----------------------------
DROP TABLE IF EXISTS `cvn_verification`;
CREATE TABLE `cvn_verification` (
  `UserID` int(11) NOT NULL,
  `VerificationCode` text NOT NULL,
  `DateCreated` datetime NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of cvn_verification
-- ----------------------------
INSERT INTO `cvn_verification` VALUES ('27337', 'RWDVXV', '2015-08-09 20:57:04');

-- ----------------------------
-- Table structure for `xel_checksum`
-- ----------------------------
DROP TABLE IF EXISTS `xel_checksum`;
CREATE TABLE `xel_checksum` (
  `Index` int(11) NOT NULL AUTO_INCREMENT,
  `XelionSumCheck` text NOT NULL,
  PRIMARY KEY (`Index`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of xel_checksum
-- ----------------------------
INSERT INTO `xel_checksum` VALUES ('1', '|_,552573|-|8#3,|_00#_2-0,4_72_1');
