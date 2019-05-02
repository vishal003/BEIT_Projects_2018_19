<?php include('header.php');?>	
	<div class="container">
		<div class="col-md-12">
			<div class="content_box">
				<table class="table table-bordered">
									<tr>

										
										<th>Farmer Id</th>
										<th>Email</th>
										<th>Name</th>
										<th>Mobile</th>
										<th>Gender</th>
										<th>Certificate</th>
										<th>staus</th>
									</tr>
															
									<?php
										include ('../db.php');
										$SqlQueryRun=mysqli_query($con,"SELECT * FROM farmers");

										while($rows=mysqli_fetch_array($SqlQueryRun))
										{
									
									?>
									<tr>
										<td><?php echo $rows['farmer_id']; ?></td>
										<td><?php echo $rows['email']; ?></td>
										<td><?php echo $rows['f_name'];?></td>
										<td><?php echo $rows['mobile'];?></td>
										<td><?php echo $rows['gender']; ?></td>
										
										<td><?php echo $rows['certificate']; ?></td>
										<td><?php echo $rows['user_email_status']; ?></td>
										
										
									</tr>
									<?php
									}
									//include ('../close.php');
									?>
												
								</table>
								</div></div></div>
		
