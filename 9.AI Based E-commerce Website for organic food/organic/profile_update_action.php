<?php
include "session.php";
include('db.php');
if(isset($_POST['submit'])) 
{
	
	$usertype="2";
	//$date = date('Y-m-d H:i:s');
	//$username=trim($_POST['email_id']);
	//$userpass=trim($_POST['password']);
	//$passconf=trim($_POST['conf_password']);
	//$user_id=trim($_POST['user_id']);
	$firstname=trim($_POST['firstname']);
	//$lastname=trim($_POST['lastname']);
	$gender=trim($_POST['gender']);
	$dob=trim($_POST['dob']);
	$email=trim($_POST['email']);
	$address=trim($_POST['address']);
	$city=trim($_POST['city']);
	$state=trim($_POST['state']);
	$country='India';
	$pincode=trim($_POST['pincode']);
	$mobile=trim($_POST['mobile']);
	if (isset($_SESSION['user_id'])) {
			$user_id=$_SESSION['user_id'];
	}
	/*elseif (isset($_SESSION['id'])) {
	
			$user_id=$_SESSION['id'];
	}*/
	//$newsletter="";
	//$newsletter=trim($_POST['newsletter-product']).($_POST['newsletter-offers']);
	
	/*$terms=trim($_POST['accept-terms']);
	$status="pending";*/

	//if ($userpass != $passconf)
	/*{
		echo '<script type="text/javascript">
		alert("Your confirmation password is not matching");
		window.location="blogger_signup1.php";
		</script>';	
	}*/
	
		//include('../connect.php');
	/*if (isset($_SESSION['id'])) {
	
		$sqlSignup= "UPDATE  users SET name='$firstname',mobile='$mobile', dob='$dob', address='$address', city='$city', state='$state', pincode='$pincode' WHERE oauth_uid='$user_id'";
		$sendData=mysqli_query($con, $sqlSignup);
	}*/
	if (isset($_SESSION['user_id'])) {

		$sqlSignup= "UPDATE  users SET first_name='$firstname',email='$email',mobile='$mobile',gender='$gender',dob='$dob', address='$address', city='$city', state='$state', pincode='$pincode', modified='".date("Y-m-d H:i:s")."' WHERE user_id='$user_id'";
		$sendData=mysqli_query($con, $sqlSignup);		
	}
	else{
			echo '<script type="text/javascript">
		alert("Data not sucessfully Updated ...!!");
		window.location="personal_info.php";
		</script>';	

	}
	if($sendData == TRUE)  
	   {
		echo '<script type="text/javascript">
		alert("User information updated successfully!!!");
		window.location="personal_info.php";
		</script>';	
		}
	   else
	   {
		echo '<script type="text/javascript">
		alert("Sorry your account has not been created. Please try again");
		</script>';			
	   }
	 /*if (isset($_SESSION['user_id'])) {  
			echo $user_id;
			echo "name='$firstname',mobile='$mobile', dob='$dob', address='$address', city='$city', state='$state', pincode='$pincode', modified='.date('Y-m-d H:i:s').'";
		}*/

	//include('close.php');
	

}

?>
<?php include "close.php"; ?>