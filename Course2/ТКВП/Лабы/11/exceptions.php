<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>данные</title>
</head>

<body>

	<?php
		
		$ok = 0;
		
		if(!empty($_POST['email']))
	        {
	           if(preg_match("|^[-0-9a-z_\.]+@[-0-9a-z_^\.]+\.[a-z]{2,6}$|i", $_POST['email']))
	           {         

				  echo $_POST['email']. "  -   Правильный email. <br />";
					$ok = 1;
	           }
	           else
	           {
	              echo $_POST['email']. "  -   НЕ правильный email. <br />";  
				  $ok = 0;
	           }
	        }
	        else
	        {
	           echo "Вы не ввели email. <br />"; 
				$ok = 0;
	        } 

			
		if (preg_match("/.[0-9]+./", $_POST['telefon']) && strlen($_POST['telefon']) == 10) 
		{
			
			echo "телефон  правильный <br />";
			$ok = 1;
		}
		else
			echo "телефон  неправильный <br />";
			$ok = 0;
			
			
		if (preg_match("/.[a-z]+./", $_POST['pass']))  
		{
			$ok = 1;
			echo "пароль правильный <br />";
		}
		else
		{
			$ok = 0;
			echo "пароль  неправильный <br />";
		}
			
		if (preg_match("/([\s])/", $_POST['pass']))
		{
			echo "Пароль должен быть без пробелов <br />";
			$ok = 0;
		}
		
			
		if(strlen($_POST['pass']) < 9)
		{
			$ok = 0;
			echo "Пароль должен быть не менее 9 символов <br />";
		}
		
		if($ok == 1)
		{
		echo "Все данные корректны";
		}

	?> 
</body>
</html>