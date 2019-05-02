<?php
$conn = mysqli_connect("localhost","root","123456","organic");
if(!$conn){
	die("connection failed".mysqli_connect_error());
}
mysqli_set_charset($conn,'utf8');
?>