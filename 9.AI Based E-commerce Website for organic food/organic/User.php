<?php
include "db.php";
class User {
	private $dbHost     = "localhost";
    private $dbUsername = "root";
    private $dbPassword = "";
    private $dbName     = "organic";
    private $userTbl    = 'gusers';
	
	function __construct(){
        if(!isset($this->db)){
            // Connect to the database
            $con = new mysqli($this->dbHost, $this->dbUsername, $this->dbPassword, $this->dbName);
            if($con->connect_error){
                die("Failed to connect with MySQL: " . $con->connect_error);
            }else{
                $this->db = $con;
            }
        }
    }
	
	function checkUser($userData = array()){
        if(!empty($userData)){
            //Check whether user data already exists in database
           /* $prevQuery = "SELECT * FROM ".$this->userTbl." WHERE oauth_provider = '".$userData['oauth_provider']."' AND oauth_uid = '".$userData['oauth_uid']."'";
            $prevResult = $this->db->query($prevQuery);
			
            if($prevResult->num_rows > 0){
                //Update user data if already exists
                $query = "UPDATE ".$this->userTbl." SET first_name = '".$userData['first_name']."', last_name = '".$userData['last_name']."', email = '".$userData['email']."', gender = '".$userData['gender']."', locale = '".$userData['locale']."', picture = '".$userData['picture']."', link = '".$userData['link']."', modified = '".date("Y-m-d H:i:s")."' WHERE oauth_provider = '".$userData['oauth_provider']."' AND oauth_uid = '".$userData['oauth_uid']."'";
                $update = $this->db->query($query);
            }else{
                //Insert user data
                $query = "INSERT INTO ".$this->userTbl." SET oauth_provider = '".$userData['oauth_provider']."', oauth_uid = '".$userData['oauth_uid']."', first_name = '".$userData['first_name']."', last_name = '".$userData['last_name']."', email = '".$userData['email']."', gender = '".$userData['gender']."', locale = '".$userData['locale']."', picture = '".$userData['picture']."', link = '".$userData['link']."', created = '".date("Y-m-d H:i:s")."', modified = '".date("Y-m-d H:i:s")."'";
                $insert = $this->db->query($query);
            }*/
			include "db.php";
			$prevQuery1 = "SELECT * FROM users WHERE email='".$userData['email']."'";
            $prevResult1 = mysqli_query($con,$prevQuery1);
			if($prevResult1->num_rows > 0){
                $sql="SELECT * FROM users WHERE email='".$userData['email']."' ";
                $run_query=mysqli_query($con,$sql);
                $count=mysqli_num_rows($run_query);

                if($count>0)
                {
                    $row=mysqli_fetch_array($run_query);
                    
                    $_SESSION['user_id']=$row['user_id'];
                    $_SESSION['name']=$row['name'];
                    
                    //}
                    //Update user data if already exists
                    //$row=mysqli_fetch_array($run_query);
                    if($row['user_email_status'] == 'verified')
                    {
                        $query1 = "update users set first_name='".$userData['first_name']."', 
                                    last_name='".$userData['last_name']."',email='".$userData['email']."', gender='".$userData['gender']."',locale='".$userData['locale']."', picture='".$userData['picture']."',link='".$userData['link']."', modified='".date("Y-m-d H:i:s")."' WHERE oauth_provider = '".$userData['oauth_provider']."' AND oauth_uid = '".$userData['oauth_uid']."'";
                        $update1 = $this->db->query($query1);
                    }
                    else{
                        echo '<script type="text/javascript">
                        alert("Please First Verify, your email address");
                        window.location="login.php";
                        </script>'; 
                        session_destroy();
                        exit(); 
                    }
                }

            }else{
                //Insert user data
                $user_activation_code = md5(rand());
                $user_email_status= 'not verified';
                $query1 = "INSERT INTO users (oauth_provider,oauth_uid,first_name,last_name,email,gender,user_activation_code,  user_email_status,locale,picture,link,created,modified) VALUES ('".$userData['oauth_provider']."','".$userData['oauth_uid']."','".$userData['first_name']."','".$userData['last_name']."','".$userData['email']."','".$userData['gender']."','$user_activation_code','$user_email_status','".$userData['locale']."','".$userData['picture']."','".$userData['link']."','".date("Y-m-d H:i:s")."','".date("Y-m-d H:i:s")."')";
                $insert1 = $this->db->query($query1);
               
                if(isset($insert1))
                {
                    $base_url = "http://localhost/organic/";  //change this baseurl value as per your file path
                    $mail_body = "
                    <p>Hi ".$_SESSION['givenName'].",</p>
                    <p>Thanks for Registration. This password will work only after your email verification.</p>
                    <p>Please Open this link to verified your email address - ".$base_url."email_verification.php?activation_code=".$user_activation_code."
                    <p>Best Regards,<br />OrganiCrate</p>
                    ";
                    require 'class/class.phpmailer.php';
                    $mail = new PHPMailer;
                    $mail->IsSMTP();                                //Sets Mailer to send message using SMTP
                    $mail->Host = 'smtp.gmail.com';     //Sets the SMTP hosts of your Email hosting, this for Godaddy
                    $mail->Port = '587';                                //Sets the default SMTP server port
                    $mail->SMTPAuth = true;                         //Sets SMTP authentication. Utilizes the Username and Password variables
                    $mail->Username = 'apsitproject@gmail.com';                 //Sets SMTP username
                    $mail->Password = 'Pass@123';                   //Sets SMTP password
                    $mail->SMTPSecure = 'tls';                          //Sets connection prefix. Options are "", "ssl" or "tls"
                    $mail->From = 'apsitproject@gmail.com';         //Sets the From email address for the message
                    $mail->FromName = 'OrganiCrate';                    //Sets the From name of the message
                    $mail->AddAddress($_SESSION['email'], $_SESSION['familyname']);     //Adds a "To" address           
                    $mail->WordWrap = 50;                           //Sets word wrapping on the body of the message to a given number of characters
                    $mail->IsHTML(true);                            //Sets message type to HTML             
                    $mail->Subject = 'Email Verification';          //Sets the Subject of the message
                    $mail->Body = $mail_body;                           //An HTML or plain text message body
                    if($mail->Send())                               //Send an Email. Return true on success or false on error
                    {
                        $message = '<label class="text-success">Register Done, Please check your mail.</label>';
                    }
                }
                session_destroy();
            }
            
            /*
			$sql1 = "SELECT * FROM users WHERE user_id='".$userData['oauth_uid']."'";
			$result1 = $conn->query($sql1);
			if ($result1->num_rows > 0) {
			   $conn->query("update users set first_name='".$userData['first_name']."', last_name='".$userData['last_name']."', email='".$userData['email']."',modified = '".date("Y-m-d H:i:s")."' where user_id='".$userData['oauth_uid']."'");
			} else {
				$conn->query("INSERT INTO users (user_id,oauth_provider,first_name,last_name,email,gender,picture,link,created,modified) VALUES ('".$userData['oauth_uid']."','".$userData['oauth_provider']."','".$userData['first_name']."','".date("Y-m-d H:i:s")."','".date("Y-m-d H:i:s")."')");  
			}
			$res1 = $conn->query($sql1);
			$userData1 = $res1->fetch_assoc();
			*/
			
            
            //Get user data from the database
            //$result = $this->db->query($prevQuery);
            //$userData = $result->fetch_assoc();
			//$result1 = $this->db->query($prevQuery1);
            //$userData1 = $result1->fetch_assoc();
        }

        //Return user data
        return $userData;
    }
}
?>
<?php

?>
<?php include "close.php"; ?>