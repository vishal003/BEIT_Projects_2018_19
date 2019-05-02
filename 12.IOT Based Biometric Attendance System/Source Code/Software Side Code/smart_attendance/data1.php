<?php
if($_SERVER["REQUEST_METHOD"]=="GET"){
require 'connection_demo.php';
data("0",0);
}

function data($id,$f){
global $connect;

$user_id="2";
$r_id="";
date_default_timezone_set('Asia/Kolkata');
$i=0;
		
while ( $i <= 8) {
	// add attendance in database
	$current_time = "10:00:00";  // get time
	if($i + 1 >= 10){
		$current_date=($i+1)."-04-2019";  // get date
	}
	else{
		$current_date="0".($i+1)."-04-2019";  // get date
	}

	$dateAndTime=$current_date." ".$current_time;
	$current_day=date('l',strtotime($dateAndTime));  //  get day
	$current_week=0 + date("W", strtotime($dateAndTime));  // get week
	$today_lecture="AI";

	if ($current_day!="Sunday" && $current_day!="Saturday" && $current_day!="sunday" && $current_day!="saturday" ) {

			$query3="INSERT INTO attendance_info(user_id,date,lecture,a_flag,week) VALUES('$user_id','$dateAndTime','$today_lecture',2,'$current_week');";

			$result3=mysqli_query($connect,$query3);
			$no_of_row3=mysqli_affected_rows($connect);

			if($no_of_row3>0){
				echo "Successfully".$i."<br>";
			}

			if($no_of_row3==0){
				echo "Unsuccessfully".mysqli_error($connect);
			}
		}
		else {
			echo "".$current_day."<br>";
		}
	$i++;
}

mysqli_close($connect);
}
?>