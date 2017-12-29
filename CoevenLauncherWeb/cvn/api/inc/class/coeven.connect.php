<?php

	//Configuraciones
	$mysql_host = 'localhost';
	$mysql_user = 'root';
	$mysql_pass = '';
	$mysql_db = 'coeven';
	//Configuraciones

	try{
	$db = new PDO('mysql:host='.$mysql_host.';dbname='.$mysql_db.';charset=utf8', ''.$mysql_user.'', ''.$mysql_pass.'');
	$db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	$db->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
	} catch(PDOException $ex) {
		die("Base de Datos Invalida: (".$ex.")");
	}

?>