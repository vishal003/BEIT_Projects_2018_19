<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
require 'connection_demo.php';
check();
}

function check(){

global $connect;

$query="SELECT a.id,a.user_id,u.user_name,u.department,u.behavior FROM attendance_info a INNER JOIN users u ON a.user_id=u.user_id AND a.a_flag=1;";

$result=mysqli_query($connect,$query);
$no_of_row=mysqli_num_rows($result);

if($no_of_row>0){

        while($row=mysqli_fetch_assoc($result)){
                $id=$row['id'];

                $str="Student id = ".$row['user_id'].',\n Already Present.';
        		echo "<script> alert(\"$str\"); </script>";

                $query2="UPDATE attendance_info SET a_flag='0' WHERE id='$id';";
                mysqli_query($connect,$query2);
        }
        
}


mysqli_close($connect);
}
?>