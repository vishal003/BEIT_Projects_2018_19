<?php 
//include "header.php";
include "connect.php";

?>
<br>

<head>

	<script src="css1/js/bootstrap.js"></script>

	<script src="css1/js/jquery-3.2.1.min.js"></script>
	
	<script src="css1/js/bootstrap.min.js"></script>
	
	<script src="main.js"></script>
	
	<link rel="stylesheet" href="css1/css/bootstrap.min.css">
	

	
	<link rel="stylesheet" href="css1/css/style.css">
	
	<link rel="stylesheet" href="css1/css/font-awesome.css">

</head>

<center style="padding:10px";>
<a href="dashboard.php"><button id="" style="width:150px"; class="btn btn-success">Back To Home</button></a>
</center>


<br>

<div class="container">
	<div class="row">
		<div class="col-md-10 mx-auto">
			<div class="card" style="box-shadow:0 0 15px 0 lightgrey;">
				<div class="card-header"><center><h3><b>New Order</b></h3></center></div>
					<div class="card-body">
						<!--<div class="card-title"></div>
						<p class=""></p>
						<a href="#" class="btn btn-primary"></a>-->
						<form action="bill.php" method="get">
							<div class="form-group row">
								<label class="col-sm-3" align="right">Order Date</label>
								<div class="col-sm-6">
									<input type="text" id="date" name="date" readonly class="form-control form-control-sm" value="<?php echo date("y-d-m");?>" >
								</div>
							</div>
							
							<div class="form-group row">
								<label class="col-sm-3 " align="right">Customer Name</label>
								<div class="col-sm-6">
									<input type="text" name="cust_name" class="form-control form-control-sm" placeholder="Enter Customer Name" required>
								</div>
							</div>
							
							<div class="card" style="box-shadow:0 0 15px 0 lightgrey;">
								<div class="card-body">
									<h3>Make a Order List</h3>
									<table align="center" style="width:800px;" action="action.php">
										<thead>
											<tr>
												<th>#</th>
												<th style="text-align:center;">Item Name</th>
												
												<th style="text-align:center;">Quantity</th>
												<th style="text-align:center;">Units</th>
												<th style="text-align:center;">Price</th>
												<!--<th>Total Price</th>-->
											</tr>
										</thead>
										<tbody id ="invoice_item">
											<tr>
												<td><b id="number">1</b></td>
												<td>
													<select name="product_title" class="form-control form-sm">
													
													<?php 

														$products=mysqli_query($conn,"SELECT * FROM addproduct")or die(mysqli_error($conn));
														while($row=mysqli_fetch_array($products))
														{

													?>

													
													<option value="<?php echo $row["product_title"]; ?>"><?php echo $row["product_title"]; ?></option>


													<?php
														}
													?>
												</td>
												<td>
												<input  name="qty" type="text" class="form-control form-sm">
												</td>
												<td>
												<input  name="units" type="text" class="form-control form-sm">
												</td>
												<td>
												<input  name="price" type="text" class="form-control form-control-sm">
												
												</td>


												
												
											</tr>
										</tbody>
									</table>
									<center style="padding:10px";>
										<button id="add" style="width:150px"; class="btn btn-success">Add</button>
										<button id="remove" style="width:150px"; class="btn btn-success">Remove</button>
										
									</center>
								</div>
							</div>
							<br>

							
							<div class="form-group row">
								<label for="total"  class="col-sm-3" align="right">Total Price</label>
								<div class="col-sm-6">
									<input type="text" name="total" class="form-control form-control-sm" id="total" required>
								</div>
							</div>
							
							<div class="form-group row">
								<label for="paid" class="col-sm-3"  align="right">Paid</label>
								<div class="col-sm-6">
									<input type="text" name="paid" class="form-control form-control-sm" id="paid" required>
								</div>
							</div>
							
							<div class="form-group row">
								<label for="Due"  class="col-sm-3" align="right">Due</label>
								<div class="col-sm-6">
									<input type="text" name="due" class="form-control form-control-sm" id="due" required>
								</div>
							</div>
							
							<div class="form-group row">
								<label for="payment" class="col-sm-3"  align="right">Payment Method</label>
								<div class="col-sm-6">
									<select name="payment" class="form-control form-control-sm" id="payment" required>
										<option>Card</option>
										<option>Cash</option>
										<option>Draft</option>
										<option>Cheque</option>
									</select>
								</div>
							</div>
							
							<center>
								<input type="submit"  name="order_form" style="width:150px;" class="btn btn-info" value="Order">
								<input type="submit"  name="print_invoice" style="width:150px;" class="btn btn-success d-none" value="Order">
							</center>
							
							
							
							
							
							
							</form>
					</div>
			</div>
		</div>
	</div>
</div>