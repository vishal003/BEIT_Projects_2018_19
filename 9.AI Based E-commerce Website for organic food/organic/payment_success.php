<?php

include "header.php";
//include "session.php";
$trx_id="";
	if(isset($_GET["st"]))
	{
		$trx_id=$_GET["tx"];
		$p_status=$_GET["st"];
		$amount=$_GET["amt"];
		$cc=$_GET["cc"];
	
	//$custom_user_id=$_GET["cm"];
	

		if($p_status == "completed")
		include "db.php";
		{
			if(isset($_SESSION["user_id"]))
			include "db.php";
			{		
				$user_id=$_SESSION["user_id"];
		
				$run="SELECT farmer_id,product_id,product_title,qty,units,product_image,total_amount FROM cart WHERE user_id='$user_id'";
		
				//$run="SELECT * FROM cart WHERE user_id=$_SESSION[user_id]";
				
				$run_query= mysqli_query($con,$run);
				$row = mysqli_num_rows($run_query);
				
				//$run_query = mysqli_query($con,$run);
				//$row= mysqli_fetch_array($run_query);
			
				if($row > 0)
				{
					while($row=mysqli_fetch_array($run_query))
					{
						$product_id=$row["product_id"];
						$farmer_id=$row["farmer_id"];
						$product_title=$row["product_title"];
						$qty=$row["qty"];
						$units=$row["units"];
						$product_image=$row["product_image"];
						$total_amount=$row["total_amount"];
				
						$sql="INSERT INTO orders (user_id,farmer_id,product_id,product_title,product_image,qty,units,total_amount,trx_id,p_status,date) VALUES
						('$user_id','$farmer_id','$product_id','$product_title','$product_image','$qty','$units','$total_amount','$trx_id','$p_status','".date("Y-m-d H:i:s")."')";
				
						mysqli_query($con,$sql);
					}
						/*for($i=0; $i<count($product_id); $i++)
						{
						$sql="INSERT INTO orders (user_id,product_id,qty,trx_id,p_status) VALUES
						('$trx_id_user_id','".$product_id[$i]."','".$qty[$i]."','$trx_id','$p_status')";
				
						mysqli_query($con,$sql);
				
						}*/

						$sql="DELETE FROM cart WHERE user_id='$user_id'";
			
						if(mysqli_query($con,$sql))
						{
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
					<h1>Thank You</h1>
						<p>Hello&nbsp;<b><?php echo $_SESSION["first_name"]; ?></b>,Your Payment Process Is Successfully Completed And Your Transaction Id is <b><?php echo $trx_id; ?></b>.<br/><br/>
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

			<?php
			/*}
		}
		else{
			header("location:index.php");
		}*/
	
	
		
	}
	}
	}
	}
	}
	
	
	
	
	
	?>
<?php include "close.php"; ?>



	
	




