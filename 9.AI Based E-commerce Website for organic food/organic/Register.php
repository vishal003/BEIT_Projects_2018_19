	<?php include "header.php"; ?>
	<style>
	label{
		color: red;
	}
	</style>
    <script src="js/form-validation.js"></script>


		<div class="col-md-6" style="margin-top:30px">
		<div class="signup-form">
	<form action="customer_registration.php" name="buyer" method="post">
		<h2>Create an Account As A Buyer</h2>
	<div class="form-group">
						<input type="text" class="form-control input-lg" name="name" placeholder="Enter Name" >
				</div>
	<div class="form-group">
						<input type="email" class="form-control input-lg" name="email" placeholder="Enter Email Address" >
					</div>
	<div class="form-group">
						<input type="text" class="form-control input-lg" name="mobile" placeholder="Enter Contact number" >
					</div>
	<div class="form-group row">
						<div class="form-group">
							<div class="col-sm-5"><label class="radio-inline">Male &nbsp;</label><input type="radio" name="gender" value="Male"></div>
							<div class="col-sm-5"><label class="radio-inline">Female &nbsp;</label><input type="radio" name="gender" value="Female"></div>
						</div>
					</div>
	<div class="form-group">
							<input type="password" class="form-control input-lg" name="pwd" id="pwd" placeholder="Enter Password" >
						</div>
	<div class="form-group">
							<input type="password" class="form-control input-lg" name="cpwd" placeholder="Confirm Password" >
						</div> 
	<div class="form-group">
							<label class="radio-inline">I Agree with the<a href="#"> Terms and Conditions</a></label>&nbsp;&nbsp;<input type="checkbox" name="agree" value="agree"> 
								
	</div>
	<div class="form-group">
					<button type="submit" name="signup" class="btn btn-success btn-lg btn-block signup-btn">Sign Up</button></div>
					<div class="text-center">Already have an account? <a href="login.php">Login here</a></div>
					
	</form>

			</div>
		</div>
		
		
		
		
		<div class="col-md-6" style="margin-top:30px">
		<div class="signup-form">
			<form action="farmer_registration.php" name="seller" method="post">
				<h2>Create an Account As A Seller/Farmer</h2>
					<div class="form-group">
						<input type="text" class="form-control input-lg" name="name" placeholder="Enter Name" >
				</div>
					<div class="form-group"> 
					
						<input type="email" id="email" class="form-control input-lg" name="email" placeholder="Enter Email Address" required="required">
					</div>
				<div class="form-group">
						<input type="text" class="form-control input-lg" name="mobile" placeholder="Enter Contact number" >
					</div>

						<div class="form-group row">
						<div class="form-group">
							<div class="col-sm-5"><label class="radio-inline">Male &nbsp;</label><input type="radio" name="gender" value="Male"></div>
							<div class="col-sm-5"><label class="radio-inline">Female &nbsp;</label><input type="radio" name="gender" value="Female"></div>
						</div>
					</div>
						<div class="form-group">
							<input type="password" class="form-control input-lg" name="pwd" id="fpwd" placeholder="Enter Password" required="required">
						</div>
						<div class="form-group">
							<input type="password" class="form-control input-lg" name="cpwd" placeholder="Confirm Password" required="required">
						</div>
				
						
						<label class="radio-inline">
						<b>Select Organic Certification details</b>
						</label>
						<div class="form-group">
							
								<label class="radio-inline">
									Self Declared Farmer &nbsp;
								</label><input type="radio" name="certificate" value="Self Declared Farmer" ><label></label>
							<br>
							
								<label class="radio-inline">
									PGS India Organic &nbsp;
								</label><input type="radio" name="certificate" value="PGS India Organic"><label></label>
							<br>
							
								<label class="radio-inline">
									Other Organic Certificate &nbsp;
								</label>
								<input type="radio" name="certificate" value="Other Organic Certificate"><label></label>
							
						</div>
						<div class="form-group">
							<label class="radio-inline">I Agree with the<a href="#"> Terms and Conditions</a></label>&nbsp;&nbsp;<input type="checkbox" name="agree" value="agree"> 		
						</div>

						<div class="form-group">
						<button type="submit" name="signup" class="btn btn-success btn-lg btn-block signup-btn">Sign Up</button>
						</div>
					<div class="text-center">Already have an account? <a href="login.php">Login here</a></div>

			</form>
						

	</body>
	</html>
	<?php include "close.php"; ?>
