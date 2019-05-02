<?php include('header.php');?>

<section id="content">
	<?php include "side_menu_2.php"; ?>
	<div class="container">	
	
	<div class="row ">
				<div class="col-md-6 box-contain content_box ">
								<div class="content_box">
					<table class="table table-bordered">
										<tr style="background-color:#59B210;color:#fff;">
											<!--<th>id</th>-->
											<th>Product Name</th>
											<th>Quantity</th>
											<th>Price</th>
											<th>Amount</th>
											<th>Product Image</th>
										</tr>
																
										<?php
											include ('db.php');
											
											$SqlQueryRun=mysqli_query($con,"select * from cart ORDER BY id DESC");

											while($rows=mysqli_fetch_array($SqlQueryRun))
											{
										?>
										<tr>
											<td><?php echo $rows['product_title'] ?></td>
											<td><?php echo $rows['qty'] ?></td>	
											<td><?php echo $rows['price'] ?></td>	
											<td><?php echo $rows['total_amount'];?></td>
											<td><?php echo "<img src='farmer_images/".$rows['product_image']."' height=auto width='100px'";?></td>										
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
	