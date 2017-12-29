<?php
	if(isset($_GET['sess'])){
		$token = $_GET['sess'];
	}else{
		die("Error_01");
	}
	if(strlen($token) < 5){
		die("Error_02");
	}
	if(isset($_GET['userid'])){
		$userid = $_GET['userid'];
	}
	if(!(is_numeric($userid))){
		die("Error_03");
	}
echo'	
<!DOCTYPE html>
<html>

	<head>
	<title>cvnconnectado</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="stylesheet" href="css/live.css"></link>
	<link rel="stylesheet" href="css/tooltip.css"></link>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script src="inc/tooltip.js" type="text/javascript"></script>
	<script type="text/javascript">
			$(function(){
			$(".titulo").tipTip();
			});
	</script>
	
	 <script type="text/javascript">
			$(function() {
				getStatus();
			});
		function getStatus() {
			$.getJSON(\'inc/main_live_do.php?userid='.$userid.'&sess='.$token.'\', function(data) {
			document.title = data.title;
			$(\'span#connum\').html(data.conectados);
			$(\'span#regnum\').html(data.registrados);
			});
			
			setTimeout("getStatus()",10000);
		}
		</script>
		
	</head>
	
	<body>
		<header>
			<ul>
				<li>Conectados: <span id="connum">1</span></li>
				<li>Registrados: <span id="regnum">1</span></li>
			</ul>
		</header>
	
	</body>
	
</html>
	';
?>