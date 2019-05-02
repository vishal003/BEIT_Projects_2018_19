<?php
session_start();
include "db.php";

?>
<?php
//include "db.php";

    $name='';

	$email='';

	$password='';
	
		if(isset($_POST["login"]))
		{
		if(isset($_POST["user_id"]))
		{
		$user_id = $_SESSION["user_id"];
		}
		
		$email=$_POST["email"];
		$password=$_POST["password"];
		
		
		
		$sql="SELECT * FROM users WHERE email='$email' && password='$password'";
		

	$run_query=mysqli_query($con,$sql);
	$count=mysqli_num_rows($run_query);

	
	if($count>0)
	{
		$row=mysqli_fetch_array($run_query);
		
		$_SESSION['user_id']=$row['user_id'];
		$_SESSION['name']=$row['name'];
		
		header('location: index.php');
	}
	else
	{
		echo "something wrong";
	}
	}
	 	

	?>
	
<?php


    $name='';

	$email='';

	$password='';
	
		if(isset($_POST["login"]))
		{
		if(isset($_POST["farmer_id"]))
		{
		$farmer_id = $_SESSION["farmer_id"];
		}
		
		$email=$_POST["email"];
		$password=$_POST["password"];
		
		
		
		$sql="SELECT * FROM farmers WHERE email='$email' && password='$password'";
		

	$run_query=mysqli_query($con,$sql);
	$count=mysqli_num_rows($run_query);

	
	if($count>0)
	{
		$row=mysqli_fetch_array($run_query);
		
		$_SESSION['farmer_id']=$row['farmer_id'];
		$_SESSION['f_name']=$row['f_name'];
		
		header('location: my_orders_farmer.php');
	}
	else
	{
		echo "something wrong";
	}
	}
	 <?php include "close.php"; ?>	
	?>
	