<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>Решение квадратного уравнения</title>
</head>

<body>

	<?php
		$a = $_POST['a'];
		$b = $_POST['b'];
		$c = $_POST['c'];
		$x1 = 0;
		$x2 = 0;
		
		$dis = pow($b, 2) - 4 * $a * $c;
		if ($dis > 0)
		{
			$x1 = (int)((-$b) + sqrt($dis))/(2 * $a);
			$x2 = (int)((-$b) - sqrt($dis))/(2 * $a);
			echo '<br/>'."x1 = ".$x1;	
			echo '<br/>'."x2 = ".$x2;						
		}
		elseif($dis == 0)
		{
			$x1 = (int)((-$b) + sqrt($dis))/(2 * $a);
			echo '<br/>'."x1 = ".$x1;			
		}
		else
		{
			echo "Дискриминант меньше нуля!";
		}	
	?> 
</body>
</html>