<?php
	
	/** Includes **/
	include('connect.inc.php');
	/** Includes **/	
	
	/** Variables **/
	$clientIP = $_SERVER['REMOTE_ADDR'];
	$link = "http://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
	$token = token(32);
	$log_fecha = date("Y-m-d H:i:s");
	/** Variables **/
	if(isset($_GET['act'])){
	//si es slidertexto
		if($_GET['act'] == 'cvntxt'){
			include('inc/main_text.php');
		}
		//cvn main launcher
		if($_GET['act'] == 'cvnmain'){
			include('inc/coeven.php');
		
		}
			//cvn main launcher
		if($_GET['act'] == 'cvnmainxelion'){
		
			include('inc/xelion.php');
		}
		
		if($_GET['act'] == 'cvnregister'){
			include('inc/register.php');
		}
		
		
		if($_GET['act'] == 'cvnforgot'){
			include('inc/forgotpass.php');
		}
		
		if($_GET['act'] == 'cvnlive'){
			include('inc/main_live.php');
		}
		
		if($_GET['act'] == 'cvnchangepass'){
			include('inc/main_changepass.php');
		}
		
	}else{
	echo '<html>
		<head>
		<title>Coeven Launcher ShoutBox</title>
		</head>
		<body>
		Error #cvn01
		</body>
		</html>';
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