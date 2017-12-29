<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>Coeven - Launcher Gateway</title>
  <link rel="stylesheet" href="css/superslides.css">
</head>
<body style="overflow:hidden;">
  <div id="slides">
    <div class="slides-container">
	
	<li>
        <img src="img/coeven/coeven01.jpg" alt="">
    </li>
	
	<li>
        <img src="img/coeven/coeven02.jpg" alt="">
    </li>
	
	<li>
        <img src="img/coeven/coeven03.jpg" alt="">
      </li>
  
    </div>

  <nav class="slides-navigation">
      <a href="#" class="next">
        <i class="icon-chevron-right"></i>
      </a>
      <a href="#" class="prev">
        <i class="icon-chevron-left"></i>
      </a>
    </nav>
	
  </div>

  <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
  <script src="js/jquery.easing.1.3.js"></script>
  <script src="js/jquery.animate-enhanced.min.js"></script>
  <script src="js/jquery.superslides.js" type="text/javascript" charset="utf-8"></script>
  <script>
    $('#slides').superslides({
      animation: 'fade',
	  play: 4000
    });
  </script>
</body>
</html>