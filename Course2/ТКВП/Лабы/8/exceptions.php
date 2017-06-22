<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>8 лаба</title>
</head>

<body>
<?php

if (isset($_POST['submitt'])) {
	$error = '';	
	if ((!preg_match("/^[a-zA-Z]+$/", $_POST['firstname'])) ) 
	$error.= "<p style=color:red>Ошибка в поле имя<br></p>";
	
	if ((!preg_match("/^[a-zA-Z]+$/", $_POST['patronymic']))) 
	$error.= "<p style=color:red>Ошибка в поле отчество<br></p>";
	
	if ((!preg_match("/^[a-zA-Z]+$/", $_POST['surname']))) 
	$error.= "<p style=color:red>Ошибка в поле фамилия<br></p>";	
	
	if ($error)
	echo "<b style=color:red>Исправьте ошибки: ".$error."</b>";
	else {
		echo $_POST['surname']." ".$_POST['firstname']." ".$_POST['patronymic'];
		
		if ($_POST['gender'] == "Male")
			echo " родился ";
		else 
			echo " родилась ";
		echo $_POST['birthday']."<br>";		
		
		echo "Любит фильм ".$_POST['movie']."<br>";
		
		if (!empty($_POST['music'])) 
		{
			echo "Любит музыку: ";
			foreach ($_POST['music'] as $song){
				echo "<br>".$song;
				}
		}
		else
			echo "Не любит музыку";
	}
}
?>

<?
if (!isset($_POST['send']) || $error):
?>

<form action="?" method="post">
			<h2><b>Личная информация</b></h2>
			<p><b>Имя:</b>
				<input type="text" name="firstname" size="40">
			</p>	
			<p><b>Отчество:</b>
				<input type="text" name="patronymic" size="40">
			</p>
			<p><b>Фамилия:</b>
				<input type="text" name="surname" size="40">
			</p>
			<p><b>Дата рождения:</b>
				<input type="text" name="birthday" size="40">
			</p>
			<p><b>Ваш пол:</b></p>
			<p>
				<input type="radio" name="gender" value="Male" checked="true">Мужской<Br>
				<input type="radio" name="gender" value="Female">Женский<Br>
			</p>
			<p><b>Подписаться на рассылку</b>
				<input type="checkbox" name="mailing" size="40" checked = "true">
			</p>			
			<hr/>
			
			<h2><b>Предпочтения</b></h2>
			<p><b>Любимый фильм:</b>
				<select name='movie'>
					<option>Back in the future</option>
					<option>Inglorious bustards</option>
					<option>Pirate of the Caribbean</option>
					<option>Predator</option>
				</select>
			</p>
			<p><b>Любимые жанры музыки:</b></p>
			<p>
				<select name='music[]' multiple='multiple' size='3'>
					<option>Trance</option>
					<option>Pop</option>
					<option>Rock</option>
				</select>
			</p>	
			<hr/>	
			
			<h2><b>Обратная связь</b></h2>
			<p><textarea rows="10" cols="45" name="text"></textarea></p>
			<hr/>
			
			<input type="submit" name="submitt" size="40">
		</form>		







<?
endif;
?>
</body>
</html>