<?php
session_start();
include "db.php";

?>
<?php

/*
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
	}*/
	 


include "dbconnection.php";
if(isset($_POST["login"]))
{
	$query = "
	SELECT * FROM farmers 
		WHERE email = :email ";
	$statement = $db->prepare($query);
	$statement->execute(
		array(
				'email'	=>	$_POST["email"]
			)
	);
	$count = $statement->rowCount();
	if($count > 0)
	{
		$result = $statement->fetchAll();
		foreach($result as $row)
		{
			if($row['user_email_status'] == 'verified')
			{
				//if(password_verify($_POST["password"], $row["password"]))
				if($row["password"] == $_POST["password"])
				{
					$_SESSION['farmer_id'] = $row['farmer_id'];
					$_SESSION['f_name'] = $row['f_name'];
					header("location:index.php");
				}
				else
				{
					echo '<script type="text/javascript">
					alert("Wrong Password....!!!");
					window.location="login.php";
					</script>';	
				}
			}
			else
			{
				echo '<script type="text/javascript">
					alert("Please First Verify, your email address");
					window.location="login.php";
					</script>';	
						}
		}
	}
	else
	{
			echo '<script type="text/javascript">
					alert("Wrong Email Address...!");
					window.location="login.php";
					</script>';		}
}


	?>	
	<?php include "close.php"; ?>