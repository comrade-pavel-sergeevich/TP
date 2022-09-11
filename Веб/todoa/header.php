<?php if(!session_status() === PHP_SESSION_ACTIVE ? TRUE : FALSE) session_start(); ?>
<header><div class="menu">
<ul class="top-menu">
                <li class="menu-item" onclick="document.location.href = 'index.php';">Home</li>
				<?php  
				if(!isset($_SESSION['user_email'])){
				echo '<li class="menu-item" onclick="document.location.href = \'index.php?reg_form=register\';">Register</li>
                <li class="menu-item" onclick="document.location.href = \'index.php?reg_form=login\'">Log in</li>';
				}else echo '<li class="menu-item" onclick="document.location.href = \'includes/logout.php\';">LogOut</li>
				<li class="menu-item">Привет, '.$_SESSION['user_name'].'</li>'
				
				?>
                            </ul></div>
                            </header>
                            <div style="height:40px; color:transparent">Кто прочитал, тому хорошего дня</div>