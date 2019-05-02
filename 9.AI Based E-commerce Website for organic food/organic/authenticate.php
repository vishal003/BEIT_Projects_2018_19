<?php 
require_once 'fbconfig.php';

if(isset($_REQUEST['code'])){
	header('Location: authenticate.php');
}
############ Set Fb access token ############
if(isset($_SESSION['fb_token'])){
		$facebook->setDefaultAccessToken($_SESSION['fb_token']);
}
else{
	$_SESSION['fb_token'] = (string) $accessToken;
	$oAuth2Client = $facebook->getOAuth2Client();
	$longLivedAccessToken = $oAuth2Client->getLongLivedAccessToken($_SESSION['fb_token']);
	$_SESSION['fb_token'] = (string) $longLivedAccessToken;
	$facebook->setDefaultAccessToken($_SESSION['fb_token']);
}
############ Fetch data from graph api  ############
try {
	$profileRequest = $facebook->get('/me?fields=id,name,first_name,last_name,email,link,gender,birthday,cover,picture{url}');
	$fbuserData = $profileRequest->getGraphNode()->asArray();
} catch(FacebookResponseException $e) {
	echo 'Graph returned an error: ' . $e->getMessage();
	session_destroy();
	header("Location: ./");
	exit;
} catch(FacebookSDKException $e) {
	echo 'Facebook SDK returned an error: ' . $e->getMessage();
	session_destroy();
	header("Location: ./");
	exit;
}

############ Store data in database  ############

$oauthpro = "facebook";
$oauthid = $fbuserData['id'] ?? '';
$f_name = $fbuserData['first_name'] ?? '';
$l_name = $fbuserData['last_name'] ?? '';
$gender = $fbuserData['gender'] ?? '';
$email_id = $fbuserData['email'] ?? '';
$dob = $fbuserData['birthday'];
$picture = $fbuserData['picture']['url'] ?? '';
$url = $fbuserData['link'] ?? '';

/* ---- Session Variables -----*/
		$_SESSION['id'] = $oauthid;           
        $_SESSION['name'] = $f_name;
	    $_SESSION['email'] =  $email_id;
		$_SESSION['link'] =  $url;
		$_SESSION['gender'] =  $gender;
		$_SESSION['dob'] =  $dob;
	    

$sql = "SELECT * FROM fbusers WHERE oauthid='".$fbuserData['id']."'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
   $conn->query("update fbusers set f_name='".$f_name."', l_name='".$l_name."', email_id='".$email_id."', gender='".$gender."', picture='".$picture."', url='".$url."' where oauthid='".$oauthid."' ");
  // $query1 = "UPDATE users SET name = '".$f_name."', email = '".$email_id."' WHERE name = '".$f_name."'";
	//$conn->query($query1);
} else {
	$conn->query("INSERT INTO fbusers (oauth_pro, oauthid, f_name, l_name, email_id, gender , picture, url) VALUES ('".$oauthpro."', '".$oauthid."', '".$f_name."', '".$l_name."', '".$email_id."', '".$gender."','".$picture."', '".$url."')");  
	//$query1 = "INSERT INTO users SET name = '".$f_name."', email = '".$email_id."'";
	//$conn->query($query1);
}
$res = $conn->query($sql);
$userData = $res->fetch_assoc();

$sql1 = "SELECT * FROM users WHERE oauth_uid='".$oauthid."'";
$result1 = $conn->query($sql1);
if ($result1->num_rows > 0) {
   $conn->query("update users set first_name='".$f_name."', last_name='".$l_name."', email='".$email_id."', gender='".$gender."', picture='".$picture."', link='".$url."',modified = '".date("Y-m-d H:i:s")."' where oauth_uid='".$oauthid."'");
} else {
	$conn->query("INSERT INTO users (oauth_provider,oauth_uid,first_name,last_name,email,gender,picture,link,created,modified) VALUES ('".$oauthpro."','".$oauthid."','".$f_name."','".$l_name."','".$email_id."','".$gender."','".$picture."', '".$url."','".date("Y-m-d H:i:s")."','".date("Y-m-d H:i:s")."')");  
}
$res1 = $conn->query($sql1);
$userData1 = $res1->fetch_assoc();


/*
	$prevQuery1 = "SELECT * FROM users WHERE name = '".$f_name."'";
        $prevResult1 = $conn->query($prevQuery1);
		if($prevResult1->num_rows > 0){
        //Update user data if already exists
            $query1 = "UPDATE users SET name = '".$f_name."', email = '".$email_id."' WHERE name = '".$f_name."'";
            $update1 = $conn->query($query1);
        }else{
        //Insert user data
			$query1 = "INSERT INTO users SET name = '".$f_name."', email = '".$email_id."'";
            $insert1 = $conn->query($query1);
        }
		$result = $conn->query($prevQuery1);
        $userData = $result->fetch_assoc();
		*/		
		$_SESSION['userData'] = $userData;
		$sqlt="SELECT * FROM users WHERE oauth_uid='".$oauthid."'";
		$run_query=mysqli_query($con,$sqlt);
		$count=mysqli_num_rows($run_query);
	
	if($count>0)
	{
		$row=mysqli_fetch_array($run_query);
		
		$_SESSION['user_id']=$row['user_id'];
		$_SESSION['name']=$row['name'];
	}
		

header("Location: index.php");
include "close.php";
?>