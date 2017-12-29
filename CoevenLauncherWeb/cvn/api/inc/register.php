<!DOCTYPE html>
<html>

	<head>
	<title>Coeven Launcher - Registro Nuevo</title>
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
		<h1><img style="margin-bottom: -10px; margin-right: 5px;" src="img/icon/regicon.png">Registrar una Nueva Cuenta</h1>
		<div id="pretexto">
			Registrate <strong>Gratis</strong> en la comunidad de juegos MMORPG de Coeven. Utiliza tu E-Mail o conectate con alguna de las redes sociales disponibles:
		</div>
		
		<form name="registro" onsubmit="return submitValidate()">
			<img src="img/icon/reguser.png"></img><input class="input" name="cuser" id="cuser" type="text" placeholder="Usuario" maxlength="16"></input><img id="userAjax" class="hidden" style="float: right;margin-left: -20px;margin-right: -25px;margin-top: 13px;"src="img/icon/ajaxload.gif"></img><img class="titulo" id="siUser" title="Usuario Disponible" style="display:none;cursor:pointer;float: right;margin-left: -20px;margin-right: -20px;margin-top: 15px;"src="img/icon/ajaxok.png"></img><img class="titulo" id="noUser" title="Usuario No Disponible" style="display:none;cursor:pointer;float: right;margin-left: -20px;margin-right: -20px;margin-top: 15px;"src="img/icon/ajaxno.png"></img><br/>
			<img src="img/icon/regemail.png"></img><input class="input" name="cemail"  id="cemail" type="email" placeholder="Correo Electronico" ></input><img id="emailAjax" class="hidden" style="float: right;margin-left: -20px;margin-right: -25px;margin-top: 13px;"src="img/icon/ajaxload.gif"></img><img class="titulo" id="siEmail" title="Correo Electronico Disponible" style="display:none;cursor:pointer;float: right;margin-left: -20px;margin-right: -20px;margin-top: 15px;"src="img/icon/ajaxok.png"></img><img class="titulo" id="noEmail" title="Correo Electronico No Disponible" style="display:none;cursor:pointer;float: right;margin-left: -20px;margin-right: -20px;margin-top: 15px;"src="img/icon/ajaxno.png"></img><br/>
			<img src="img/icon/regpass1.png"></img><input class="input" name="pass1" id="pass1" type="password" placeholder="Contraseña" ></input><br/>
			<img src="img/icon/regpass2.png"></img><input class="input" name="pass2" id="pass2" type="password" placeholder="Repetir Contraseña" =""></input><br/>
			<div id="notification"><p></p></div>
			<input class="boton azulado" id="submit" type="submit" value="Registrar Ahora"></input>
		</form>
		<script src="inc/register.js" type="text/javascript"></script>
	</body>
	
</html>