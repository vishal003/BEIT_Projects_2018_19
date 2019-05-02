<?php
//session_start();
include "session.php";
$ip_add = getenv("REMOTE_ADDR");

include "db.php";


if(isset($_POST["category"])){
	$category_query = "SELECT * FROM categories";
	$run_query = mysqli_query($con,$category_query) or die(mysqli_error($con));
	echo "
		<div class='nav nav-pills nav-stacked'>
			<li class='active'><a href='#'><h4>Categories</h4></a></li>
	";
	if(mysqli_num_rows($run_query) > 0){
		while($row = mysqli_fetch_array($run_query)){
			$cid = $row["cat_id"];
			$cat_name = $row["cat_title"];
			echo "
					<li><a href='#' class='category' cid='$cid'>$cat_name</a></li>
			";
		}
		echo "</div>";
	}
}

if(isset($_POST["page"]))
{
	$sql="SELECT * FROM addproduct";
	$run_query = mysqli_query($con,$sql);
	$count=mysqli_num_rows($run_query);
	$pageno=ceil($count/9);
	
	for($i=1;$i<=$pageno;$i++)
	{
		echo "<li><a href='#' page='$i' id='page'>$i</a></li> ";
	}
}
	

$start='';
$limit='';
if(isset($_POST["getProduct"]))
{
	$limit = 6;
	if(isset($_POST["setpage"]))
	{

		$pageno = $_POST["pagenumber"];
		
		$start = ($pageno * $limit) - $limit;
		
	}else
	{
		$start = 0;
	}
	
	$product_query = "SELECT * FROM addproduct WHERE status='approved' LIMIT $start,$limit";
	$run_query = mysqli_query($con,$product_query);
	if(mysqli_num_rows($run_query) > 0)
	{
		while($row = mysqli_fetch_array($run_query))
		{
			$pro_id    = $row['product_id'];
			$pro_cat   = $row['product_cat'];

			$pro_title = $row['product_title'];
			$pro_price = $row['product_price'];
			$pro_image = $row['product_image'];
			echo "
				<div class='col-md-4'>
					
						<div class='cards'>
							<img class='cimg' src='farmer_images/$pro_image' style='width:100%; height:200px;'/>
							$pro_title<br>
							$pro_price Rupees<br>
							<button pid='$pro_id' id='product' class='act_btn 'style='width:103px;'>Add To Cart</button>
							<a href='view.php?product_id=$pro_id'><button pid='$pro_id' class='act_btn' >View</button></a>
						</div>
					
				</div>	
				
			";

		}
	}
}

	$ip_add='';
	$user_id='';
	$pro_name='';
	$pro_price='';
	$pro_image='';
	$row='';
	$product_id='';
	
	//if user login//
	
	if(isset($_POST["addProduct"]))
	{
		
		$pro_id = $_POST["proId"];
		
		
		if (isset($_SESSION))
		{
		if(isset($_SESSION["user_id"]))
		{
			$user_id = $_SESSION["user_id"];
			
			$sql = "SELECT * FROM cart WHERE product_id = '$pro_id' AND user_id='$user_id'"; 
		}
		else if(isset($_SESSION["id"]))
		{
			$user_id = $_SESSION["id"];
			
			$sql = "SELECT * FROM cart WHERE product_id = '$pro_id' AND user_id='$user_id'"; 
			
		}
		else
		{
			echo "
				<div class='alert alert-success'>
					<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
						<b>Please&nbsp;<a href='login.php'>LogIn</a>&nbsp;First..!</b>
					</div>
				";
			exit();
			
		}
			$run_query = mysqli_query($con,$sql);
			$count = mysqli_num_rows($run_query);
			
		if($count > 0)
		{
			echo "
				<div class='alert alert-warning'>
					<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
						<b>Product is already added into the cart Continue Shopping..!</b>
				</div>";
			exit();
		} 
		
		else 
		{
			$sql = "SELECT * FROM addproduct WHERE product_id = '$pro_id'";
			
				$run_query = mysqli_query($con,$sql);
				$row= mysqli_fetch_array($run_query);
				
				$pro_id=$row['product_id'];
				$farmer_id=$row['farmer_id'];


				$pro_name =$row["product_title"];
				$pro_image=$row["product_image"];
				$pro_price=$row["product_price"];
				$units=$row["units"];

				$sql = "INSERT INTO `cart`
				(`farmer_id`,`product_id`, `ip_add`, `user_id`, `qty`, `units`, `product_title`, `product_image`, `price`, `total_amount`)
				VALUES ('$farmer_id','$pro_id','-1','$user_id','1','$units','$pro_name','$pro_image','$pro_price','$pro_price')";

				if (mysqli_query($con,$sql)) 
				{
					echo "
						<div class='alert alert-success'>
							<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
							<b>Your product is Added Successfully..!</b>
						</div>
					";
				exit();
				}
		}
		
		}
		
		else
		{
			echo "
				<div class='alert alert-success'>
					<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
						<b>Please&nbsp;<a href='login.php'>LogIn</a>&nbsp;First..!</b>
					</div>
				";
			exit();
			/*if user not login
		
		
				$sql = "SELECT * FROM cart WHERE product_id = '$pro_id' AND user_id = -1";
		$run_query = mysqli_query($con,$sql);
		$count = mysqli_num_rows($run_query);
		if($count > 0)
		{
			echo "
				<div class='alert alert-warning'>
					<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
						<b>Product is already added into the cart Continue Shopping..!</b>
				</div>";
			exit();
		}
			$sql = "SELECT * FROM addproduct WHERE product_id = '$pro_id'";
			
				$run_query = mysqli_query($con,$sql);
				$row= mysqli_fetch_array($run_query);
				
				$pro_id=$row['product_id'];
				$farmer_id=$row['farmer_id'];
				
				$pro_name =$row["product_title"];
				$pro_image=$row["product_image"];
				$units=$row['units'];
				//$ip_add=$row['ip_add'];
				$pro_price=$row["product_price"];
				
				$sql = "INSERT INTO `cart`
				(`farmer_id`,`product_id`, `ip_add`, `user_id`, `qty`, `units`, `product_title`, `product_image`, `price`, `total_amount`)
				VALUES ('$farmer_id','$pro_id','$ip_add','-1','1','$units','$pro_name','$pro_image','$pro_price','$pro_price')";
				
				if (mysqli_query($con,$sql)) 
				{
					echo "
						<div class='alert alert-success'>
							<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
							<b>Your product is Added Successfully..!</b>
						</div>
					";
				exit();
				}*/
		
		}
		}
	
	
	
//move cart in dropdown menu	
$pro_images='';	
$count='';
$pro_id='';
if (isset($_POST["Common"])) 
{
	if (isset($_SESSION))
	{
	/*if(isset($_SESSION["id"]))
	{
		$sql="SELECT * FROM cart WHERE user_id=$_SESSION[id]" or die(mysqli_error($con));
	}
	else*/ if(isset($_SESSION["user_id"]))
	{
		$sql="SELECT * FROM cart WHERE user_id=$_SESSION[user_id]" or die(mysqli_error($con));
	}
	}
	else
	{
		$sql ="SELECT * FROM cart WHERE user_id=-1";
	
	}
		$run_query=mysqli_query($con,$sql);
		$count=mysqli_num_rows($run_query);
		
		if(isset($_POST["get_cart_product"]))
		{
			
			if($count>0)
			{
				$no=1;
				while ($row=mysqli_fetch_array($run_query)) 
				{
					$pro_id=$row['product_id'];
					$pro_image=$row['product_image'];
					$pro_name=$row['product_title'];
					//$units=$row['units'];
					$pro_price=$row['price'];
					$qty=$row['qty'];

					
					echo"
			
						<div class='row'>
							<div class='col-md-3'>$no</div>
							<div class='col-md-3'><img src='farmer_images/$pro_image' width='60px' height='50px'></div>
							<div class='col-md-3'>$pro_name</div>
							
							<div class='col-md-3'>Rs.$pro_price.00 </div>

						</div>
						";
						$no=$no+1;
				}
					echo "
						<a style='float:right;' href='cart.php' class='btn btn-primary'>Edit&nbsp;&nbsp;<span class='glyphicon glyphicon-edit'></span></a>
						";
					exit();
				
			}
		}
			
		//cart.php 
		$pro_id='';
		$total_amt='';
		if(isset($_POST["checkout"]))
		{
			
			if($count>0)
			{
				$no=1;
				
				$total_amt=0;
				
				while ($row=mysqli_fetch_array($run_query)) 
				{
					$pro_id=$row['product_id'];
					$pro_image=$row['product_image'];
					$pro_name=$row['product_title'];
					$pro_price=$row['price'];
					$units=$row['units'];
					$qty=$row['qty'];
					$total=$row['total_amount'];
					
					//total Amount
					
					$price_array=array($total);
					$total_sum=array_sum($price_array);
					$total_amt=$total_amt + $total_sum;
	
				echo"
						<div class='row'>
							<div class='col-md-2'>
								<div class='btn btn-group'>
									<a href='' button pid='$pro_id'  class='btn btn-danger remove' ><span class='glyphicon glyphicon-trash'></span></a>
									<a href='' button pid='$pro_id'  class='btn btn-primary update' ><span class='glyphicon glyphicon-ok-sign'></span></a>
								</div>
							</div>
								<div class='col-md-2'><b>$pro_name</b></div>
								<div class='col-md-2'><b><img src='farmer_images/$pro_image' width='60px' height='50px'></div>
								<div class='col-md-1'><input type='text' pid='$pro_id' id='qty-$pro_id' class='form-control qty' value='$qty'  ></div>
								<div class='col-md-1'><b>$units</b></div>
								<div class='col-md-2'><input type='text' pid='$pro_id' id='price-$pro_id' class='form-control price' value='$pro_price' ></div>
								<div class='col-md-2'><input type='text' pid='$pro_id' id='total-$pro_id' class='form-control total' value='$total' ></div>
							</div>
						";
		
		
		
				}
			}
			
			//total amount
			if(isset($_POST["checkout"]))
			{
				echo "
					<div class='row'>
						<div class='col-md-8'></div>
						<div class='col-md-2'>
							<h3><b>Total Rs.$total_amt</b></h3>
						</div>";
			}
			
			//paypal payment page
			//<input type="hidden" name="currency_code" value="USD">
			
			echo '
			
			<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="POST">
			<input type="hidden" name="cmd" value="_cart">
			<input type="hidden" name="business" value="apsitpro@gmail.com">
			
			<input type="hidden" name="upload" value="1">';
			
			$x=0;
			
			$user_id=$_SESSION["user_id"];
			
			$sql="SELECT * FROM cart WHERE user_id='$user_id'";
			
			$run_query=mysqli_query($con,$sql);
			
			while($row=mysqli_fetch_array($run_query))
			{	
				$x++;
			echo '
			
			<input type="hidden" name="item_name_'.$x.'" value="'.$row["product_title"].'">
			<input type="hidden" name="item_number_'.$x.'" value="'.$x.'">
			<input type="hidden" name="amount_'.$x.'" value="'.$row["price"].'">
			<input type="hidden" name="quantity_'.$x.'" value="'.$row["qty"].'">
			<input type="hidden" name="units_'.$x.'" value="'.$row["units"].'">
			';
			
			}
			
			echo '
			<input type="hidden" name="return" value="http://localhost/organic/payment_success.php">
			
			
			
			<input type="hidden" name="custom" value="'.$_SESSION["user_id"].'"/>
			
			<input type="hidden" name="cancel_return" value="http://localhost/organic/cancel_payment.php"/>
			
			<input type="hidden" name="notify_url" value="http://localhost/organic/payment_success.php">
			
			<input type="hidden" name="currency_code" value="USD">
			
			<input style="float:left;margin-left:80px;" type="image" name="submit"
			
			src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/PP_logo_h_200x51.png" alt="PayPal Logo"
			alt="PayPal - The safer, easier way to pay online">
			
			</form>
			
			';
			
		}
		
}

/*$id="";
if(isset($_POST["page"]))
{
	$sql="SELECT * FROM addproduct WHERE product_cat = '$id'";
	$run_query = mysqli_query($con,$sql);
	$count=mysqli_num_rows($run_query);
	$pageno=ceil($count/9);
	
	for($i=1;$i<=$pageno;$i++)
	{
		echo "<li><a href='#' page='$i' id='page'>$i</a></li> ";
	}
}*/

	
	
	if(isset($_POST["get_seleted_Category"]) || isset($_POST["search"]))
	{
	/*$limit = 6;
	if(isset($_POST["setpage"]))
	{

		$pageno = $_POST["pagenumber"];
		
		$start = ($pageno * $limit) - $limit;
		
	}else
	{
		$start = 0;
	}*/
	if(isset($_POST["get_seleted_Category"]))
	{	
		$id = $_POST["cat_id"];
		$sql = "SELECT * FROM addproduct WHERE product_cat = '$id' AND status='approved'";
	}
	else
	{
		
		$keyword = $_POST["keyword"] or die(mysqli_error($con));
		$sql = "SELECT * FROM addproduct WHERE product_desc LIKE '%$keyword%' AND status='approved'"  or die(mysqli_error($con));
	}
	
	$run_query = mysqli_query($con,$sql);
	while($row=mysqli_fetch_array($run_query))
	{
	
	/*$my_data='';
		if(isset($_POST["country"]))
		{
		$q=$_POST['q'];
	$my_data=$q;
	
		
	
	$sql = "SELECT * FROM products WHERE product_title LIKE '%$my_data%'"  or die(mysqli_error($con));
	$result = mysqli_query($con,$sql) or die(mysqli_error());
		/*while($row=mysqli_fetch_array($result))
		{
	
	
			if($result)
			{
			while($row=mysqli_fetch_array($result))
			{
			echo $row['product_title']."\n";*/
			
	
	
			$pro_id    = $row['product_id'];
			$pro_cat   = $row['product_cat'];
			$pro_title = $row['product_title'];
			$pro_price = $row['product_price'];
			$pro_image = $row['product_image'];
			echo "
				<div class='col-md-4'>
					
						<div class='cards'>
							<img class='cimg' src='farmer_images/$pro_image' style='width:100%; height:200px;'/>
							$pro_title<br>
							$pro_price Rupees<br>
							<button pid='$pro_id' id='product' class='act_btn 'style='width:103px;'>Add To Cart</button>
							<a href='view.php?product_id=$pro_id'><button pid='$pro_id' class='act_btn' >View</button></a>
						</div>
					
				</div>	
			";
			

		}
	}
		
		

	
  
	
//cart count

	if(isset($_POST["cart_count"]))
	{
		//if (isset($_SESSION))
		//{
		/*if (isset($_SESSION["id"]))
		{
			$sql="SELECT COUNT(*) AS cart_count FROM cart WHERE user_id=$_SESSION[id]" or die(mysqli_error($con));
		
		}
		else*/ if (isset($_SESSION["user_id"]))
		{
			$sql="SELECT COUNT(*) AS cart_count FROM cart WHERE user_id=$_SESSION[user_id]" or die(mysqli_error($con));
		
		}
		//}
		else
		{
		
		$sql = "SELECT COUNT(*) AS cart_count FROM cart WHERE ip_add = '$ip_add' AND user_id < 0";
		}
		$run_query=mysqli_query($con,$sql);
	$row = mysqli_fetch_array($run_query);
	echo $row["cart_count"];
	exit();
			
		
	}
	
if(isset($_POST["removeFromCart"]))
{
	$pro_id=$_POST["removeId"];
	
	$user_id=$_SESSION["user_id"];
		
		$sql = "DELETE FROM cart WHERE product_id = '$pro_id' AND user_id ='$user_id'";
	
	
	
	
	$run_query=mysqli_query($con,$sql);
	if($run_query)
	{
		echo "
			<div class='alert alert-danger'>
				<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
					<b>Product is Removed From Cart Continue Shopping..!</b>
			</div>";
		exit();
	}
}

if(isset($_POST["UpdateCart"]))
{
	$pro_id=$_POST["UpdateId"];
	$qty=$_POST["qty"];
	$price=$_POST["price"];
	$total=$_POST["total"];
	
	$user_id=$_SESSION["user_id"];
		
		$sql = "UPDATE cart SET qty='$qty',price='$price',total_amount='$total' WHERE product_id = '$pro_id' AND user_id ='$user_id'";
	
	
	
	
	$run_query=mysqli_query($con,$sql);
	if($run_query)
	{
		echo "
			<div class='alert alert-danger'>
				<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
					<b>Product is Updated..!</b>
			</div>";
		exit();

	}
}
include "close.php";
?>







