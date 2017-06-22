<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>Форма</title>
</head>

<body>

	<?php
		
		echo "Имя: ".($_POST['firstname']."\n"); 
		echo "<br />"."Отчество: ".htmlspecialchars($_POST['patronymic']);
		echo "<br />"."Фамилия: ".htmlspecialchars($_POST['surname']);
		echo "<br />"."Дата рождения: ".htmlspecialchars($_POST['birthday']);
		
		if($_POST['mailing'])
			echo ("<br />"."подписан или нет: да");
		else
			echo ("<br />"."подписан или нет: нет");
		echo "<br />"."Пол: ".($_POST['gender']);
		echo "<br />"."Любимый фильм: ".($_POST['movie']);
		echo "<br />"."Любимая музыка: ";			
		foreach ($_POST['music'] as $t)
		{
			echo "<br />".$t;
		}
		echo "<br />"."Обратная связь: ".htmlspecialchars($_POST['text']);

	?> 
</body>
</html>