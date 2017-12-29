<?php
include('../connect.inc.php');
if(isset($_GET['userid'])){
	if(is_numeric($_GET['userid'])){
		$userid = $_GET['userid'];
	}else{
	 $xVariables["title"] = "Error01";
	}
}else{
	 $xVariables["title"] = "Error02";
}
if(isset($_GET['sess'])){
		$token = $_GET['sess'];
	}else{
		 $xVariables["title"] = "Error03";
	}
	if(strlen($token) < 5){
		 $xVariables["title"] = "Error04";
	}
	

//Actualizamos el Token para avisarle al server que estamos conectados
	$tokenAhora = strtotime("now");
	$tokenNuevo = strtotime("now") + 10;
	$log_fecha = date("Y-m-d H:i:s");
	
	$stmt = $db->prepare('SELECT * FROM api_token where cID = ? and cToken = ?');
		$stmt->bindParam(1, $userid, PDO::PARAM_INT);
		$stmt->bindParam(2, $token, PDO::PARAM_STR);
		$stmt->execute();
		$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
			{
				//Borramos Tokens si existen
				$stmt = $db->prepare('DELETE FROM api_token where cID = ?');
				$stmt->bindParam(1, $userid, PDO::PARAM_INT);
				$stmt->execute();
				//Insertamos Token Nuevo
				$stmt = $db->prepare('INSERT INTO api_token (cID, cToken, cBorn, cDie) values (?,?,?,?)');
				$stmt->bindParam(1, $userid, PDO::PARAM_INT);
				$stmt->bindParam(2, $token, PDO::PARAM_STR);
				$stmt->bindParam(3, $log_fecha, PDO::PARAM_STR);
				$stmt->bindParam(4, $tokenNuevo, PDO::PARAM_STR);
				$stmt->execute();
				$xVariables["title"] = "cvnconnectado";
			}
			else{
				$xVariables["title"] = "servererror";
			}
			
			$stmt = $db->prepare('SELECT * FROM api_token where cDie > ?');
			$stmt->bindParam(1, $tokenAhora, PDO::PARAM_INT);
			$stmt->execute();
			$conectados = $stmt->rowCount();

			$xVariables['conectados'] = $conectados;
			
			$stmt = $db->prepare('SELECT * FROM cvn_users');
			$stmt->execute();
			$registrados = $stmt->rowCount();

			$xVariables['registrados'] = $registrados;
			
			//Seleccionamos en la base de datos si es que tiene notificaciones sin leer :D

		$stmt = $db->prepare('SELECT * FROM cvn_ads where TargetID = ? and TargetSeen = 0 order by Indice DESC Limit 1');
		$stmt->bindParam(1, $userid, PDO::PARAM_INT);
		$stmt->execute();
		$row = $stmt->fetch(PDO::FETCH_ASSOC);
		if($row)
			{
				$indice = $row['Indice'];
				$titulo = $row['Titulo'];
				$descripcion = $row['Descripcion'];
				$link = $row['Url']; 
				$imagen = $row['Imagen'];
				$xVariables["title"] = ''.$titulo.'@'.$descripcion.'@'.$link.'@'.$imagen.'';
				$stmt = $db->prepare('UPDATE cvn_ads SET TargetSeen = 1 where Indice = ?');
				$stmt->bindParam(1, $indice, PDO::PARAM_INT);
				$stmt->execute();
			}
			
echo json_encode($xVariables);
?>