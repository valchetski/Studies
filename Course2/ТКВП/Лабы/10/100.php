<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>Born</title>
</head>

<body >
<?php
if ( session_id() ) {
        // Если есть активная сессия, удаляем куки сессии,
        setcookie(session_name(), session_id(), time()-60*60*24);
        // и уничтожаем сессию
        session_unset();
        session_destroy();
    }
session_start(); 
	$_SESSION['test11'] = 15; // 1 переменная
	$_SESSION['test22'] = 3; // 2 переменная
	$_SESSION['test33'] = 1995;
	$_SESSION['test44'] = 11;
	$_SESSION['born'] = mktime(20, 15, 0, 3, 15, 1995);
session_write_close();

header("location: 10/10.php");

?>
</body>
</html>