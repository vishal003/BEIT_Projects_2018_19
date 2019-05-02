<?php
include "connect.php";


$date='';
$qty='';
$units='';
$price='';
$date='';
$cust_name='';
$payment='';

	if(isset($_GET["order_form"]))
	{ 
		
		$date=$_GET["date"]; 
		$cust_name=$_GET["cust_name"]; 
		$pro_name=$_GET["product_title"]; 
		$qty=$_GET["qty"];
		$units=$_GET["units"];
		$price=$_GET["price"];
		$total=$_GET["total"];
		$paid=$_GET["paid"];
		$due=$_GET["due"];
		$payment=$_GET["payment"];
		
	}
		
	
	$sql="INSERT INTO invoices(date,cust_name,product_title,qty,units,price,total,paid,due,payment)VALUES('$date','$cust_name','$pro_name','$qty','$units','$price','$total','$paid','$due','$payment')";
	
		$sql	=	mysqli_query($conn, $sql);
	
	if($sql == TRUE)
	{
		echo
		'<script type="text/javascript">
		alert("Your Product Is Uploaded....")
		window.location="bill.php";		
		</script>';
	}
	else{
		'<script type="text/javascript">
		alert("Something Went Wrong....")
		</script>';
		
	}

?>



