<!DOCTYPE html>

<?php include'connection_demo.php';?>

<html>
<head>
<meta charset="ISO-8859-1">
<title><?php echo"$project_name"; ?></title>

	<link rel="stylesheet" href="assets/css/bootstrap.min.css">

	<link rel="stylesheet" href="assets/css/font-awesome.min.css">

	<!-- Custom styles for our template -->

	<link rel="stylesheet" href="assets/css/bootstrap-theme.css" media="screen">

	<link rel="stylesheet" href="assets/css/style.css">

	<link rel="stylesheet" href="css/style.css" type="text/css">

	<style type="text/css">
		
		html,body{
			height: 90%;
		}
	</style>

</head>
<body class="text-secondary my-body-background-color">

	<?php include('header.php'); ?>

    <div class="my-center-container" >
    	<div style="width: 50%;background-color: #fff;">

    		<div style="background-color: #9da4cf;padding: 30px 10px">
    		
            	<h3 style=" text-transform: uppercase;text-align: center;margin: 0;padding: 0; color: #2b3187">Login</h3>

            </div>
            

            <div style="padding: 1%">
            	<br/>

				<div class="row">

					<div class="col-md-12">

						<form class="form-light mt-20" role="form"  method="post" action="login.php">

							<div class="form-group">

								<label style="color:#2b3187">Username</label>

								<input type="text" class="form-control" placeholder="Username" name="username" required>

							</div>


							<div class="form-group">

								<label style="color:#2b3187">Password</label>

								<input type="Password" class="form-control" placeholder="Password" name="password" required>

							</div>
							

							<center><button type="submit" class="btn btn-two" style="background-color: #9da4cf">Login</button></center>
							<p><br/></p>

						</form>

					</div>

				</div>

			</div>
		</div>
			
				
	</div>

	

</body>
</html>