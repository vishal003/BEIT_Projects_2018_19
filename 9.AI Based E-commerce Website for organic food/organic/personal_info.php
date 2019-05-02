<?php
include "session.php";
include "db.php"; 
?>

<?php
	if(isset($_SESSION['user_id'])){
		$user_id = $_SESSION['user_id'];
		
		$run=mysqli_query($con,"SELECT * FROM users where user_id= '$user_id'");
		while($row=mysqli_fetch_array($run)){
			/*$id=$row[0];
			$oauthpro=$row[1];
			$oauthuid=$row[2];*/
			$f_name=$row["first_name"];
			$l_name=$row["last_name"];
			//$name=$row[5];
			$email=$row["email"];
			$mobile=$row["mobile"];
			$gender=$row["gender"];
			$dob=$row["dob"];
			$locale=$row[10];
			$picture=$row[11];
			$link=$row[12];
			$address=$row["address"];
			$city=$row["city"];
			$state=$row["state"];
			$pincode=$row["pincode"];
		}
	}
	/*if(isset($_SESSION['access_token']) || isset($_SESSION['fb_token']) ){
		$user_id = $_SESSION['id'];
		
		$run=mysqli_query($con,"SELECT * FROM users where oauth_uid= '$user_id'");
		while($row=mysqli_fetch_array($run)){
			$id=$row[0];
			$oauthpro=$row[1];
			$oauthuid=$row[2];
			$name=$row[3];
			$l_name=$row[4];
			//$name=$row[5];
			$email=$row[6];
			$mobile=$row[7];
			$gender=$row[8];
			$dob=$row[9];
			$locale=$row[10];
			$picture=$row[11];
			$link=$row[12];
			$address=$row[13];
			$city=$row[14];
			$state=$row[15];
			$pincode=$row[16];	
		}
	}
	if(isset($_SESSION['f_name'])){
		$user_id = $_SESSION['farmer_id'];
		
		$run=mysqli_query($con,"SELECT * FROM farmers where user_id= '$user_id'");
		while($row=mysqli_fetch_array($run)){
			$id=$row[0];
			$name=$row[1];
			$email=$row[2];
			$mobile=$row[3];
			$gender=$row[4];
			
		}
	}*/
?>
<?php include('header.php');?>

<section id="content">
<?php include('side_menu.php');?>
<!--<div class="container">-->

	<div class="row ">
	
			<!--<div class="post-heading form-heading">
			<h4 class="text-center">New Blogger Signup</h4>
			</div>
 			<hr style="border:5px solid #FF5722;">-->	
		<!--<div class="col-md-4"></div>-->
		

		<div class="col-md-6 box-contain content_box "><form method="POST" action="profile_update_action.php">
		<h3 style="color:#59B210;">PERSONAL DETAILS</h3>

			<div class="form-group">
			  <label class="control-label" for="email_id">Name <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="firstname" name="firstname" class="form-control" placeholder="" type="text" required="" value="<?php echo $f_name?>">
				</div>
			</div>
			<!--<div class="form-group">
			  <label class="control-label" for="email_id">Last Name <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="lastname" name="lastname" class="form-control" placeholder="" type="text" required="">
				</div>
			</div>	-->


			<div class="form-group">
			  <label class="control-label" for="Gender">Gender <font color="red">*</font></label> 
			</div>
			<div class="form-group">
				 <select name="gender">
	            	<option value=<?php echo $gender;?>><?php echo $gender;?></option>
	            	<option value="Male">Male</option>
	            	<option value="Female">Female</option>
	        	</select>
	        </div>
			<div class="form-group">
			  <label class="control-label" for="mobile">Date of Birth <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="dob" name="dob" class="form-control" value="<?php echo $dob?>" placeholder="" type="date" required="">
				</div>
			</div>
			<div class="form-group">
			  <label class="control-label" for="state">E-Mail <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="email" name="email" class="form-control" placeholder="" type="text" required="" value="<?php echo $email?>"> 
				</div>
			</div>				

		<br>	
		<h3 style="color:#59B210;">ADDRESS</h3>

		
			<div class="form-group">
			  <label class="control-label" for="address">Address <font color="red"></font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <!--<textarea id="address" name="address" class="form-control" value="<?php echo $address ?>" placeholder="" > </textarea>-->
				  <input type="text" name="address" class="form-control" value="<?php echo $address ?>" placeholder="" >
				</div>
			</div>	

			<div class="form-group">
			  <label class="control-label" for="city">City <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="city" name="city" class="form-control" placeholder="" type="text" value="<?php echo $city ?>" required="">
				</div>
			</div>	

			<div class="form-group">
			  <label class="control-label" for="state">State <font color="red">*</font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="state" name="state" class="form-control" placeholder="" value="<?php echo $state ?>" type="text" required="">
				</div>
			</div>	

			<div class="form-group">
			  <label class="control-label" for="pincode">Pincode <font color="red"></font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="pincode" name="pincode" class="form-control" placeholder="" value="<?php echo $pincode ?>" type="text">
				</div>
			</div>	


			<div class="form-group">
			  <label class="control-label" for="mobile">Mobile <font color="red"></font></label>
				<div class="input-group">
				  <span class="input-group-addon"></span>
				  <input id="mobile" name="mobile" class="form-control" placeholder="" value="<?php echo $mobile?>" type="phone">
				</div>
			</div>	

			<br>
		<!--<h4>E-Mail Subscription</h4>
			<div class="form-group">
			  <label class="control-label" for="mobile">Emails you would like to recieve <font color="red">*</font></label>
				<div class="input-group">			  
				  <input id="newsletter-product" name="newsletter-product" type="checkbox" value="product, newsletters"> Product / Newsletters
				  <input id="newsletter-offers" name="newsletter-offers" type="checkbox" value="offers, promotions"> Offers & Promotions from leading companies
				</div>  
			</div>	
			
			<div class="form-group">
			  <label class="control-label" for="mobile">Terms & Conditions <font color="red">*</font></label>
				<div class="input-group">	
				<input id="accept-terms" name="accept-terms" type="checkbox" required=""> I have read and agree to Unitech Consultancy privacy statement and terms of use.
				</div>
			</div>-->
			
			
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
//include 'close.php' ;
?>
<?php include "close.php"; ?>
	