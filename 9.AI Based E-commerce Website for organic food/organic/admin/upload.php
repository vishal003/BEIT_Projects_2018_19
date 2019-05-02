<?php
include('connect.php');
if(isset($_POST['upload']))
{
	$name=$_POST['file_name'];
	$captn=$_POST['caption'];
	$type=$_POST['category'];
	//$size=$_POST['size'];
	
	if(empty($name))
	{
		echo'<script type=text/javascript>
		alert("Please Select file.....")
		window.location="add_photos.php"
		</script>';
	}
	else
	{
		$sqlrun="INSERT INTO photos(file_name,caption,type)VALUES('$name','$captn','$type')";
	$sendsql=mysqli_query($conn,$sqlrun);
	if($sendsql=TRUE)
	{
	echo'<script type=text/javascript>
	alert("photo uploded sucessfully....")
	window.location="add_photos.php"
	</script>';
	}
	else{
		echo'<script type=text/javascript>
	alert("something went wrong....")
	window.location="add_photos.php"
	</script>';
	}}
}
include('close.php');
?>