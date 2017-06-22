<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>12 lab</title>
</head>

<body>
<?php

$dir = "E:\\125\\";
$fold = "";
$fold = $_GET['fold'];
$del = "";
$del = $_GET['del'];
$del1 = 0;

if ($del1 == $_GET['del1'])
{
	unlink($del);
	$del == 0;
}

if ((strpos($fold,$dir)!=0)||(strpos($fold,"..")!=False)||($fold==""))
  $dir=$dir;
else
  $dir=$fold;

// Открыть заведомо существующий каталог и начать считывать его содержимое
	if (is_dir($dir)) 
	{
		
		if ($dh = opendir($dir)) {
			echo ("<table  border=1>");
			$back = substr($dir, 0, strrpos($dir, "\\"));
			echo ("<tr><td><a href=index.php?fold=$back>вверх</a></td></tr>");
			while (($file = readdir($dh)) !== false) {
				$full = $dir.'\\'.$file;
				if (is_dir($full) == true) 
				{
					$dirr = $dir.'\\'.$file;
					echo ("<tr><td>$file</td><td><a href=index.php?fold=$dirr>open</a></td><td></td></tr>");
				}
				else
				{
					$dirrs = $dir.'\\'.$file; 
					echo ("<tr><td>$file</td><td ><a href=index.php?del=$dirrs>delete</a></td><td><a href=".($dir.$file).">open</a></td></tr>");

				}
			}
			echo ("</table>");
			closedir($dh);
		}
	}




	
?>

</body>
</html>