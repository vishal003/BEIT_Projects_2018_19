<?php include('../db.php');
$product_id=$_GET['product_id'];
$sql="UPDATE addproduct SET status='approved' WHERE product_id=$product_id";
$setapprove=mysqli_query($con,$sql);
header("Location:display.php");
//include('../close.php');
?>
