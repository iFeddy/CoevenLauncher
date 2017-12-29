<?php
	/** Includes **/
	include('../connect.inc.php');
	/** Includes **/

	/** Variables **/
	$clientIP = $_SERVER['REMOTE_ADDR'];
	$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
	$log_fecha = date("Y-m-d H:i:s");
	/** Variables **/
	
	if(isset($_GET['cUser'])){
		$user = $_GET['cUser'];
		if(strlen ($user) > 4){
			$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cUsername = ?');
			$stmt->bindParam(1, $user, PDO::PARAM_STR);
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if($row)
			{
				echo 'si';
			}else{
				echo 'no';
			}
		}else{
		echo 'no';
		}
	}
	else{
	
		if(isset($_GET['cEmail'])){
			$email = $_GET['cEmail'];
			if(strlen ($email) > 4){
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cEmail = ?');
				$stmt->bindParam(1, $email, PDO::PARAM_STR);
				$stmt->execute();
				$row = $stmt->fetch(PDO::FETCH_ASSOC);
				if($row)
				{
					echo 'si';
				}else{
					echo 'no';
				}
			}else{
			echo 'no';
			}
		}
		else{
		echo 'no';
		}
	}
?>