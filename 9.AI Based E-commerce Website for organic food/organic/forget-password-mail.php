<?php
require_once 'vendor/autoload.php';
define("PROJECT_NAME", "http://localhost/organic/");
$mail = new PHPMailer\PHPMailer\PHPMailer;
//Enable SMTP debug mode
$mail->SMTPDebug = 0;
//set PHPMailer to use SMTP
$mail->isSMTP();
//set host name
$mail->Host = "smtp.gmail.com";
// set this true if SMTP host requires authentication to send mail
$mail->SMTPAuth = true;
//Provide username & password
$mail->Username = "apsitproject@gmail.com";
$mail->Password = "Pass@123";
$mail->SMTPSecure = "tls";
$mail->Port = 587;

$mail->From = "apsitproject@gmail.com";
$mail->FromName = "OrganiCrate";
$mail->addAddress($_POST["user-email"]);
$mail->isHTML(true);

$mail->Subject = "Forget Password Recovery";
$mail->Body="<div>".$user[0]["name"]."<br><br><p>Click here to recover your password<br>
    <a href='".PROJECT_NAME."resetPassword.php?name=".$user[0]["name"]."'> ".PROJECT_NAME.
        "resetPassword.php?name=".$user[0]["name"]."</a><br><br></p>Regards<br> Admin.</div>";

        if(!$mail->send()) {
            $error_message = "Mailer Error : ". $mail->ErrorInfo;
        } else {
            $success_message = "Message has been sent successfully";
        }
        <?php include "close.php"; ?>


