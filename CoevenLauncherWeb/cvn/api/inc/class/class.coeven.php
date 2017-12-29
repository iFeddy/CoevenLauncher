<?php
/** Probando Clases en PHP ( No se como saldra :( **/


class Coeven
{

		function crearVerificacion(){
			
			$chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			$str = '';
			$size = strlen( $chars );
			for( $i = 0; $i < 6; $i++ ) {
			$str .= $chars[ rand( 0, $size - 1 ) ];
			}
					
			$code = strtoupper($str);
			
			return $code;
		}
		
		function crearUsuario($cUser,$cPass,$cPassHash,$cEmail){
			include('coeven.connect.php');
			$ip = $_SERVER['REMOTE_ADDR'];
			$date = date ("Y-m-d H:i:s");
			
			//Cuenta COEVEN MYSQL
			$stmt = $db->prepare('INSERT INTO cvn_users (cUsername , cPassword, cPasswordSalt, cEmail, cAuthID, cIP, cDate, cPoints, cVerified) VALUES (?, ?, ?, ?, 1, ?, ?, 0, 0)');
			$stmt->bindParam(1, $cUser, PDO::PARAM_STR);
			$stmt->bindParam(2, $cPass, PDO::PARAM_STR);	
			$stmt->bindParam(3, $cPassHash, PDO::PARAM_STR);
			$stmt->bindParam(4, $cEmail, PDO::PARAM_STR);
			$stmt->bindParam(5, $ip, PDO::PARAM_STR);
			$stmt->bindParam(6, $date, PDO::PARAM_STR);
			$stmt->execute();
			//Cuenta Xelion Online
		
		}
		
		function enviarEmail($theme, $email, $from, $userid , $codigo){
			
			require_once('class.phpmailer.php');
			include("class.smtp.php"); // optional, gets called from within class.phpmailer.php if not already loaded

			$mail = new PHPMailer(true); // the true param means it will throw exceptions on errors, which we need to catch

			$mail->IsSMTP(); // telling the class to use SMTP

			try {
			  $mail->Host       = "smtp.mandrillapp.com"; // SMTP server
			  $mail->SMTPDebug  = 0;                     // enables SMTP debug information (for testing)
			  $mail->SMTPAuth   = true;                  // enable SMTP authentication
			  $mail->Host       = "smtp.mandrillapp.com"; // sets the SMTP server
			  $mail->Port       = 587;                    // set the SMTP port for the GMAIL server
			  $mail->Username   = "coevengames@gmail.com"; // SMTP account username
			  $mail->Password   = "3FSa3y_HdOBJDS5CBEHDhQ";        // SMTP account password
			 
			  $mail->AddAddress($email);
			  $mail->SetFrom($from, 'Coeven Games');

			if($theme == "VERIFICACION"){
				
				$mail->Subject = 'Confirma tu cuenta de Coeven';
			    $mail->MsgHTML('<html style="background-color:#FFF">
				<head>
					<link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">
				</head>
			  <body style="width:90%;margin:0 auto;font-family: \'Open Sans\', sans-serif;">
			  
				<center>
					<img style="max-width: 285px;width: 80%;" src="http://i.imgur.com/cnr8JU2.jpg"></img><br>
					<div style="width:90%;margin: 0 auto;font-size:0.9em;color:#303030;border-bottom:1px solid rgba(228, 177, 177, 1);">
						Bienvenido a <strong>Coeven Games</strong>! <br>
						Te estamos enviando este correo electronico porque recientemente te registraste en <strong>Coeven</strong>, si quieres tener acceso completo a nuestro sistema , 
						confirma tu registro ingresando en el siguiente enlace:<br><br>
						<a href="#">Confirmar Cuenta</a>
						<br><br>Si tienes problemas ingresando al enlace, por favor usa el siguiente codigo desde nuestra web:<br><br>
						<span style="color:rgba(85, 101, 111, 1);"><strong>'.$codigo.'</strong></span>
						<br><br>
					</div>
				</center>
				  <div style="font-size:0.75em;color: rgba(98, 98, 98, 1);"><br><b>CoevenGames</b> -  2014-2015&copy;<br><br>
				  </div>
			  </body>
			</html>');				
			}
			 else if($theme == "FORGOTPASS"){
				 
				 //Buscar datos de la cuenta
				include('coeven.connect.php');
				$ip = $_SERVER['REMOTE_ADDR'];
				$date = date ("Y-m-d H:i:s");
				
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cID = ?');
				$stmt->bindParam(1, $userid, PDO::PARAM_STR);
				$stmt->execute();
				$row = $stmt->fetch(PDO::FETCH_ASSOC);
					if($row)
					{
						$cUser = $row['cUsername'];
						$cPass = $row['cPassword'];
						$cEmail = $row['cEmail'];
					}
		
				$mail->Subject = 'Recuperacion de Cuenta Coeven';
			    $mail->MsgHTML('<html style="background-color:#FFF">
				<head>
					<link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">
				</head>
			  <body style="width:90%;margin:0 auto;font-family: \'Open Sans\', sans-serif;">
			  
				<center>
					<img style="max-width: 285px;width: 80%;" src="http://i.imgur.com/cnr8JU2.jpg"></img><br>
					<div style="width:90%;margin: 0 auto;font-size:0.95em;color:#303030;border-bottom:1px solid rgba(228, 177, 177, 1);">
						Bienvenido a <strong>Coeven Games</strong>! <br>
						Te estamos enviando este correo electronico porque solicitaste <strong>Recuperar Contrase&ntilde;a</strong> los datos de tu cuenta son los siguientes:<br><br>
											
						<div style="text-align:left;width:90%;margin: 0 auto;font-size:0.90em;color:#454545;">
								<u>Datos de Cuenta Coeven</u><br>
								<strong>Usuario:</strong> '.$cUser.'
								<br>
								<strong>Contrase&ntilde;a:</strong> '.$cPass.'
								<br>
								<strong>Correo Electronico:</strong> '.$cEmail.'
								<br><br>
								Por motivos de seguridad, recomendamos que la contrase&ntilde;a sea cambiada lo antes posible.
							</div>
					</div>
				</center>
				  <div style="font-size:0.75em;color: rgba(98, 98, 98, 1);"><br><b>CoevenGames</b> -  2014-2015&copy;<br><br>
				  </div>
			  </body>
			</html>');				
			 }			

			else{
							$mail->Subject('Error');
							$mail->MsgHTML('Error');
					}			 
			 $mail->Send();
			} catch (phpmailerException $e) {
			  echo $e->errorMessage(); //Pretty error messages from PHPMailer
			} catch (Exception $e) {
			  echo $e->getMessage(); //Boring error messages from anything else!
			}
						
		}
}




?>