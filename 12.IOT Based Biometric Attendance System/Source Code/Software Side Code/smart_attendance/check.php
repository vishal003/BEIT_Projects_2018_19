<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
require 'connection_demo.php';
check();
}

function check(){

global $connect;

$student_id=$_POST["sid"];

$query="SELECT  user_id FROM users WHERE user_id='$student_id';";

$result=mysqli_query($connect,$query);
$no_of_row=mysqli_num_rows($result);

if($no_of_row>0){
	$row=mysqli_fetch_assoc($result);
        $user_id=$row['user_id'];

        if ($user_id==$student_id) {
                
                session_start(); 
                $_SESSION['sid']=$student_id;                
        	header('Location:student_detail.php');  
        }
        else{
                $str="Invalid Student ID,".'\nGo back and try again.';
                echo "<script>
                window.location.href='search.php';
                alert(\"$str\");
                </script>";
        }
}
else{
	$str="Invalid Student ID,".'\nGo back and try again.';
        echo "<script>
        window.location.href='search.php';
        alert(\"$str\");
        </script>";
        //echo 'Invalid Student ID, '."<a href='search.php'>Go back and try again.</a>";
}

mysqli_close($connect);
}
?>