<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>Первые 50 членов арифм. прогрессии</title>
</head>

<body>

	<?php
		echo "Џервые 50 членов арифметической прогрессии:"."<br/>";
		$an = $_POST['a0'];
		$summa = 0;
		for($i = 0; $i < 50; $i++)
		{
			echo ' '.$an;
			$an = ($an - 1) + 15;
			$summa += $an;
		}
	echo "<br/>"."Сумма = ".$summa;
	?> 
</body>
</html>