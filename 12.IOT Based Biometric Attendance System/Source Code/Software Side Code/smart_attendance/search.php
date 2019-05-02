<!DOCTYPE html>

<?php 
include'connection_demo.php';

session_start();
if (strlen($_SESSION['user'])==0  && $_SESSION['user']!="admin") {
    header('Location:index.php');
}

?>

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

</head>
<body class="text-secondary" style="background-color: #EEEEEE;"  style="margin: auto;">

	<?php include('header.php') ?>
	<?php include('nav_bar.php'); ?>
	<br/>

    <div class="my-center-container" >
    	<div style="width: 50%;background-color: #fff;">

    		<div style="background-color: #9da4cf;padding: 30px 10px">
    		
            	<h3 style=" text-transform: uppercase;text-align: center;margin: 0;padding: 0; color: #2b3187">View Student Details</h3>

            </div>
            

            <div style="padding: 1%">
            	<br/>

				<div class="row">

					<div class="col-md-12">

						


						<form class="form-light mt-20" role="form"  method="post" action="check.php">

							<div class="form-group">

								<label style="color:#2b3187">Enter Student ID</label>

								<input type="text" class="form-control" placeholder="Student ID" name="sid" autocomplete="off" required>

							</div>
							

							<center><button type="submit" class="btn btn-two" style="background-color: #9da4cf;">Submit</button></center><p><br/></p>

							

						</form>

					

					</div>

				</div>

			</div>
		</div>
			
				
	</div>

</body>
</html>