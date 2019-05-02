<?php
include "header.php";
include "side_menu_2.php";
include "db.php";

	$product_title='';
	$quantity='';
	$units='';
	$product_price='';
	$product_cat='';
	$product_desc='';
	$newname='';
	$url='';
	$date='';
	$type='';
	$size='';
	$product_image='';
	$img_newfile='';
	$datetime='';
	$farmer_id='';
	$pro_image='';
	

		
	 	
	if(isset($_POST['upload']))
	{

		$datetime = date('Y-m-d H:i:s');
		$pro_image=$_FILES['photo']['name'];
		$size=$_FILES['photo']['size'];
		$type=$_FILES['photo']['type'];
		$temp=$_FILES['photo']['tmp_name'];
		$img_extension = explode('.',$product_image);
		$img_extension = strtolower(end($img_extension));	
		$img_newfile = uniqid().'.'.$img_extension; 
		$file_tem_Loc=$_FILES['photo']['tmp_name'];
		$store="farmer_images/".$product_image;
		if(move_uploaded_file($temp,$store.$pro_image))

		$farmer_id=$_SESSION["farmer_id"];
		
		$product_title=$_POST["product_title"];
		$quantity=$_POST["quantity"];
		$product_price=$_POST["product_price"];
		$units=$_POST["units"];
		$product_cat=$_POST["product_cat"];
		$product_desc=$_POST["product_desc"];
		
	}
	
	

	$sql="INSERT INTO addproduct(farmer_id,date,product_image,newname,file_type,file_size,product_title,quantity,units,product_price,product_cat,product_desc)VALUES
								('$farmer_id','$datetime','$product_image','$img_newfile','$type','$size','$product_title','$quantity','$units','$product_price','$product_cat','$product_desc')";
	$data	=	mysqli_query($con, $sql);
		
if($data == TRUE)
	{
		echo
		'<script type="text/javascript">
		alert("Your Product Is Uploaded....")
		window.location="add_products.php";		
		</script>';
	}
	else if(!$data == TRUE)
	{
		echo
		'<script type="text/javascript">
		alert("Something Wents wrong....")
		window.location="add_products.php";		
		</script>';
	}
	else
	{
				echo
		'<script type="text/javascript">
		alert("Something Wents wrong....")
		window.location="add_products.php";		
		</script>';
	}
		
	
	
	

?>





