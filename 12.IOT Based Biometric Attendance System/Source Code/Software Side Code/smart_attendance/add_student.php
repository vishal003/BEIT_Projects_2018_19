<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
require 'connection_demo.php';
add();
}

function add(){

global $connect;

$id=$_POST["s_id"];
$name=$_POST["s_name"];
$dept=$_POST["s_dept"];
$behav=$_POST["s_behav"];
$email=$_POST["s_email"];
$mobile=$_POST["s_mobile"];
$address=$_POST["s_address"];
$year=$_POST["s_year"];


$query="INSERT INTO users(user_id,user_name,department,behavior,email_id,mobile_no,address,year) VALUES('$id','$name','$dept','$behav','$email','$mobile','$address','$year');";

        $result=mysqli_query($connect,$query);
        $no_of_row=mysqli_affected_rows($connect);

        if($no_of_row>0){
                /*echo "Successfully";
                header('Location:admin_page.php');*/

                // query use for get user id
                // $query2="SELECT user_id FROM users ORDER BY user_id DESC LIMIT 1;";

                // $result2=mysqli_query($connect,$query2);
                // $row2=mysqli_fetch_assoc($result2);
                // $user_id=$row2['user_id'];
                // call function from file
                //require_once('data.php');
                //data("$user_id",1);
                // goto page
                $str='Student Register Successfully \n Student Id : '."$id";
                echo "<script>
                window.location.href='registration.php';
                alert(\"$str\");
                </script>";
        }
        else{
                //echo "Registeration Unsuccessfully ".mysqli_error($connect);
                //echo ', '."<a href='admin_page.php'>Go back and try again.</a>";

                $str="Registeration Unsuccessfully ".mysqli_error($connect).'\nGo back and try again.';
                echo "<script>
                window.location.href='registration.php';
                alert(\"$str\");
                </script>";
        }

mysqli_close($connect);
}?>

