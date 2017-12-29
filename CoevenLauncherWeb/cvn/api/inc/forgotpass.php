<?php

if(isset($_GET['req'])){
//Pagina de enviar Email [Post]
 if($_GET['req'] == 'recoverPass'){
		//Verificar Datos
		$User = $_POST['cuser'];
		if(trim($User) != ""){
		/** Revisamos Login **/
		try{
			if(!(filter_var($User, FILTER_VALIDATE_EMAIL))) {
				//si lo que pone es usuario
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cUsername = ? ');
			}else{
				//puso email
				$stmt = $db->prepare('SELECT * FROM cvn_users WHERE cEmail = ? ');
			}
			$stmt->bindParam(1, $User, PDO::PARAM_STR);
	
			$stmt->execute();
			$row = $stmt->fetch(PDO::FETCH_ASSOC);
			if(!$row)
			{
						 	echo'
	<!DOCTYPE html>
<html style="min-height:0;">

	<head>
	<title>Coeven Launcher - Recuperar Contraseña</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/registro.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	</head>
	
	<body>
		<header style"margin-bottom:-25px;">
			<img WIDTH="100" src="img/cvn_logo.png"></img>
		</header>
	<h1 style="margin-top:-15px;font-size: 16px;" ><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Recuperar Contraseña</h1>
	<div id="pretexto">
		Introduce tu nombre de usuario o correo electronico para continuar
		</div>
		
		<form name="registro" method="POST" action="?act=cvnforgot&req=recoverPass">
			<img src="img/icon/regemail.png"></img><input class="input" name="cuser" id="cuser" type="text" placeholder="Usuario o Correo Electronico"></input>
			<input class="boton azulado" id="submit" type="submit" value="Enviar"></input>
			<div id="notification" style="display:block;"><p>No se ha encontrado el usuario en nuestra base de datos</p></div>
		</form>
		
	</body>
	
</html>';
			}
			else{
				//El usuario existe
				$userid = $row['cID'];
				$username = $row['cUsername'];
				$email = $row['cEmail'];
				$codigo = '00';
				include_once('class/class.coeven.php');
				$coeven = new Coeven();
				$coeven-> enviarEmail("FORGOTPASS", $email, "no-reply@coeven.com", $userid , $codigo);
				
			echo '<!DOCTYPE html>
	<html style="min-height:0;">

	<head>
	<title>Coeven Launcher - Correo Electronico Enviado</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/registro.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	</head>
	
	<body>
		<header style"margin-bottom:-25px;">
			<img WIDTH="100" src="img/cvn_logo.png"></img>
		</header>
		<h1 style="margin-top:-15px;font-size: 16px;" ><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Correo Electronico Enviado</h1>
			<div id="pretexto">
			Se ha enviado un correo electronico a la siguiente cuenta:
			</div>
			<form name="registro" onsubmit="return submitValidate()">
				Usuario: ****'.substr($username, 5).'<br>
				Correo Electronico: ****'.substr($email, 5).'<br>
				<div id="notification" style="display:block;"><p>Revisa tu correo electronico para recuperar tus datos</p></div>
			</form>
			';
			
			}
		}catch(PDOException $ex) {
				 	echo'
	<!DOCTYPE html>
<html style="min-height:0;">

	<head>
	<title>Coeven Launcher - Recuperar Contraseña</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/registro.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	</head>
	
	<body>
		<header style"margin-bottom:-25px;">
			<img WIDTH="100" src="img/cvn_logo.png"></img>
		</header>
	<h1 style="margin-top:-15px;font-size: 16px;" ><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Recuperar Contraseña</h1>
	<div id="pretexto">
		Introduce tu nombre de usuario o correo electronico para continuar
		</div>
		
		<form name="registro" method="POST" action="?act=cvnforgot&req=recoverPass">
			<img src="img/icon/regemail.png"></img><input class="input" name="cuser" id="cuser" type="text" placeholder="Usuario o Correo Electronico"></input>
			<input class="boton azulado" id="submit" type="submit" value="Enviar"></input>
			<div id="notification" style="display:block;" class="titulo" title="'.$ex.'"><p>No usar caracteres especiales (Ver Error)</p></div>
		</form>
		
	</body>
	
</html>';
			
		}	
		/** Revisamos Login **/
	}
		else{
		 //User vacio
		 	echo'
	<!DOCTYPE html>
<html style="min-height:0;">

	<head>
	<title>Coeven Launcher - Recuperar Contraseña</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/registro.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	</head>
	
	<body>
		<header style"margin-bottom:-25px;">
			<img WIDTH="100" src="img/cvn_logo.png"></img>
		</header>
	<h1 style="margin-top:-15px;font-size: 16px;" ><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Recuperar Contraseña</h1>
	<div id="pretexto">
		Introduce tu nombre de usuario o correo electronico para continuar
		</div>
		
		<form name="registro" method="POST" action="?act=cvnforgot&req=recoverPass">
			<img src="img/icon/regemail.png"></img><input class="input" name="cuser" id="cuser" type="text" placeholder="Usuario o Correo Electronico"></input>
			<input class="boton azulado" id="submit" type="submit" value="Enviar"></input>
			<div id="notification" style="display:block;"><p>Introduce un Usuario o Email Valido para continuar</p></div>
		</form>
		
	</body>
	
</html>';
		}
	}
else{
	die();
}	
}else{

//Pagina Normal
	echo'
	<!DOCTYPE html>
<html style="min-height:0;">

	<head>
	<title>Coeven Launcher - Recuperar Contraseña</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/registro.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	</head>
	
	<body>
		<header style"margin-bottom:-25px;">
			<img WIDTH="100" src="img/cvn_logo.png"></img>
		</header>
	<h1 style="margin-top:-15px;font-size: 16px;" ><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Recuperar Contraseña</h1>
	<div id="pretexto">
		Introduce tu nombre de usuario o correo electronico para continuar
		</div>
		
		<form name="registro" method="POST" action="?act=cvnforgot&req=recoverPass">
			<img src="img/icon/regemail.png"></img><input class="input" name="cuser" id="cuser" type="text" placeholder="Usuario o Correo Electronico"></input>
			<div id="notification" style="display:block;"><p>Recuerda Revisar <strong>"Correo No Deseado"</strong></p></div>
			<input class="boton azulado" id="submit" type="submit" value="Enviar"></input>
		</form>
	
	</body>
	
</html>';
}
?>