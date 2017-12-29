<!DOCTYPE html>
<html>

	<head>
	<title>Coeven Launcher - Cambio de Contraseña</title>
	<link href='http://fonts.googleapis.com/css?family=Ubuntu:300' rel='stylesheet' type='text/css'>
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
		<header>
			<img src="img/cvn_logo.png"></img>
		</header>
		<h1><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Cambio de Contraseña</h1>
		<div id="pretexto">
			Cambia la <strong>contraseña</strong> desde el siguiente panel:
		</div>
		
		<form name="registro" onsubmit="return submitValidate()">
			<img src="img/icon/regpass1.png"></img><input class="input" name="pass1" id="pass1" type="password" placeholder="Contraseña Actual" ></input><br/>
			<img src="img/icon/regpass2.png"></img><input class="input" name="pass2" id="pass2" type="password" placeholder="Contraseña Nueva" =""></input><br/>
			<img src="img/icon/regpass2.png"></img><input class="input" name="pass2" id="pass3" type="password" placeholder="Repetir Contraseña Nueva" =""></input><br/>
			<input class="hidden" name="myToken" type="text" id="token" value="<?php if(isset($_GET['tk'])){ echo $_GET['tk'];} else { echo "TokenError";}?>"></input>
		<div id="notification"><p></p></div>
			<input class="boton azulado" id="submit" type="submit" value="Cambiar Contraseña"></input>
		</form>
		<script src="inc/main_changepass.js" type="text/javascript"></script>
	</body>
	
</html>