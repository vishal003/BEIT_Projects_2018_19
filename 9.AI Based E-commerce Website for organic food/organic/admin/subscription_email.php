<?php include('header.php');?>	
	<div class="container">
		<div class="col-md-12">
			<div class="content_box">
				<table class="table table-bordered">
									<tr>
										<th>id</th>
										<th>Date</th>
										<th colspan="2">Email</th>
									</tr>
															
									<?php
										include ('../db.php');
										
										$SqlQueryRun=mysqli_query($con,"select * from subscription ORDER BY id DESC");

										while($rows=mysqli_fetch_array($SqlQueryRun))
										{
									?>
									<tr>
										<td><?php echo $rows['id'] ?></td>
										<td><?php echo $rows['date'] ?></td>	
										<td><?php echo $rows['email'] ?></td>
									</tr>
									<?php
									}
									//include ('../close.php');
									?>
												
								</table>
								<center><a class="btn btn-primary" href="https://login.mailchimp.com/login/post/">SEND</a><center>
								</div></div></div>
		
