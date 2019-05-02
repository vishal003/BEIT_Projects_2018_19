<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
require 'connection_demo.php';
graph_data();
}else {
	echo "plese use post request";
}

function graph_data(){

global $connect;
$p=$_POST["pr"];
$month=$_POST["month"];

$query = "SELECT  u.user_name,ROUND( ( (  COUNT( a.user_id ) / 176 ) * 100 ),2)as p FROM attendance_info a INNER JOIN users u ON a.user_id = u.user_id AND a.a_flag='2' AND SUBSTR(a.date,4,7) = '$month' GROUP BY a.user_id HAVING  p>'$p' ";

//$result = mysqli_query($connect,$query);

/*$data = array();
foreach ($result as $row) {
	$data[] = $row;
}*/

$result=mysqli_query($connect,$query);
$no_of_row=mysqli_num_rows($result);

$temp_array=array();

if($no_of_row>0){
	while($row=mysqli_fetch_assoc($result)){
		$temp_array[]=$row;	
	}
	header('Content-Type: application/json');
	echo json_encode($temp_array);
}
else{
	echo "Unsuccessfully";
}

echo "".mysqli_error($connect);

/*header('Content-Type: application/json');
echo json_encode($data);*/

mysqli_close($connect);
}
?>