<?php
//error_reporting(0);
include('../connect.php');
	
/*if (isset($_POST['upload']))
{
	//echo "hello";
	//$ipaddress=getRealIpAddr();
	//$datetime = date('Y-m-d H:i:s');
	
	//$errors= array();
			
	//$sql1=mysqli_query($conn,"select user_id from member_accounts where username='$login_session'");
	//$getid = mysqli_fetch_assoc($sql1);
	//$userid =$getid['user_id'];
		
	//$status="pending";	
	//$approvedby="none";	
	//$title=$_POST['title'];
	$type=$_POST['category'];
	$captn=$_POST['caption'];
	$name=$_POST['file_name'];
	//$description=$_POST['description'];
	//$tags=$_POST['tags'];
	
	$file_name=$_FILES['file']['name'];
	$size=$_FILES['file']['size'];
	$type=$_FILES['file']['type'];
	$temp=$_FILES['file']['tmp_name'];
	
	$img_extension = explode('.',$name);
	$img_extension = strtolower(end($img_extension));	
	$img_newfile = uniqid().'.'.$img_extension; 
	//$store= "../pictures/";
	
	$msg="";
	
	$limitsize=16777216; //for 16 mb
	//$limitsize=4194304; //for 4 mb
	//$limitsize=1048576; //for 1 mb
	//$limitsize=200000; //for 200 KB
	
	if (empty($name)){
		$msg="Please select file";
	}
	else {
		//$msg="Uploaded";
		if($img_extension=='jpg' || $img_extension=='png'|| $img_extension=='jpeg'){
			$msg="Uploaded file is " . $img_extension ;
			
			if($size < $limitsize){
				$msg="Uploaded file size is " . $size;
				
				
					//$url="http://www.marthas.org/".$store.$img_newfile;
					//$msg="File stored in uploads and new name is " . $img_newfile;

					
					//include('../connect.php');
												
					$sqlSave=mysqli_query($conn,"INSERT INTO photos(file_name,caption,category)VALUES('$name','$captn','$type')");
						
						if($sqlSave == TRUE){	
							$msg=$name . " file uploaded successfully.";
						}
						else {
							$msg="Something went wrong please try again.";
							//unlink($store.$img_newfile);
						}
						
					
					
					
				
				
				
			}
			
			else {
				//$msg="Maximum file size limit is " . $limitsize ."Byte";
				$msg="Maximum file size limit is 4MB.";
			}
			
		}
		
		else {
			$msg="Uploaded file format doesn't allowed";
		}
	}
	include('close.php');
	echo '<script type="text/javascript">
	alert("'.$msg.'");
	</script>';		
	
} */ 
if (isset($_POST['upload']))
{
	//echo "hello";
	//$ipaddress=getRealIpAddr();
	//$datetime = date('Y-m-d H:i:s');
		
	//$status="pending";	
	//$approvedby="none";	
	$category=$_POST['category'];
	$caption=$_POST['caption'];
	
	$file_name=$_FILES['photo']['name'];
	$size=$_FILES['photo']['size'];
	$type=$_FILES['photo']['type'];
	$temp=$_FILES['photo']['tmp_name'];
	
	$img_extension = explode('.',$file_name);
	$img_extension = strtolower(end($img_extension));	
	$img_newfile = uniqid().'.'.$img_extension; 
	$store= "direct-upload/";

	$msg="";
	
	$limitsize=1048576; //for 1 mb
	//$limitsize=200000; //for 200 KB
	
	if (empty($file_name || $category)){
		$msg="Please select file...";
	}
	/*else if(empty($category))
	{
		$msg="please select the category...";
	}*/
	else {
		//$msg="Uploaded";
		if($img_extension=='jpg' || $img_extension=='jpeg' || $img_extension=='bmp' || $img_extension=='png'){
			//$msg="Uploaded file is " . $img_extension ;
			
			if($size <= $limitsize){
				//$msg="Uploaded file size is " . $size;
				
				if(move_uploaded_file($temp,$store.$img_newfile)){
					$url=$store.$img_newfile;
					//$url="http://www.marthas.org/".$store.$img_newfile;
					//$msg="File stored in uploads and new name is " . $img_newfile;

					
					//include('connect.php');
												
					$sqlSave=mysqli_query($conn,"INSERT INTO upload_photo (url,file_name, category , newname, filetype, filesize,caption) VALUES('$url','$file_name','$category', '$img_newfile','$type', '$size','$caption')");
						
						if($sqlSave == TRUE){	
							$msg=$file_name . " file uploaded successfully.";
						}
						else {
							$msg="Something went wrong please try again.";
							unlink($store.$img_newfile);
						}
						
					
					include('../close.php');
					
				}
				
				else {
					$msg="This file could not be uploaded. Please check file size.";
				}
				
			}
			
			else {
				//$msg="Maximum file size limit is " . $limitsize ."Byte";
				$msg="Maximum file size limit is 1 MB.";
			}
			
		}
		
		else {
			$msg="Uploaded file format doesn't allowed";
		}
	}
	
	echo '<script type="text/javascript">
	alert("'.$msg.'");
	window.location="add_photos.php";
	</script>';	
	
} 
include('../close.php'); 
?>
