<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
require 'connection_demo.php';
getId();
}

function getId(){

global $connect;

$query="SELECT * FROM registration_status WHERE r_flag='1' ORDER BY id DESC;";

$result=mysqli_query($connect,$query);
$no_of_row=mysqli_num_rows($result);

if($no_of_row>0){
	$row=mysqli_fetch_assoc($result);
	$str="".$row['r_id'].'';
    echo "<script>  document.getElementById('get_id').value=\"$str\" </script>;";
    $query2="UPDATE registration_status SET r_flag='0' WHERE r_flag='1';";
    mysqli_query($connect,$query2);
}
else{
	$str="";
	 echo "<script>  document.getElementById('get_id').value=\"$str\" </script>;";
}
mysqli_close($connect);
}
?>