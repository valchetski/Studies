<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>Геометрическая прогрессия</title>
</head>

<body>
	<?php
		echo "Первые 50 членов геометрической прогрессии:"."<br/>";
		$bn = $_POST['b0'];
		$summa = 0;
		for($n = 1; $n <= 50; $n++)
		{
			echo ' '.(float)$bn;
			$summa += $bn;
			$bn = (float)pow((-1), $n) * 1.5 * $bn;			
		}
	echo '<br/>'."Сумма = ".$summa;
	?> 
</body>
</html>