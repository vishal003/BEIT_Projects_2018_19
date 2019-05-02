<?php 
include("db.php");
if(isset($_POST["subscribe"]))
{
	$subemail=$_POST['email'];
	$subsql="INSERT INTO subscription(email)VALUES('$subemail')";
}
	echo '<script type="text/javascript">
		alert("Subscribe Successfully....");
		window.location="index.php";
		</script>';	
	mysqli_query($con,$subsql);
		
	?>