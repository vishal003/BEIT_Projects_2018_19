<?php
include "session.php";
include "db.php"; 
?>

<?php
	if(isset($_SESSION['farmer_id'])){
		$user_id = $_SESSION['farmer_id'];
		
		$run=mysqli_query($con,"SELECT * FROM farmers where farmer_id= '$user_id'");
		while($row=mysqli_fetch_array($run)){
			$f_name=$row["f_name"];
			$email=$row["email"];
			$mobile=$row["mobile"];
			$gender=$row["gender"];
			$certificate=$row["certificate"];
		}
	}
?>
<?php include('header.php');?>

<section id="content">
<?php include('side_menu_2.php');?>
<!--<div class="container">-->

	<div class="row ">

		<div class="col-md-6 box-contain content_box "><form method="POST" action="farmer_profile_action.php">
		<h3 style="color:#59B210;">PERSONAL DETAILS</h3>

			<div class="form-group">
			  <label class="control-label" for="email_id">Name <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="firstname" name="firstname" class="form-control" placeholder="" type="text" required="" value="<?php echo $f_name?>">
				</div>
			</div>

			<div class="form-group">
			  <label class="control-label" for="Gender">Gender <font color="red">*</font></label> :
				 <select name="gender">
	            	<option value=<?php echo $gender;?>><?php echo $gender;?></option>
	            	<option value="Male">Male</option>
	            	<option value="Female">Female</option>
	        	</select>
	        </div>
			<div class="form-group">
			  <label class="control-label" for="state">E-Mail <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="state" name="email" class="form-control" placeholder="" type="text" required=""value="<?php echo $email?>"> 
				</div>
			</div>				



			<div class="form-group">
			  <label class="control-label" for="mobile">Mobile <font color="red"></font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="mobile" name="mobile" class="form-control" placeholder="" value="<?php echo $mobile?>" type="phone">
				</div>
			</div>

			<div class="form-group">
			  <label class="control-label" for="mobile">Certificate <font color="red"></font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="cert" name="cert" class="form-control" placeholder="" value="<?php echo $certificate?>" type="phone">
				</div>
			</div>	

			<br>
			<!-- Button -->
			<div class="form-group">
			  <label class="control-label" for="submit"></label>
				<button id="submit" name="submit" class="btn btn1"> Update Details</button>
			</div>
			
	
						
		</form>	 
				<!--<script>
					function myFunction() {
					  var x = document.getElementByClass("");
					  if (x.style.display === "none") {
						x.style.display = "block";
					  } else {
						x.style.display = "none";
					  }
					}
					</script>
-->

	
		</div>

		<div class="col-lg-6">
			<p>&nbsp;</p>
		</div>		

		

			
	</div>	
			
</div>
</section>
<?php include('footer.php');
include 'close.php' ;
?>
	