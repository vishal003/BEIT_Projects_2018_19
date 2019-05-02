
<?php
    require_once "config.php";

	if (!isset($_SESSION)) {
		header('Location: index.php');
		exit();
	}

	$loginURL = $gClient->createAuthUrl();
?>
<?php
require_once 'fbconfig.php';
/*if(isset($_SESSION['userData'])){
	header('location: view.php');
}*/
$floginURL = $helper->getLoginUrl($redirectURL, $fbPermissions);
?>

<?php
include "db.php";
?>
<?php include "header.php"; ?>
	<br><br>
    <div class="container-fluid">
 	<div class="signup-form">
    	<!--<form action="customer_farmer_login.php  " method="post">
		<div class="form-group">
        	<input type="email" class="form-control input-lg" name="email" placeholder="Email Address" required="required">
        </div>
		<div class="form-group">
            <input type="password" class="form-control input-lg" name="password" placeholder="Password" required="required">
        </div> 
        <div class="form-group">
            <button type="submit" name="login" class="btn btn-success btn-lg btn-block signup-btn">Log In</button>
        </div>
		
		<div class="text-center"><a href="forgetPassword.php">Forgot Password..?</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">Need an Account..?</a></div>
    </form>-->

    <ul class="nav nav-tabs">
		    <li class="active"><a data-toggle="tab" href="#clogin">Customer Login</a></li>
		    <li><a data-toggle="tab" href="#flogin">Farmer Login</a></li>
		  </ul>

	  		<div class="tab-content">
	    		<div id="clogin" class="tab-pane fade in active">
	    			<br><br>
	    		<form action="/examples/actions/confirmation.php" method="post">
					<h2>LogIn To Account </h2>
					<p class="hint-text">SignIn with your social media account or email address</p>
					<div class="social-btn text-center">
						<a href="<?= htmlspecialchars( $floginURL ); ?>" class="btn btn-primary btn-lg"><i class="fa fa-facebook"></i> Facebook</a>
						<a class="btn btn-danger btn-lg" onclick="window.location ='<?php echo $loginURL ?>';"><i class="fa fa-google"></i> Google</a>
					</div>
				</form>
				<div class="or-seperator"><b>or</b></div>
			
				<form action="customer_login.php  " method="post">
					<div class="form-group">
			        	<input type="email" class="form-control input-lg" name="email" placeholder="Email Address" required="required">
			        </div>
					<div class="form-group">
			            <input type="password" class="form-control input-lg" name="password" placeholder="Password" required="required">
			        </div> 
			        <div class="form-group">
			            <button type="submit" name="login" class="btn btn-success btn-lg btn-block signup-btn">Log In</button>
			        </div>
					
					<div class="text-center"><a href="forgetPassword.php">Forgot Password..?</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="register.php">Need an Account..?</a></div>
    			</form>	    					
	    		</div>
	    		<div id="flogin" class="tab-pane fade">
	      			<br><br>
				<form action="farmer_login.php  " method="post">
					<div class="form-group">
			        	<input type="email" class="form-control input-lg" name="email" placeholder="Email Address" required="required">
			        </div>
					<div class="form-group">
			            <input type="password" class="form-control input-lg" name="password" placeholder="Password" required="required">
			        </div> 
			        <div class="form-group">
			            <button type="submit" name="login" class="btn btn-success btn-lg btn-block signup-btn">Log In</button>
			        </div>
					
					<div class="text-center"><a href="forgetPassword.php">Forgot Password..?</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="register.php">Need an Account..?</a></div>
    			</form>	 
	    		</div>
	  		</div>
    </div>
</div>
		
	<div class="signup-form">
		
		  
	</div>
<br><br>
<?php include('footer.php');?>



    <!-- jQuery -->   <script src="js/jquery-1.11.3.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="js/jquery.easing.min.js"></script>
    
    <!-- Custom Javascript -->
    <script src="js/custom.js"></script>

</body>

</html>
<?php include "close.php"; ?>
