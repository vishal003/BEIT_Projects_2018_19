<?php include('header.php');?>	
	<div class="container">
		<div class="col-md-12">
			<div class="content_box">
				<table class="table table-bordered">
									<tr>
										<!--<th>id</th>-->
										<th>Date</th>
										<th>Product Image</th>
										<th>Product Name</th>
										<th colspan="3">Status</th>
									</tr>
															
									<?php
										include ('../db.php');
										
										$SqlQueryRun=mysqli_query($con,"SELECT * FROM addproduct ORDER BY product_id DESC");

										while($rows=mysqli_fetch_array($SqlQueryRun))
										{
									?>
									<tr>
										<!--<td><?php// echo $rows['product_id']; ?></td>	-->
										<td><?php echo $rows['date']; ?></td>
										<td><?php echo "<img src='../farmer_images/".$rows['product_image']."'height=auto width=100px'";?></td>
										<td><?php echo $rows['product_title']; ?>	
										<?php
												echo'<label style="color:#FF5722">' .$rows['status'].'<label>' ;
												?>
										</td>	
										<!--<td><?php //echo '<a href="view_blog.php?id='.$rows['product_id'].'" title="View" class="btn btn-primary" style="color:white;">'.'View'.'</a>';?></td>-->
										<td><?php echo '<a href="approve.php?product_id='.$rows['product_id'].'" title="Approve" class="btn btn-success">'.'Approve'.'</a>';?></td>
										<td><?php echo '<a href="disapprove.php?product_id='.$rows['product_id'].'" title="Disapprove" class="btn btn-Warning">'.'Disapprove'.'</a>';?></td>
										<td><?php echo '<a href="delete.php?product_id='.$rows['product_id'].'" title="Disapprove" class="btn btn-Danger">'.'Delete'.'</a>';?></td>
									</tr>
									<?php
									}
									//include ('../close.php');
									?>
												
								</table>
								</div></div></div>
		
