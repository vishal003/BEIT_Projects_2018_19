<?php
	session_start();
	
	if(isset($_POST['submit'])){
		include('../db.php');
		
		$uname	=	$_POST['username'];
		$pwd	=	$_POST['password'];
		
		$query	=	"SELECT * FROM admin_users WHERE username='$uname'and password='$pwd'";
		$result	=	mysqli_query($con,$query) or die (mysqli_error($con));
		
		$count	=	mysqli_num_rows($result);
		if($count == 1){
			$_session['uname']	=	$uname;
			header("location:dashboard.php");
		}
		else
		{
		
		}
		
		if (isset($_SESSION['uname'])){
		$uname = $_SESSION['uname'];
		//echo "user  logedin";
		//header("location: dashboard.php");  
		echo'<script type="text/jalreadyavascript">window.location="dashboard.php";</script>';
	}
		include('../close.php');
	}
?>
<html>
<head>
	<link rel="stylesheet" href="css/bootstrap.css">
	<link rel="stylesheet" href="css/style.css">
	<title>Login</title>
</head>
<body>
	<div class="container">
		<div class="col-md-3">
		</div>
		<div class="col-md-6">
		<div class="login-form">
		<h1 style="color:#FF6600;font-size:80px;margin-left:5%;"><b>Organi<label style="color:yellowgreen;">C</label>rate<b></h1>
		<center>
		<!--<center><h3><b>LOGIN SECTION</b></h3></center>-->
			<form method="post" name="form1" action="">
				<div class="form-group">
					<div class="input-group">
						<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
						<input type="text" placeholder="Username" class="form-control" name="username" id="uname">
					</div>
				</div>
				<div class="form-group">
					<div class="input-group">
						<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
						<input type="password" placeholder="Password" class="form-control" name="password" id="pwd">
					</div>
				</div>
				<input type="submit" name="submit" class="btn1" value="Login"/>
			</form>
			</div>
			</div>
			<div class="col-md-3">
			</div>
	</div>
<body>
</html>