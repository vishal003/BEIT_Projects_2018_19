<?php include('header.php');?>
<section id="content">
	<div class="row">
	<div class="container">	
	<div class="col-md-4"><?php include "side_menu_2.php"; ?></div>
				<div class="col-md-6 box-contain content_box "><h3 style="color:#59B210;text-align:center;">My Products</h3>
								<div class="content_box">
					<table class="table table-bordered">
										<tr style="background-color:#59B210;color:#fff;">
											<!--<th>id</th>-->
											<th>Product Name</th>
											<th>Quantity</th>
											<th>Price</th>
											<th>Units</th>
											<th>Product Image</th>
										</tr>
																
										<?php
											include ('db.php');
											
											if(isset($_SESSION["farmer_id"]))
											{
											
											$SqlQueryRun=mysqli_query($con,"select * from addproduct WHERE farmer_id=$_SESSION[farmer_id] ORDER BY date");

											while($rows=mysqli_fetch_array($SqlQueryRun))
											{
										?>
										<tr>
											<td><?php echo $rows['product_title'] ?></td>
											<td><?php echo $rows['quantity'] ?></td>
											<td><?php echo $rows['product_price'] ?></td>													
											<td><?php echo $rows['units'] ?></td>	
											<td><?php echo $rows['product_image'];?></td>										
										</tr>
										<?php
										}
											}
										//include ('../close.php');
										?>
													
									</table>
									</div>  
				</div>
				<!--<div class="col-lg-6">
					<p>&nbsp;</p>
				</div>-->					
		</div>					
	</div>
</section>
<?php include('footer.php');?>
	<?php include "close.php"; ?>