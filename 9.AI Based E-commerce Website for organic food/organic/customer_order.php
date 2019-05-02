<?php
	include "header.php";
	include "db.php";
	
if(!isset($_SESSION["user_id"]))
{
	header("location:index.php");
}
	
?>
<p><br/></p>


<html>
<head>
	<style>
		table tr td{padding:10px;}
	</style>
</head>
<body>
<div class="container-fluid">
	<div class="row">
		<div class="col-md-2"></div>
		<div class="col-md-8">
			<div class="panel panel-default">
				<div class="panel-heading"></div>
				<div class="panel-body">
					<h1>Customer Order Details</h1>
					<hr/>
						<?php


							$user_id = $_SESSION["user_id"];
							
							$orders_list ="SELECT * FROM orders WHERE user_id='$user_id'"; 
							$query = mysqli_query($con,$orders_list);
							if (mysqli_num_rows($query) > 0) {
								while ($row=mysqli_fetch_array($query)) {
						?>
						<div class="row">
							<div class="col-md-6">
								<img style="float:right;" src="farmer_images/<?php echo $row['product_image']; ?>" class="img-thumbnail"/>
							</div>
							<div class="col-md-6">
								<table>
									<tr><td>Product Name</td>&nbsp;<td><b><?php echo $row["product_title"]; ?></b></td></tr>
									<tr><td>Product Price</td>&nbsp;<td><b><?php echo $row["total_amount"]; ?></b></td></tr>
									<tr><td>Quantity</td>&nbsp;<td><b><?php echo $row["qty"]; ?></b></td></tr>
									<tr><td>Units</td>&nbsp;<td><b><?php echo $row["units"]; ?></b></td></tr>
									<tr><td>Payment</td>&nbsp;<td><b><?php echo $row["p_status"]; ?> </b></td></tr>
									<tr><td>Transaction Id</td>&nbsp;<td><b><?php echo $row["trx_id"] ?></b></td></tr>
								</table>
							</div>
						</div>
						<?php
								}
							}
						?>
								<div class="panel-footer"></div>
				</div>
			</div>
		</div>
	</div>
	
</div>
</body>
</html>
<?php include "close.php"; ?>


