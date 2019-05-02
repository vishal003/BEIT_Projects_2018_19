<?php
include "db.php";

	/*if(mysqli_connect_error())
		{
			echo "connection failed: " . mysql_connect_error();
		}*/

	
    /*$name='';
	$email='';
	$gender='';
	$mobile='';
	$password='';
	*/
	 	
	if(isset($_POST["signup"])) 
	{
		$name=$_POST["name"]; 
		$email=$_POST["email"];
		$mobile=$_POST["mobile"];
		$gender=$_POST["gender"];
		$password=$_POST["pwd"];
		$user_activation_code = md5(rand());
		$user_email_status=	'not verified';
		
	
	
			if(empty($email) || empty($password))
			{
				echo "
					<div class='alert alert-warning'>
						<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><b>PLease Fill all fields..!</b>
					</div>
					";
				exit();
			} 
			else 
			{
				$sql = "SELECT user_id FROM users WHERE email = '$email' LIMIT 1" ;
				$check_query = mysqli_query($con,$sql);
				$count_email = mysqli_num_rows($check_query);
				if($count_email > 0)
				{
					echo "
							<script>alert('Email Address already registered Try another Email')
							window.location='Register.php';</script>
						";

				exit();
				}

			}

	}
		
	
	$sql="INSERT INTO users(first_name,email,mobile,gender,password,user_activation_code,user_email_status,created,modified)VALUES('$name','$email','$mobile','$gender','$password','$user_activation_code','$user_email_status','".date("Y-m-d H:i:s")."','".date("Y-m-d H:i:s")."')";
		
		if(isset($sql))
		{
			$base_url = "http://localhost/organic/";  //change this baseurl value as per your file path
			$mail_body = "
			<p>Hi ".$_POST['name'].",</p>
			<p>Thanks for Registration. Your password is ".$password.", This password will work only after your email verification.</p>
			<p>Please Open this link to verified your email address - ".$base_url."email_verification.php?activation_code=".$user_activation_code."
			<p>Best Regards,<br />OrganiCrate</p>
			";
			require 'class/class.phpmailer.php';
			$mail = new PHPMailer;
			$mail->IsSMTP();								//Sets Mailer to send message using SMTP
			$mail->Host = 'smtp.gmail.com';		//Sets the SMTP hosts of your Email hosting, this for Godaddy
			$mail->Port = '587';								//Sets the default SMTP server port
			$mail->SMTPAuth = true;							//Sets SMTP authentication. Utilizes the Username and Password variables
			$mail->Username = 'apsitproject@gmail.com';					//Sets SMTP username
			$mail->Password = 'Pass@123';					//Sets SMTP password
			$mail->SMTPSecure = 'tls';							//Sets connection prefix. Options are "", "ssl" or "tls"
			$mail->From = 'apsitproject@gmail.com';			//Sets the From email address for the message
			$mail->FromName = 'OrganiCrate';					//Sets the From name of the message
			$mail->AddAddress($_POST['email'], $_POST['name']);		//Adds a "To" address			
			$mail->WordWrap = 50;							//Sets word wrapping on the body of the message to a given number of characters
			$mail->IsHTML(true);							//Sets message type to HTML				
			$mail->Subject = 'Email Verification';			//Sets the Subject of the message
			$mail->Body = $mail_body;							//An HTML or plain text message body
			if($mail->Send())								//Send an Email. Return true on success or false on error
			{
				$message = '<label class="text-success">Register Done, Please check your mail.</label>';
			}
			//sending Text message
			$msg = "Thanks for Registration. Kindly verify your Email and Enjoy Online Shopping. ";
			$authKey = "269378A6QTLMKWTK5c9cdd08";
			$senderId = "OGCART";
			$route = "4";
			$postData = array(
			    'authkey' => $authKey,
			    'mobiles' => $mobile,
			    'message' => $msg,
			    'sender' => $senderId,
			    'route' => $route,
			    'country'=>'0'
			);
			$url="https://control.msg91.com/api/sendhttp.php";
			$ch = curl_init();
			    curl_setopt_array($ch, array(
			    CURLOPT_URL => $url,
			    CURLOPT_RETURNTRANSFER => true,
			    CURLOPT_POST => true,
			    CURLOPT_POSTFIELDS => $postData
			));
			curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
			curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
			$output = curl_exec($ch);
			 if(curl_errno($ch))
			{
			    echo 'error:' . curl_error($ch);
			}
			curl_close($ch);
			echo '<script>alert("Message sent Successfully")</script>';
			

		}
	
	

	
	if(!mysqli_query($con,$sql))
	{
		die('Error: ' . mysqli_error($con));
	}

	header('location: login.php');
	
	//mysqli_close($con);
	?>
	<?php include "close.php"; ?>
