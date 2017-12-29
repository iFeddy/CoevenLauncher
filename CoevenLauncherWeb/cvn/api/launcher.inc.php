<?php
/***
 ***   API (Interfaz de programación de aplicaciones)
 ***   Coeven Launcher
 ***   Version 0.01
 ***   Shared Password: cvnapilchr
 ***   Fecha: 24/11/2014
 ***   Salida: usuario,email,auth,fecha,launcherversion,parchehabilitado(?)
 ***/
 die("no");
	
	/** Includes **/
	include('connect.inc.php');
	/** Includes **/	
	/** Variables **/
	$clientIP = $_SERVER['REMOTE_ADDR'];
	$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
	$token = token(32);
	$log_fecha = date("Y-m-d H:i:s");
	/** Variables **/
	
	
	/** Variables GET **/
	if(isset($_GET['token'])){
		$tokenInterno = trim($_GET['token']);
	}
	if($tokenInterno != 'cvnapilchr'){
		$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (0,?,?,?,?,3)');
		$stmt->bindParam(1, $token, PDO::PARAM_STR);
		$stmt->bindParam(2, $clientIP, PDO::PARAM_STR);
		$stmt->bindParam(3, $link, PDO::PARAM_STR);
		$stmt->bindParam(4, $log_fecha, PDO::PARAM_STR);
		$stmt->execute();
		die('err=1');
	}
	if($_GET['action'] == 'cvnlogin'){
		if(!(isset($_GET['user']) && isset($_GET['pass']))){
			$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (0,?,?,?,?,4)');
			$stmt->bindParam(1, $token, PDO::PARAM_STR);
			$stmt->bindParam(2, $clientIP, PDO::PARAM_STR);
			$stmt->bindParam(3, $link, PDO::PARAM_STR);
			$stmt->bindParam(4, $log_fecha, PDO::PARAM_STR);
			$stmt->execute();	
			die('err=2');
		}	
		
		$User = trim($_GET['user']);
		$Pass = trim($_GET['pass']);
		
		/** Creamos la Fecha Actual **/
		$tokenDie = strtotime('now') + 120; //2 min dura la session del launcher
		$dias = array("Domingo","Lunes","Martes","Miercoles","Jueves","Viernes","Sábado");
		$meses = array("Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre");
		$fecha = $dias[date('w')]." ".date('d')." de ".$meses[date('n')-1]. " del ".date('Y')." ".date('H').":".date('i').":".date('s')." ".date('a') ;
		/** Fecha: Lunes 24 de Noviembre del 2014 06:38:16 am **/

		/** Vemos si los servidores estan en mantenimiento **/
		try{
			$i = 0;
			foreach($db->query('SELECT * FROM cvn_maintenance order by cServerID ASC') as $row)
			{
				$svd[$i] = [
					"Status" => $row['cServerStatus'],
					"CodeName" => $row['cServerCodeName']
				];
				$i++;
			}
		}
		catch(PDOException $ex) {}
		if($i == 0){
			die('err=3');
		}
		//Si Coeven esta en mantenimiento, no se puede entrar a ningun juego
		if($svd[0]["Status"] == 0){
			die('err=4');
		}
		/** $svd[x] ID y Status 0 = Coeven, 1 = XelionOnline**/
		
		/** Revisamos Login **/
		try{
			if(!(filter_var($User, FILTER_VALIDATE_EMAIL))) {
				//si lo que pone es usuario
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cUsername = ? and cPasswordSalt = ? ');
			}else{
				//puso email
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cEmail = ? and cPasswordSalt = ? ');
			}
			$stmt->bindParam(1, $User, PDO::PARAM_STR);
			$stmt->bindParam(2, $Pass, PDO::PARAM_STR);
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if(!$row)
			{
				$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (0,?,?,?,?,5)');
				$stmt->bindParam(1, $token, PDO::PARAM_STR);
				$stmt->bindParam(2, $clientIP, PDO::PARAM_STR);
				$stmt->bindParam(3, $link, PDO::PARAM_STR);
				$stmt->bindParam(4, $log_fecha, PDO::PARAM_STR);
				$stmt->execute();
				die("err=5");
			}
			else{
				//El usuario existe
				$id = $row['cID'];
				$username = $row['cUsername'];
				$email = $row['cEmail'];
				$auth = $row['cAuthID'];
				$verified = $row['cVerified'];
				$cPoints = $row['cPoints'];
				$cPicture = $row['cPicture'];
				
				if($auth == 0){
					$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (?,?,?,?,?,2)');
					$stmt->bindParam(1, $id, PDO::PARAM_INT);
					$stmt->bindParam(2, $token, PDO::PARAM_STR);
					$stmt->bindParam(3, $clientIP, PDO::PARAM_STR);
					$stmt->bindParam(4, $link, PDO::PARAM_STR);
					$stmt->bindParam(5, $log_fecha, PDO::PARAM_STR);
					$stmt->execute();
					die('err=6');
				}
				if($auth == -1){
					$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (?,?,?,?,?,2)');
					$stmt->bindParam(1, $id, PDO::PARAM_INT);
					$stmt->bindParam(2, $token, PDO::PARAM_STR);
					$stmt->bindParam(3, $clientIP, PDO::PARAM_STR);
					$stmt->bindParam(4, $link, PDO::PARAM_STR);
					$stmt->bindParam(5, $log_fecha, PDO::PARAM_STR);
					$stmt->execute();
					die('err=7');
				}
				//Borramos Tokens si existen
				$stmt = $db->prepare('DELETE FROM api_token where cID = ?');
				$stmt->bindParam(1, $id, PDO::PARAM_INT);
				$stmt->execute();
				//Insertamos Token Nuevo
				$stmt = $db->prepare('INSERT INTO api_token (cID, cToken, cBorn, cDie) values (?,?,?,?)');
				$stmt->bindParam(1, $id, PDO::PARAM_INT);
				$stmt->bindParam(2, $token, PDO::PARAM_STR);
				$stmt->bindParam(3, $log_fecha, PDO::PARAM_STR);
				$stmt->bindParam(4, $tokenDie, PDO::PARAM_STR);
				$stmt->execute();
				
				//hacemos un log de lo que paso OK
				$stmt = $db->prepare('INSERT INTO api_log (log_user, log_token, log_ip, log_url,log_date,log_type) values (?,?,?,?,?,1)');
				$stmt->bindParam(1, $id, PDO::PARAM_INT);
				$stmt->bindParam(2, $token, PDO::PARAM_STR);
				$stmt->bindParam(3, $clientIP, PDO::PARAM_STR);
				$stmt->bindParam(4, $link, PDO::PARAM_STR);
				$stmt->bindParam(5, $log_fecha, PDO::PARAM_STR);
				$stmt->execute();
				
			}
		}catch(PDOException $ex) {
			die($ex);
		}	
		/** Revisamos Login **/
		
		/** Ver Version del Launcher **/
		try{
			$stmt = $db->prepare('SELECT * FROM api_version ORDER BY api_version.`Index` DESC');
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row){
				$c = $row['api_code'];
				$v = $row['api_version'];
				$b = $row['api_build'];
				$p = $row['api_patch'];
				$vd = $row['api_fecha'];
			}else{
				$c = 0;
				$v = 0;
				$b = 0;
				$p = 0;
				$vd = 0;
			}
		}
		catch(PDOException $ex) {
			die('err=3');
		}
			/** Ver Version del Launcher **/
		
		/** Imprimimos todo **/
		echo 'id='.$id.',user='.$username.',email='.$email.',cpoints='.$cPoints.',cpicture='.$cPicture.',auth='.$auth.',verified='.$verified.',token='.$token.',ip='.$clientIP.',fecha='.$fecha.',c='.$c.',v='.$v.',b='.$b.',p='.$p.',vd='.$vd.',timestamp='.$tokenDie.'';
		/** FIN **/
	}
	
	if($_GET['action'] == 'cvnxelver'){
		try{
			$stmt = $db->prepare('SELECT * FROM cvn_installer WHERE cvn_game = 1');
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row){
				$iv = $row['cvn_iversion'];
				$d = $row['cvn_downloaded'];
			}else{
				$iv = 0;
				$d = 0;
			}
		}
		catch(PDOException $ex) {
			die('err=3');
		}
		/** Imprimimos Toda la Info**/
		echo $iv;
		echo "-";
		echo $d;
	}
	
	if($_GET['action'] == 'cvnxeldowncomplete'){
	try{
			$stmt = $db->prepare('UPDATE cvn_installer SET cvn_downloaded = cvn_downloaded + 1 WHERE cvn_game = 1 LIMIT 1');
			$stmt->execute();
		}
		catch(PDOException $ex) {
			die('err=3');
		}
	}
	
		
	if($_GET['action'] == 'cvnupdpoints'){
	$id = $_GET['user'];
	$token = $_GET['ctoken'];
		try{
			$stmt = $db->prepare('SELECT cvn_users.cID, cvn_users.cPoints, api_token.cToken FROM cvn_users Inner Join api_token ON cvn_users.cID = api_token.cID WHERE cvn_users.cID =  ? and api_token.cToken = ?');
			$stmt->bindParam(1, $id, PDO::PARAM_INT);
			$stmt->bindParam(2, $token, PDO::PARAM_STR);
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row){
			echo $row['cPoints'];
			}else{
			echo 'Error';
			}
		}
		catch(PDOException $ex) {
			die('err=3');
		}

	}
	
	if($_GET['action'] == 'cvnchangepass'){
	$id = $_GET['user'];
	$token = $_GET['ctoken'];
	$pass = $_GET['pass'];
	$newpass = $_GET['newpass'];
	/*	try{
			$stmt = $db->prepare('SELECT cvn_users.cID, cvn_users.cPoints, api_token.cToken FROM cvn_users Inner Join api_token ON cvn_users.cID = api_token.cID WHERE cvn_users.cID =  ? and api_token.cToken = ?');
			$stmt->bindParam(1, $id, PDO::PARAM_INT);
			$stmt->bindParam(2, $token, PDO::PARAM_STR);
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row){
			echo $row['cPoints'];
			}else{
			echo 'Error';
			}
		}
		catch(PDOException $ex) {
			die('err=3');
		}
	HACER CAMBIO DE PASS // DEPENDE DEL REGISTRO */
		echo "donePassChanging";
	}
	if($_GET['action'] == 'xelchecksum'){
		try{
			$stmt = $db->prepare('SELECT * FROM xel_checksum');
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row){
			echo $row['XelionSumCheck'];
			}else{
			echo 'Error';
			}
		}
		catch(PDOException $ex) {
			die('err=3');
		}
		
	}
	function token($length){
		$chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		$str = '';	
		$size = strlen( $chars );
		for( $i = 0; $i < $length; $i++ ) {
		$str .= $chars[ rand( 0, $size - 1 ) ];
		}
		return $str;
	}
?>