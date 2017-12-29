<?php
	$espacio = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			";
	echo '<html>
	<head>
	<title>Coeven Launcher - Registro Nuevo</title>
	<link href=\'http://fonts.googleapis.com/css?family=Ubuntu:300\' rel=\'stylesheet\' type=\'text/css\'>
	<link rel="Shortcut Icon" href="favicon.ico" type="image/x-icon" />
	<script src="http://code.jquery.com/jquery-2.1.3.min.js" type="text/javascript"></script>
	<script type=\'text/javascript\' src=\'//cdn.jsdelivr.net/jquery.marquee/1.3.1/jquery.marquee.min.js\'></script>
	</head>
	<style>
			*{
			background-color: #212123;
			margin: 1px;
			font-family: \'Ubuntu\', sans-serif;
			font-size: 13px;
			color:white;
			cursor:pointer;
			-webkit-user-select: none;  
-moz-user-select: none;  
-ms-user-select: none;     
-o-user-select: none;
user-select: none;  
			}
			.marquee {
  overflow: hidden;
  opacity:0.4;
    -webkit-transition: opacity 1s; /* For Safari 3.1 to 6.0 */
    transition: opacity 1s;
}
.marquee:hover{
	opacity:1;
}
	</style>
	</head>
			<body>
			<div class="marquee">
			';
			$i = 0;
			
			foreach($db->query('SELECT * FROM cvn_notice order by cvn_notice.Index DESC') as $row)
			{
				$i++;
				echo $row['cvn_name'];
				echo "&nbsp;";
				echo $row['cvn_notice'];
	
				echo $espacio;
		
			}
						
			echo'</div><script>
			$(\'.marquee\').marquee({
				//speed in milliseconds of the marquee
				duration: 4500,
				//gap in pixels between the tickers
				gap: 50,
				//time in milliseconds before the marquee will start animating
				delayBeforeStart: 5,
			});
			</script>
			</body>
			</html>
			';
			
?>