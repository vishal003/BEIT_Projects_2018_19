<?php include('header.php');?>	
	<div class="container">
		<div class="col-md-12">
			<div class="content_box">
				<table class="table table-bordered">
									<tr>
										<th>Sr no.</th>
										<th>Date</th>
										<th>User Id</th>
										<th>Farmer Id</th>
										<th>Product Id</th>
										<th>Product Image</th>
										<th>Product Name</th>
										<th>Quantity</th>
										<th>Units</th>
										<th>Amount</th>
										<th>Transaction_id</th>
									</tr>
															
									<?php
										include ('../db.php');
										$SqlQueryRun=mysqli_query($con,"SELECT * FROM orders");

										while($rows=mysqli_fetch_array($SqlQueryRun))
										{
									
									?>
									<tr>
										<td><?php echo $rows['order_id']; ?></td>
										<td><?php echo $rows['date']; ?></td>
										<td><?php echo $rows['user_id'];?></td>
										<td><?php echo $rows['farmer_id'];?></td>
										<td><?php echo $rows['product_id']; ?></td>
										<td><?php echo "<img src='../farmer_images/".$rows['product_image']."'height=auto width=100px'";?></td>
										<td><?php echo $rows['product_title']; ?></td>
										<td><?php echo $rows['qty']; ?></td>
										<td><?php echo $rows['units']; ?></td>
										<td><?php echo $rows['total_amount']; ?></td>
										<td><?php echo $rows['trx_id']; ?></td>
										
									</tr>
									<?php
									}
									//include ('../close.php');
									?>
												
								</table>
								</div></div></div>
		
