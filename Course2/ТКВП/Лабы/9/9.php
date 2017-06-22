<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>9 labs</title>
</head>

<body>

<?php
	$labs = array(
		'geom'		=> array('1','2','3','4','5','6','7'),
		'fib'	 => array('1','1','2', '3', '5', '8', '13', '21', '34'),
	);

foreach($labs as $key => $value) 
  { 
     echo "$key = "; 
	 foreach($value as $key => $value)
	 	echo  $value;
	 echo "<br />";
  } 
	
	print_array($labs);
	
	
	function print_array($ar) {
		 static $count; 
		 $count = (isset($count)) ? $count++ : 0; 
		 if (!is_array($ar)) {
			 echo "Passed argument is not an array!<p>";
			 return; 
		 } 	
		 
		 while(list($k, $v) = each($ar)) {
			 if (is_array($v))
				echo " $k ";
			else 
				echo " $v ";
			 	if (is_array($v)) {
					print_array($v);
					echo "<br />";
				 }
		 }
		 $count--;
	 } 	

?>

</body>
</html>