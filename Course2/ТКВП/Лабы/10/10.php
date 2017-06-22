
<html>
<head>
<meta charset="windows-1251">
<title>10 lab</title>
</head>

<body>
<h2>детство</h2>
	<p>родился в минске<br />
	<strong>в 6 лет пошел в школу</strong></p>
	<hr/>
	<h2>школа</h2>

	<p>поступил в школу в 2001 году<br />
	проучился в ней 11 лет<br />
	<em>в 2012 закончил школу</em></p>
	<hr/>
	<h2>универ</h2>
	<p><strong>в 2012 поступил в БГУИР</strong><br/>
	...</p>
<?php

session_start(); 
		$day = $_SESSION['test11'];
		$month = $_SESSION['test22'];
		$year = $_SESSION['test33'];
		$week = $_SESSION['test44'];
		$born = $_SESSION['born'];
echo "дата: ".dates()."<br />";
echo "дата и время: ".datetime()."<br />";
echo "дата рождения: ".dateBorn()."<br />";
echo "дней до дня рождения: ".dateBorn2()."<br />";

//foreach(dateBorn3() as $key => $value )
//		echo "$key = $value <br />";
foreach(birthday($born) as $key => $value )
		echo "$key = $value <br />";

	function dates()
	{
		$date = date("j-m-Y");
		return $date;
		
	}
	
	function datetime()
	{
		$date = date("r");
		return $date;
	}
	
	function dateBorn()
	{
		$date = $GLOBALS["day"]."-".$GLOBALS["month"]."-".$GLOBALS["year"];
		return $date;	
	}
	
	function dateBorn2()
	{
		$dayto = 0;
		$date = $GLOBALS["day"]."-".$GLOBALS["month"]."-".date("Y");
		$date2 = date("j-m-Y");
		$dayto = 365 - abs(floor((strtotime($date)-strtotime($date2))/(3600*24)));
		return $dayto;	
	}
	
	
	function birthday($sec_birthday)
	{
		$sec_now = time();
		$happy2 = array();
		for($time = $sec_birthday, $month = 0; $time < $sec_now; $time += date('t', $time) * 86400, $month++)
			$rtime = $time;
		$month = $month - 1;
		$year = intval($month / 12);
		$month = $month % 12;
		$day = 365 - dateBorn2();
		$week = abs($GLOBALS["week"] - date("W"));
		$hours = (365 - dateBorn2()) * 24;
		$minute = (365 - dateBorn2()) * 24 * 60;
		$happy["day"] = $day;
		$happy["month"] = $month;
		$happy["year"] = $year;
		$happy["week"] = $week;
		$happy["hours"] = $hours;
		$happy["minute"] = $minute;
		return $happy;
	}
	
?>

</body>
</html>