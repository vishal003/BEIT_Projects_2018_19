<?php
if($_SERVER["REQUEST_METHOD"]=="POST"){
//require 'connectiondemos.php';
login();
}

function login(){

$username=$_POST["username"];
$password=$_POST["password"];

	if($username=='admin' && $password=='123456')
	{
		session_start();
		$_SESSION['user']="admin";
		echo "<script> window.location.href='registration.php'; </script>";
		//header('Location:registration.php');
	}
    else{
    	
        $str="Invalid Credentials, ".'\nGo back and try again.';
        echo "<script> window.location.href='index.php'; alert(\"$str\"); </script>";
    	//echo 'Invalid Credentials, '."<a href='index.php'>Go back and try again.</a>";
    }

}
?>