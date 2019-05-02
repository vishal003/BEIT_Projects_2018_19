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
											<th>User ID</th>
											<th>Product Name</th>
											<th>Product Image</th>
											<th>Quantity</th>
											<th>Total Price</th>

										</tr>
																
										<?php
											include ('db.php');
											
											if(isset($_SESSION["farmer_id"]))
											{
											
											$SqlQueryRun=mysqli_query($con,"select * from orders WHERE farmer_id=$_SESSION[farmer_id]");
											while($rows=mysqli_fetch_array($SqlQueryRun))
											{
										?>
										<tr>
											<td><?php echo $rows['user_id'] ?></td>
											<td><?php echo $rows['product_title'] ?></td>
											<td><?php echo "<img src='farmer_images/".$rows['product_image']."' height=auto width='100px'"?></td>										
											<td><?php echo $rows['qty'] ?></td>	
											
											<td><?php echo $rows['total_amount'];?></td>
											
										</tr>
										<?php
										}
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
	