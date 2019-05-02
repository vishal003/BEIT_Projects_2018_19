<?php
	//include "db.php";
 	include "session.php";
	if(isset($_POST['upload']))
	{
		include "db.php";
		$farmer_id=$_SESSION["farmer_id"];
		$product_title=$_POST["product_title"];
		$quantity=$_POST["quantity"];
		$product_price=$_POST["product_price"];
		$units=$_POST["units"];
		$product_cat=$_POST["product_cat"];
		$product_desc=$_POST["product_desc"];
		
		$datetime = date('Y-m-d H:i:s');
		$product_image=$_FILES['photo']['name'];
		$size=$_FILES['photo']['size'];
		$type=$_FILES['photo']['type'];
		$temp=$_FILES['photo']['tmp_name'];
		$img_extension = explode('.',$product_image);
		$img_extension = strtolower(end($img_extension));	
		$img_newfile = uniqid().'.'.$img_extension; 
		$file_tem_Loc=$_FILES['photo']['tmp_name'];
		$store="farmer_images/".$product_image;
		$limitsize=1000000; //for 1 mb
		if (empty($product_title || $product_cat || $quantity || $product_price || $units))
		{
		$msg="Please select file...";
}
elseif($quantity<=0){
	$msg="please enter the valid quantity for product";
}

elseif($product_price<=0){
	$msg="please enter the valid price for product";
}
		else {
				if($img_extension=='jpg' || $img_extension=='jpeg' || $img_extension=='bmp' || $img_extension=='png')
				{
					if($size <= $limitsize)
					{
								if(move_uploaded_file($temp,$store.$pro_image))
								{
								$sql="INSERT INTO addproduct(farmer_id,date,product_image,newname,file_type,file_size,product_title,quantity,units,product_price,product_cat,product_desc,status)VALUES
											('$farmer_id','$datetime','$product_image','$img_newfile','$type','$size','$product_title','$quantity','$units','$product_price','$product_cat','$product_desc','disapproved')";
														$data	=	mysqli_query($con, $sql);
														
											if($data == TRUE)
											{
												echo
												'<script type="text/javascript">
												alert("Your Product Is Uploaded ....");
												window.location="add_products.php";
												</script>';
											}
											else{
												'<script type="text/javascript">
												alert("Something Went Wrong....");
												window.location="add_products.php";

												</script>';
												
												}
								}
					}
					else{
						$msg="This file could not be uploaded. Please check file size.";	
					}
				}
				else{
					$msg="Uploaded file format doesn't allowed";
					}
				
				
	}
	
		
	echo '<script type="text/javascript">
	alert("'.$msg.'");
	window.location="add_products.php";
	</script>';	

	
	}
	
?>