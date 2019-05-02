
<?php include('header.php');?>
<?php include ('../db.php');
	$total_emails=  mysqli_query($con,"SELECT * FROM Subscription");
	$num_rows=	mysqli_num_rows($total_emails);
	
	$total_farmers=  mysqli_query($con,"SELECT * FROM farmers");
	$farmers=	mysqli_num_rows($total_farmers);
	
	$approved_product=  mysqli_query($con,"SELECT * FROM addproduct WHERE status='approved'");
	$approved=	mysqli_num_rows($approved_product);
	
		$disapproved_product=  mysqli_query($con,"SELECT * FROM addproduct WHERE status='disapproved'");
	$disapproved=	mysqli_num_rows($disapproved_product);
	
		//$pendind_product=  mysqli_query($con,"SELECT * FROM addproduct WHERE status ='' ");
	//$pending=	mysqli_num_rows($approved_product);
	
		$total_users=  mysqli_query($con,"SELECT * FROM users ,fbusers,gusers");
	$users=	mysqli_num_rows($total_users);
	
	$complete_orders=  mysqli_query($con,"SELECT * FROM orders");
	$orders=	mysqli_num_rows($complete_orders);
?>

<div class="container">
	
	<div class="col-md-6" style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Total Products</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							 <h2><?php echo $approved;?></h2>
							</td>
							<td>
							 <h2><?php echo $disapproved;?></h2>
							</td>
							<!--<td>
							 <h2><?php //echo $pending;?></h2>
							</td>-->
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
							APPROVED
							</td>
							<td class="td1">
							DISAPPROVED
							</td>
							<!--<td class="td1">
							PENDING
							</td>-->
						</tr>
					</table>
			</div>
		
	</div>
	<div class="col-md-6"  style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Registerd Users</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							 <h2><?php echo $users;?></h2>
							</td>
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
							USERS
							</td>
						</tr>
					</table>
			</div>
	</div>
	<div class="col-md-6"  style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Registerd Farmers</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							 <h2><?php echo $farmers ;?></h2>
							</td>
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
							USERS
							</td>
						</tr>
					</table>
			</div>
	</div>
	<div class="col-md-6"  style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Total Questions</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							 <h2>10</h2>
							</td>
							<td>
								<h2>5</h2>
							</td>
							<td>
								<h2>0</h2>
							</td>
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
							<a href="#">APPROVED</a>
							</td>
							<td class="td2">
							<a href="#">DISAPPROVED</a>
							</td>
							
						</tr>
					</table>
			</div>
	</div>

			
		

			
	<div class="col-md-6" style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Complete Orders</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							  <h2><?php echo $orders ;?></h2>
							</td>
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
								ORDERS
							</td>
						</tr>
					</table>
			</div>
			
		
	</div>
	<div class="col-md-6" style="margin-top:3%;">
		<div class="dash-heading">
		<h3>Subscription Emails</h3></div>
		<div class="dash-box-total" >
				<!--<i class="fa fa-newspaper-o fa-3x fa-dash-icon" aria-hidden="true"></i>-->
					<!--<h2 style="margin-left:1%;">Total : </h2>-->
					<table class="table table-bordered text-center dash-table" width="100%;">
						<tr>
							<td>
							 <h2><?php echo "$num_rows";?></h2>
							</td>
						</tr>
						<tr class="dash-td-bg">
							<td class="td1">
								Emails
							</td>
						</tr>
					</table>
			</div>
			
		
	</div>
</div>

</body>
</html>