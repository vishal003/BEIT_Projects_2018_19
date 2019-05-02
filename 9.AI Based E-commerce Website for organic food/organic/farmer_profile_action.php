<?php
include "session.php";
include('db.php');
if(isset($_POST['submit'])) 
{
	
	$usertype="2";
	$firstname=trim($_POST['firstname']);
	$gender=trim($_POST['gender']);
	$email=trim($_POST['email']);
	$mobile=trim($_POST['mobile']);
	
	if (isset($_SESSION['farmer_id'])) {
		$user_id = $_SESSION['farmer_id'];
		$sqlSignup= "UPDATE  farmers SET f_name='$firstname',mobile='$mobile',gender='$gender' WHERE farmer_id='$user_id'";
		$sendData=mysqli_query($con, $sqlSignup);		
	}
	else{
			echo '<script type="text/javascript">
		alert("Data not sucessfully Updated ...!!");
		window.location="farmer_profile.php";
		</script>';	

	}
	if($sendData == TRUE)  
	   {
		echo '<script type="text/javascript">
		alert("User information updated successfully!!!");
		window.location="farmer_profile.php";
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
	echo "f_name='$firstname',mobile='$mobile',gender='$gender', user_id=$user_id";

}

?>
<?php include "close.php"; ?>