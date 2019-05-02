<html>
<head>
	<script src="js/bootstrap.js"></script>

	<script src="js/jquery-3.2.1.min.js"></script>
	
	<script src="js/bootstrap.min.js"></script>
	
	<script src="main.js"></script>
	
	<!--<link rel="stylesheet" href="css/bootstrap.min.css">-->
	
	<link rel="stylesheet" href="css/bootstrap.css">
	
	<link rel="stylesheet" href="css/style.css">
	
	<link rel="stylesheet" href="css/font-awesome.css">
	
	<script src="main.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="assets/js/bootstrap.js"></script>
	<title>Dashboard</title>
</head>
<body>

	<nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav navbar-right">
	  
        <li><a href="dashboard.php" style="color:#fff;">Dashboard</a></li>
		<li><a href="complete_order.php" style="color:#fff;">Orders</a></li>
		 <li><a href="Subscription_email.php" style="color:#fff;">Subscribed Emails</a></li>
        <!--<li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#">Page 1-1</a></li>
            <li><a href="#">Page 1-2</a></li>
            <li><a href="#">Page 1-3</a></li>
          </ul>
        </li>-->
        <li><a href="display.php" style="color:#fff">Products</a></li>
		 <!--<li><a href="add_photos.php">Farmers</a></li>-->
							<li class="dropdown">
						<a href="" class="dropdown-toggle" style="color:#fff" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >Users</i></a>
						<ul class="dropdown-menu" aria-labelledby="about-us">
							
							<li><a href="user_info.php">Customers</a></li>
							<li><a href="farmer_info.php">Farmers</a></li>
						</ul>
					</li>
		<li><a href="logout.php" style="color:#fff"><span><i class="fa fa-sign-out"></i>Logout</span></a></li>
      </ul>
    </div>
  </div>
</nav>