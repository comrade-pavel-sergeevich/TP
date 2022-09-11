<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<meta http-equiv="Content-Type" content="text/html; charset=cp1251" />
<script type = "text/javascript" language="javascript" src="script.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<link rel="stylesheet" href="css/style.css">
<Title> TP </Title>
</head>

<body onload="checkHash();">
<?php session_start();?>
<header><div class="menu">
<ul class="top-menu" id='ulmenu'>
                <li class="menu-item" id='home' onclick="makeRequest('home.php');">Home</li>
				<li class="menu-item" id="reg" onclick="makeRequest('signup.php');">Register</li>
				<li class="menu-item" id="log" onclick="makeRequest('login.php');">Log in</li>
</ul>
</div>
</header>
                            <div style="height:40px; color:transparent">Кто прочитал, тому хорошего дня</div>
<main id='wrapper'> 

</main>




<svg version="1.1" xmlns="http://www.w3.org/2000/svg">
  <filter id="blur">
    <feGaussianBlur stdDeviation="6"></feGaussianBlur>
  </filter>
</svg>
</body>
</html>