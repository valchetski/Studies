<!doctype html>
<html>
<head>
<meta charset="windows-1251">
<title>данные</title>
</head>

<body>

	<?php
		$name = htmlspecialchars($_POST['name']);
		$fam = htmlspecialchars($_POST['фамилия']);
		$spec = htmlspecialchars($_POST['spec']);
		$ball = htmlspecialchars($_POST['ball']);
		
		$spec = htmlspecialchars($_POST['spec']);
		$place = htmlspecialchars($_POST['place']);
		$dis1 = htmlspecialchars($_POST['dis1']);
		$dis2 = htmlspecialchars($_POST['dis2']);
		$dis3 = htmlspecialchars($_POST['dis3']);
		$disID1 = 0;
		$disID2 = 0;
		$disID3 = 0;
		$specID = 0;
		$i = 0;
		
		$link = mysqli_connect('localhost', 'zheka', '', '13');
		

		mysqli_query($link, 'INSERT INTO disc(dis1, dis2, dis3) values("'.$dis1.'", "'.$dis2.'", "'.$dis3.'"');
		$res1 = mysqli_query($link, 'SELECT * FROM disc where dis1 = "'.$dis1.'"');
		while($row1 = mysqli_fetch_array($res1)) 
				$disID = $row1[0];
				
		$res2 = mysqli_query($link, 'SELECT * FROM disc where dis2 = "'.$dis2.'"');
		while($row2 = mysqli_fetch_array($res2)) 
				$disID = $row2[0];
				
		$res3 = mysqli_query($link, 'SELECT * FROM disc where dis3 = "'.$dis3.'"');
		while($row3 = mysqli_fetch_array($res3)) 
				$disID = $row3[0];
		mysqli_query($link, 'INSERT INTO spec(Name, Place, dis1ID, dis2ID, dis3ID) values("'.$spec.'", "'.$place.'", "'.$disID1.'", "'.$disID2.'", "'.$disID3.'")');
		
	
		$res = mysqli_query($link, 'SELECT * FROM spec where Name = "'.$spec.'"');
		while($row = mysqli_fetch_array($res)) 
				$specID = $row[0];
		$result = mysqli_query($link, 'INSERT INTO student(Name, Surname, SpecID, Bal) values("'.$name.'", "'.$fam.'", "'.$specID.'", "'.$ball.'")');
		$rr = mysqli_query($link, 'SELECT * FROM spec');
		while( $rowa = mysqli_fetch_row($rr)) {
			printf('Speciality %s: </br>',$rowa[1]);
	
		$rs = mysqli_query($link, 'SELECT * FROM student  ORDER BY Bal');
		while( $rows = mysqli_fetch_row($rs)) {
			$i++;
			if($i <= $place)
				printf('Name %s  Fam %s - OK </br>',$rows[1], $rows[2]);
			else
				printf('Name %s  Fam %s - NO </br>',$rows[1], $rows[2]);
		  }
	}

	mysqli_close($link);
		  exit;

	?> 
</body>
</html>