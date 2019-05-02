

<?php

	include "db.php";
	include "header.php";
		include "session.php";
	
if(!isset($_SESSION["user_id"]))
{
	header("location:index.php");
}

?>
<p><br/></p>


<html>
<head>
	<style>
		table tr td{padding:10px;}
	</style>
</head>
<body>
<div class="container-fluid">
	<div class="row">
		<div class="col-md-2"></div>
		<div class="col-md-8">
			<div class="panel panel-default">
				<div class="panel-heading"></div>
				<div class="panel-body">
					<h1>Order Canceled</h1>
						<p>Hello&nbsp;<b><?php echo $_SESSION["first_name"]; ?></b>,Your Order has been Successfully Canceled.<br/><br/>
						You Can Continue Your Shopping.<br/></br>
						<a href="index.php" class="btn btn-success btn-large">Continue Shopping</a>
				</div>
								<div class="panel-footer"></div>
				</div>
			</div>
		</div>
	</div>
	
</div>
</body>
</html>
<?php include "close.php"; ?>

