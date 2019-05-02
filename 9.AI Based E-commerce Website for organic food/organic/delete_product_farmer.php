<?php include('db.php');
$product_id=$_GET['product_id'];
$sql="DELETE FROM addproduct WHERE product_id=$product_id";
$setapprove=mysqli_query($con,$sql);
header("Location:my_products.php");
//include('../close.php');
<?php include "close.php"; ?>
?>