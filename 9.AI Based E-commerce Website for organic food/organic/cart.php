<?php
include "header.php";

if(!isset($_SESSION["user_id"]))
{
	header("location:index.php");
}
?>

<p><br/></p>
<p><br/></p>
<p><br/></p>
<head>
<style>


</style>
</head>
<div class="container-fluid">
	<div class="row">
		<div class="col-md-2"></div>
			<div class="col-md-8" id="cart_message">
				<!--Cart Message--> 
			</div>
		<div class="col-md-2"></div>
	</div>
	<div class="row">
		<div class="col-md-1"></div>
			<div class="col-md-10">
				<div class="panel panel-primary">
					<div class="panel-heading">Cart Checkout</div>
						<div class="panel-body">
							<div class="row">
								<div class="col-md-2"><b> Action</b></div>
								<div class="col-md-2"><b>Product Name</b></div>
								<div class="col-md-2"><b>Product Image</b></div>
								<div class="col-md-1"><b>Quantity</b></div>
								<div class="col-md-1"><b>Units</b></div>
								<div class="col-md-2"><b>Price</b></div>
								<div class="col-md-2"><b>Total Amount</b></div>
							</div>
						</div>
						
								<div id="checkout"></div>
						
						<!--<div class="row">
							<div class="col-md-2">
								<div class="btn btn-group">
									<button class="btn btn-danger"><span class="glyphicon glyphicon-trash"></span>
									<button class="btn btn-primary"><span class="glyphicon glyphicon-ok-sign"></span>
								</div>
							</div>
								<div class="col-md-2"><b>Product Name</b></div>
								<div class="col-md-2"><b>Product Image</b></div>
								<div class="col-md-2"><input type='text'  class='form-control' value='1kg'  ></div>
								<div class="col-md-2"><input type='text'  class='form-control' value='50' ></div>
							</div>-->
						<!--<div class="row">
							<div class="col-md-8"></div>
							<div class="col-md-2">
								<b>Total Rs.5000</b>
							</div>-->
				</div>
			</div>
</div>
			<div class="col-md-1"></div>
</div>
<br>
<?php include "footer.php"; ?>

<?php include "close.php"; ?>

			
