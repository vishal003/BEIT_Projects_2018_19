<?php include "session.php";?>

<!Doctype type html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <title>OrganiCrate:Home</title>

    <!-- Bootstrap Core CSS -->
	    <!-- jQuery --> 
    <script src="js/bootstrap.js"></script>

	<script src="js/jquery-1.11.1.min.js"></script>
	<script src="js/jquery-1.11.3.min.js"></script>

	<script src="js/bootstrap.min.js"></script>
	
    <!-- Plugin JavaScript -->
    <script src="js/jquery.easing.min.js"></script>
    <!-- Custom Javascript -->
	<script src="main.js"></script>
	
    <script src="js/form-validation.js"></script>
    <!-- Custom Javascript -->
    <script src="js/custom.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet">
	<!--<script src="js/header-scroll.js"></script>
	<script src="js/change_color.js"></script>-->
	<script language="javascript" type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"> </script>
    <script language="javascript" type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.15.0/jquery.validate.min.js"> </script>
    <script src="js/form-validation.js"></script>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <!-- Custom CSS: You can use this stylesheet to override any Bootstrap styles and/or apply your own styles -->
    <link href="css/custom.css" rel="stylesheet">
	<link href="css/footer.css" rel="stylesheet">
	<link href="css/form.css" rel="stylesheet">

   

    <!-- Custom Fonts from Google -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
    
</head>

<body>

    <!-- Navigation -->
    <nav id="siteNav" class="nev" style="width:100%;" role="navigation">
        <div class="container">
            <!-- Logo and responsive toggle -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.php">
                	<span class="glyphicon glyphicon-grain"></span> 
                	OrganiCrate
                </a>
         <!-- </div>-->
			
			<div id="google_translate_element" style="margin-top:13px"></div>
						<script type="text/javascript">
							function googleTranslateElementInit() {
							  new google.translate.TranslateElement({pageLanguage: 'en', layout: google.translate.TranslateElement.InlineLayout.SIMPLE}, 'google_translate_element');
								}
						</script>
						<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
            		</div>
			
            <!-- Navbar links -->
            <div class="collapse navbar-collapse" id="navbar">
                <ul class="nav navbar-nav navbar-right">
				<?php if (isset($_SESSION['access_token']) || isset($_SESSION['fb_token']) || isset($_SESSION['user_id']) ): ?>
                    <li><a href="#" id="cart_container" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-shopping-cart"></span>Cart<span class="badge"></span></a>
						<div class="dropdown-menu" style="width:400px;">
							<div class="panel panel-success">
								<div class="panel-heading">
									<div class="row">
										<div class="col-md-3">Sr.No</div>
										<div class="col-md-3">Product Image</div>
										<div class="col-md-3">Product Name</div>
										<div class="col-md-3">Price </div>
									</div>
								</div>
								<div class="panel-body">		
									<div id="cart_product">
									</div>
								</div>
							</div>
						</div>	
					</li>
					<?php endif ?>
					<li>
                        <a href="index.php">Home</a>
                    </li>
				<!--After Login-->
                    
					<?php
						//
						if (isset($_SESSION['access_token'])): 
						/*{
							header('Location: login.php');
							exit();
						}*/
					?>

					<li class="dropdown">
						<a href="" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" >Hello <?php echo $_SESSION['givenName'];  ?> &nbsp; <i class="fa fa-power-off"></i></a>
						<ul class="dropdown-menu" aria-labelledby="about-us">
							<li><a href="personal_info.php">My Profile</a></li>
							<li><a href="cart.php">My Cart</a></li>
							<li><a href="logout.php">LogOut</a></li>
						</ul>
					</li>
					<?php elseif (isset($_SESSION['fb_token'])): ?>
					<li class="dropdown">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" >Hello <?= $_SESSION['givenName']; ?> &nbsp; <i class="fa fa-power-off"></i></a>
						<ul class="dropdown-menu" aria-labelledby="about-us">
							<li><a href="personal_info.php">My Profile</a></li>
							<li><a href="cart.php">My Cart</a></li>
							<li><a href="logout.php">LogOut</a></li>
						</ul>
					</li>
				<?php elseif (isset($_SESSION['user_id'])): ?>
                        <li class="dropdown">
						<a href="" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" >Hello <?= $_SESSION['first_name'] ?>&nbsp; <i class="fa fa-power-off"></i></a>
						<ul class="dropdown-menu" aria-labelledby="about-us">
							<li><a href="personal_info.php">My Profile</a></li>
							<li><a href="cart.php">My Cart</a></li>
                            <li><a href="logout.php">LogOut</a></li>
						</ul>
					</li>
				<?php elseif (isset($_SESSION['farmer_id'])): ?>
                        <li class="dropdown">
						<a href="" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" >Hello <?= $_SESSION['f_name'] ?>&nbsp; <i class="fa fa-power-off"></i></a>
						<ul class="dropdown-menu" aria-labelledby="about-us">
							<li><a href="farmer_profile.php">My profile</a></li>
							<!--<li><a href="my_products_farmer.php">My Products</a></li>-->
							<li><a href="add_products.php">Add Products</a></li>

                            <li><a href="logout.php">LogOut</a></li>
						</ul>
					</li>
					
					<!--Before Login-->
					 <?php else: ?>   
					<li>
                        <a href="login.php">Sign in <div class="glyphicon glyphicon-log-in"></div></a>
                    </li>
                    <li>
                        <a href="register.php">Sign up <div class="glyphicon glyphicon-user"></div> </a>
                    </li>
					   <?php endif ?>
					<li>
                      <!--  <a href="">About</a>-->
                    </li>
                </ul>
                	
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container -->
    </nav>
	<?php include "close.php"; ?>
