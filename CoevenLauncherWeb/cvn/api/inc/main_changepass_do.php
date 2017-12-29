<?php
	/** Includes **/
	include('../connect.inc.php');
	require_once('class/class.coeven.php');
	/** Includes **/

	/** Variables **/
	$clientIP = $_SERVER['REMOTE_ADDR'];
	$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
	$log_fecha = date("Y-m-d H:i:s");
	
	if(isset($_GET['1']) && isset($_GET['2']) && isset($_GET['3'])  && isset($_GET['4'])){
	$token = trim($_GET['1']);
	$cPassAct = trim($_GET['2']);
	$cPassNew = trim($_GET['3']);
	$cPassNew0 = trim($_GET['4']);
	}else{
		echo 'Error Interno: #001';
	}
	if($token == 'undefined' || $cPassAct == 'undefined' || $cPassNew == 'undefined' || $cPassNew0 == 'undefined'){
		die('Error: Parametros No Definidos<br><strong>Reinicia la Ventana</strong>');
	}
	
/**	
	echo $token;
	echo "<br>";
	echo $cPassAct;
	echo "<br>";
	echo $cPassNew;
	echo "<br>";
	echo $cPassNew0;
	echo "<br>"; 
**/
	
	// Nos fijamos que no esten vacias las mierdas
	if(empty($token) || empty($cPassAct) || empty($cPassNew) || empty($cPassNew0)){
		die("Introduce <span class=amarilloslim>todos</span> los Datos!");
	}
	else if($cPassAct == $cPassNew){
		die( "Las <span class=amarilloslim>Contrase&ntilde;as</span> ingresadas son iguales a la actual");
	}
	else if($cPassNew != $cPassNew0){
		die( "Las <span class=amarilloslim>Contrase&ntilde;as</span> no Coinciden!");
	}
	else if(strlen($cPassNew) > 15){
		die( "No puedes utilizar mas de <span class=amarilloslim>15(Quince)</span> Caracteres para tu contrase&ntilde;a, Intenta Nuevamente.");
	}
	else if(strlen($cPassNew) < 6){
		die( "No puedes utilizar menos de <span class=amarilloslim>6(Seis)</span> Caracteres para tu contrase&ntilde;a, Intenta Nuevamente.");
	}
	else if (strpos($cPassNew,'ñ') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ñ</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,'%') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>%</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,'\'') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>'</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"<") !== false) {
		die("No puedes utilizar la <span class=amarilloslim><</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,">") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>></span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"á") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>á</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"é") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>é</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"í") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>í</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"ó") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ó</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"ú") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>ú</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,"Ñ") !== false) {
		die("No puedes utilizar la <span class=amarilloslim>Ñ</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew,'\'') !== false) {
		die("No puedes utilizar la <span class=amarilloslim>\'</span> en Tu Contraseña");
	}
	else if (strpos($cPassNew, "\"") !== false) {
		die('No puedes utilizar la <span class=amarilloslim>&quot;</span> en Tu Contraseña');
	}
	else if (strpos($cPassNew, "&") !== false) {
		die('No puedes utilizar la <span class=amarilloslim>&</span> en Tu Contraseña');
	}
	
	$passHashActual = md5($cPassAct);
	$passHashNuevo = md5($cPassNew);
	
	//Buscamos si el Token Existe
	$stmt = $db->prepare('SELECT * FROM api_token WHERE cToken = ?');
	$stmt->bindParam(1, $token, PDO::PARAM_STR);
	$stmt->execute();
	$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
		{
			$cID = $row['cID'];
		}
		else{
			die('Error: Cierra la ventana y reintenta nuevamente');
		}
	
	//Buscamos si el Usuario Existe , verdadero = Cambiamos pass
	$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cID = ? and cPasswordSalt = ?');
	$stmt->bindParam(1, $cID , PDO::PARAM_STR);
	$stmt->bindParam(2, $passHashActual , PDO::PARAM_STR);
	$stmt->execute();
	$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
		{			
			//Cambiamos los valores
			$stmt = $db->prepare('UPDATE cvn_users SET cPassword = ?, cPasswordSalt = ? WHERE cID = ? and cPasswordSalt = ?');
			$stmt->bindParam(1, $cPassNew , PDO::PARAM_STR);
			$stmt->bindParam(2, $passHashNuevo , PDO::PARAM_STR);
			$stmt->bindParam(3, $cID , PDO::PARAM_STR);
			$stmt->bindParam(4, $passHashActual , PDO::PARAM_STR);
			$stmt->execute();
			die('La <span class="amarilloslim">contraseña</span> se ha actualizado con <strong>exito</strong>');
		}
		else{
			die("Contraseña Actual Incorrecta");
		}
	
?>