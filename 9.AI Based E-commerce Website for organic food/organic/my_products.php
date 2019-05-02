<?php include('header.php');?>
<section id="content">
	<div class="container">	
	<?php include "side_menu_2.php"; ?>
	<div class="row ">
				<div class="col-md-7 box-contain content_box ">
								<div class="content_box">
					<table class="table table-bordered">
										<tr style="background-color:#59B210;color:#fff;">
											<!--<th>id</th>-->
											<th>Product Name</th>
											<th>Quantity</th>
											<th>Units</th>
											<th>Price</th>
											<th>Product Image</th>
											<th colspan="2">Action</th>
										</tr>
																
										<?php
											include ('db.php');
											
											$SqlQueryRun=mysqli_query($con,"select * from addproduct WHERE farmer_id=$_SESSION[farmer_id] ORDER BY date");

											while($rows=mysqli_fetch_array($SqlQueryRun))
											{
										?>
										<tr>
											<td><?php echo $rows['product_title'] ?></td>
											<td><?php echo $rows['quantity'] ?></td>	
											<td><?php echo $rows['units'] ?></td>	
											<td><?php echo $rows['product_price'];?></td>
											<td><?php echo "<img src='farmer_images/".$rows['product_image']."'height=auto width=100px'";?></td>
											<td><?php echo '<a href="delete_product_farmer.php?product_id='.$rows['product_id'].'" title="Delete" class="btn btn-Danger">'.'Delete'.'</a>';?></td>	
																						
										</tr>
										<?php
										}
										//include ('../close.php');
										?>
													
									</table>
									</div>  
				</div>
				<div class="col-lg-6">
					<p>&nbsp;</p>
				</div>					
		</div>					
	</div>
</section>
<?php include('footer.php');?>
<?php include "close.php"; ?>
	