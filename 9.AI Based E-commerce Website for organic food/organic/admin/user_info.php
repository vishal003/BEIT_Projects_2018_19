<?php include('header.php');?>	
	<div class="container">
		<div class="col-md-12">
			<div class="content_box">
				<table class="table table-bordered">
									<tr>

										<th>Account Date</th>
										<th>User Id</th>
										<th>Email</th>
										<th>Name</th>
										<th>Gender</th>
										<th>Street Address</th>
										<th>City</th>
										<th>State</th>
										<th>Pincode</th>
										<th>staus</th>
									</tr>
															
									<?php
										include ('../db.php');
										$SqlQueryRun=mysqli_query($con,"SELECT * FROM users");

										while($rows=mysqli_fetch_array($SqlQueryRun))
										{
									
									?>
									<tr>
										<td><?php echo $rows['created']; ?></td>
										<td><?php echo $rows['user_id']; ?></td>
										<td><?php echo $rows['email'];?></td>
										<td><?php echo $rows['name'];?></td>
										<td><?php echo $rows['gender']; ?></td>
										
										<td><?php echo $rows['address']; ?></td>
										<td><?php echo $rows['city']; ?></td>
										<td><?php echo $rows['state']; ?></td>
										<td><?php echo $rows['pincode']; ?></td>
										<td><?php echo $rows['user_email_status']; ?></td>
										
									</tr>
									<?php
									}
									//include ('../close.php');
									?>
												
								</table>
								</div></div></div>
		
