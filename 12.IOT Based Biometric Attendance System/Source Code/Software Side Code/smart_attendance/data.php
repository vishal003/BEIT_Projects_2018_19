<?php
if($_SERVER["REQUEST_METHOD"]=="GET"){
require 'connection_demo.php';
data("0",0);
}

function data($id,$f){
global $connect;

$user_id="";
$r_id="";

if ($f==1) {
	$user_id=$id;
}
else{
	$user_id=$_GET["ID"];
	$r_id=$_GET["RID"];
}

date_default_timezone_set('Asia/Kolkata');
$current_time = date("H:i:s");  // get time
$current_day=date('l');  //  get day
$current_date=date("d-m-Y");  // get date
$current_week=date('W');  // get week
$today_lecture="";

// checking time table and get lecture
$query6="SELECT * FROM Holidays WHERE h_time=curdate();";
$result6=mysqli_query($connect,$query6);
$no_of_row6=mysqli_num_rows($result6);
if($no_of_row6>0){
	$row6=mysqli_fetch_assoc($result6);
	$today_lecture="Holiday ".  ( strlen( $row6['h_name'] )==0 ? "" : "(". $row6['h_name'] .")" ) ."";
}
else if ($current_day!="Sunday" && $current_day!="Saturday" && $current_day!="sunday" && $current_day!="saturday" ) {

	$query1="SELECT $current_day FROM time_table WHERE start_from<='$current_time' AND to_end>'$current_time' ";

	$result1=mysqli_query($connect,$query1);
	$no_of_row1=mysqli_num_rows($result1);

	if($no_of_row1>0){
		$row1=mysqli_fetch_assoc($result1);
		$today_lecture=$row1[$current_day];
	}
	else{
		$today_lecture="No Lecture";
	}

}
else if( $current_day=="Sunday" ){ $today_lecture="Holiday (Sunday)"; }
else if( $current_day=="Saturday" ){ $today_lecture="Holiday (Saturday)"; }
//else{$today_lecture="Holiday";}

echo "$current_time\n";
echo "$current_day\n";
echo "$current_week\n";
echo "$current_date\n";
echo "$today_lecture\n";

if($today_lecture!="No Lecture"){
// checking for registration
$query2="SELECT * FROM users WHERE user_id='$user_id'";

	$result2=mysqli_query($connect,$query2);
	$no_of_row2=mysqli_num_rows($result2);

	if($no_of_row2>0){

		$dateAndTime=$current_date." ".$current_time;
		// check in attendance is done or not
		$query5="SELECT * FROM attendance_info WHERE user_id='$user_id' AND lecture='$today_lecture' AND  SUBSTR(date,1,13) = SUBSTR( '$dateAndTime' ,1,13) ";

		$result5=mysqli_query($connect,$query5);
		$no_of_row5=mysqli_num_rows($result5);

		if($no_of_row5>0){
			echo "Already Present";
			// add attendance in database
			$query3="INSERT INTO attendance_info(user_id,date,lecture,a_flag,week) VALUES('$user_id','$dateAndTime','$today_lecture',1,'$current_week');";

			$result3=mysqli_query($connect,$query3);
		}

		if($no_of_row5==0  && $today_lecture!='Recess' ){

			// add attendance in database
			$query3="INSERT INTO attendance_info(user_id,date,lecture,a_flag,week) VALUES('$user_id','$dateAndTime','$today_lecture',2,'$current_week');";

			$result3=mysqli_query($connect,$query3);
			$no_of_row3=mysqli_affected_rows($connect);

			if($no_of_row3>0){
				echo "Successfully";
			}

			if($no_of_row3==0){
				echo "Unsuccessfully".mysqli_error($connect);
			}

		}
		else if($today_lecture=='Recess'){
			// add attendance in database
			$query6="INSERT INTO attendance_info(user_id,date,lecture,a_flag,week) VALUES('$user_id','$dateAndTime','$today_lecture',1,'$current_week');";
			mysqli_query($connect,$query6);
		}

	}
	else{
		echo "User not Register";
	}
}

$query4="INSERT INTO data(user_id,r_id) VALUES('$user_id','$r_id');";


	$result4=mysqli_query($connect,$query4);
	$no_of_row4=mysqli_affected_rows($connect);

	if($no_of_row4>0){
		echo " Successfully";
	}

	if($no_of_row4==0){
		echo " Unsuccessfully".mysqli_error($connect);
	}


if($r_id !=0 ){
$query7="INSERT INTO registration_status(r_id,r_flag) VALUES('$r_id','1');";

	$result7=mysqli_query($connect,$query7);
	$no_of_row7=mysqli_affected_rows($connect);

	if($no_of_row7>0){
		echo " Register Successfully";
	}

	if($no_of_row7==0){
		echo " Unsuccessfully".mysqli_error($connect);
	}

}


mysqli_close($connect);

}
?>