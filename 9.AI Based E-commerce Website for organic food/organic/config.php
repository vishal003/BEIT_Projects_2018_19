<?php
	session_start();
	require_once "GoogleAPI/vendor/autoload.php";
	$gClient = new Google_Client();
	$gClient->setClientId("899014098185-4a48gvk1615vs9fuiav4h4sa7hinh1fd.apps.googleusercontent.com");
	$gClient->setClientSecret("iuAAje3StJImlad8D2bzcewu");
	$gClient->setApplicationName("OrganiCrate");
	$gClient->setRedirectUri("http://localhost/organic/g-callback.php");
	$gClient->addScope("https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email");
?>	
<?php include "close.php"; ?>	

