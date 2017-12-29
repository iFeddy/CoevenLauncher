<?php
	/** Includes **/
	include('../connect.inc.php');
	require_once('class/class.coeven.php');
	/** Includes **/

	/** Variables **/
	$clientIP = $_SERVER['REMOTE_ADDR'];
	$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
	$log_fecha = date("Y-m-d H:i:s");
	
	if(isset($_GET['1']) && isset($_GET['2']) && isset($_GET['3'])){
	$cUser = trim($_GET['1']);
	$cPass = trim($_GET['2']);
	$cPassVer = trim($_GET['3']);
	$cEmail = trim($_GET['4']);
	}else{
		echo 'Error Interno: #001';
	}
	if($cUser == 'undefined' || $cPass == 'undefined' || $cEmail == 'undefined' || $cPassVer == 'undefined'){
		die('Error: Parametros No Definidos<br><strong>Reinicia la Ventana</strong>');
	}
	/** Variables 	echo $cUser;
	echo "<br>";
	echo $cPass;
	echo "<br>";
	echo $cEmail;
	echo "<br>";
	echo $cPassVer;
	echo "<br>"; **/

	
	// Nos fijamos que no esten vacias las mierdas
	if(empty($cUser) || empty($cPass) || empty($cPassVer) || empty($cEmail)){
		die("Introduce <span class=amarilloslim>todos</span> los Datos!");
	}
	// Nos Fijamos los Datos de Usuario
	else if(!ctype_alnum($cUser)){
		die("No Puedes Utilizar Caracteres Especiales en Tu <span class=amarilloslim>Usuario</span>!");
	}
	else if(strlen($cUser) > 15){
		die( "No puedes utilizar mas de <span class=amarilloslim>15(Quince)</span> Caracteres para tu Usuario, Intenta Nuevamente.");
	}
	else if(strlen($cUser) < 5){
		die( "No puedes utilizar menos de <span class=amarilloslim>5(cinco)</span> Caracteres para tu Usuario, Intenta Nuevamente.");
	}
	else if($cPass != $cPassVer){
		die( "Las <span class=amarilloslim>Contrase&ntilde;as</span> no Coinciden!");
	}
	else if(strlen($cPass) > 15){
		die( "No puedes utilizar mas de <span class=amarilloslim>15(Quince)</span> Caracteres para tu contrase&ntilde;a, Intenta Nuevamente.");
	}
	else if(strlen($cPass) < 6){
		die( "No puedes utilizar menos de <span class=amarilloslim>6(Seis)</span> Caracteres para tu contrase&ntilde;a, Intenta Nuevamente.");
	}
	else if (strpos($cPass,'ñ') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ñ</span> en Tu Contraseña");
	}
	else if (strpos($cPass,'%') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>%</span> en Tu Contraseña");
	}
	else if (strpos($cPass,'\'') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>'</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"<") !== false) {
		die("No puedes utilizar la <span class=amarilloslim><</span> en Tu Contraseña");
	}
	else if (strpos($cPass,">") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>></span> en Tu Contraseña");
	}
	else if (strpos($cPass,"á") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>á</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"é") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>é</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"í") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>í</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"ó") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ó</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"ú") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ú</span> en Tu Contraseña");
	}
	else if (strpos($cPass,"Ñ") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>Ñ</span> en Tu Contraseña");
	}
	else if (strpos($cPass,'\'') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>\'</span> en Tu Contraseña");
	}
	else if (strpos($cPass, "\"") !== false) {
		die('No puedes utilizar la <span class=amarilloslim>&quot;</span> en Tu Contraseña');
	}
	else if (strpos($cPass, "&") !== false) {
		die('No puedes utilizar la <span class=amarilloslim>&</span> en Tu Contraseña');
	}
	// Validamos el Email? 
	else if(!(preg_match("/^[\.A-z0-9_\-\+]+[@][A-z0-9_\-]+([.][A-z0-9_\-]+)+[A-z]{1,4}$/", $cEmail))){
		die("Introduce un <span class=amarilloslim>Email</span> Valido!");
	}

	//Buscamos si el Usuario Existe (De nuevo :C )
	$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cUsername = ?');
	$stmt->bindParam(1, $cUser, PDO::PARAM_STR);
	$stmt->execute();
	$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
		{
			die("El usuario se encuentra en uso, reintenta nuevamente");
		}
	//Buscamos si el Email Existe ...
	$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cEmail = ?');
	$stmt->bindParam(1, $cEmail, PDO::PARAM_STR);
	$stmt->execute();
	$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
		{
			die("El email se encuentra en uso, reintenta nuevamente");
		}
		
	$date = date ("Y-m-d H:i:s");

	//Todo OK (Guardamos la cuenta)
	$coeven = new Coeven();
	
	$cPassHash = md5($cPass);
	$coeven->crearUsuario($cUser,$cPass,$cPassHash,$cEmail);
	
	//Por ultimo creamos un codigo de Verificacion :(
	
	$miCodigo = $coeven->crearVerificacion();
	
	$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cUsername = ?');
	$stmt->bindParam(1, $cUser, PDO::PARAM_STR);
	$stmt->execute();
	$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if(!$row)
		{
			die("Error Interno: Error Creando Cuenta (Contacta con un Administrador para verificar)");
		}
		else
		{
			$stmt = $db->prepare('INSERT INTO `cvn_verification` (`UserID`, `VerificationCode`, `DateCreated`) VALUES (?, ?, ?)');
			$userid = $row['cID'];
			$stmt->bindParam(1, $row['cID'], PDO::PARAM_INT);
			$stmt->bindParam(2, $miCodigo, PDO::PARAM_STR);	
			$stmt->bindParam(3, $date, PDO::PARAM_STR);
			
			$stmt->execute();
		}
	
	$coeven->enviarEmail("VERIFICACION",$cEmail,"no-reply@coeven.com",$userid, $miCodigo);
	die("Cuenta creada con exito. Se ha enviado un correo electronico para verificar.");
	
?>